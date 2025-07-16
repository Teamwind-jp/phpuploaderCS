//	(c)Teamwind japan h.hayashi
//	サーバーメンテナンスツール Windows Server Maintenance Tools



using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace phpuploaderCS
{
    public partial class Form1 : Form
    {

		#region "my data"

		//zip folder textbox 入力フォルダ
		private TextBox[] txtpath = new TextBox[5];

		//timer process flag タイマー監視フラグ
		private Boolean fwatch = false;

		//copy start flag 
		//true=Monitoring batch time in timer process
		//It is turned on with the start button and executed immediately.

		//コピー開始フラグ
		//true=タイマーでバッチ時刻監視
		//開始ボタンでonにして即実行している
		private Boolean fgo = false;

		#endregion

		#region "delegates"

		//============================================================
		//   go sign
		//============================================================
		public bool dlg_getGo()
		{
			if (InvokeRequired)
			{
				return (bool)Invoke(new Func<bool>(dlg_getGo));
			}
			else
			{
				return fgo;
			}
		}

		private void dlg_setGo(Boolean b)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => fgo = b));
			}
			else
			{
				fgo = b;
			}
		}

		//============================================================
		//  Batch Time バッチ時刻 
		//	ComboBox1.SelectedIndex
		//============================================================
		private int dlg_comboBox1_selectedIndex()
		{
			if (InvokeRequired)
			{
				return (int)Invoke(new Func<int>(dlg_comboBox1_selectedIndex));
			}
			else
			{
				return ComboBox1.SelectedIndex;
			}
		}

		//============================================================
		//  Cut size カットサイズ
		//	ComboBox2.SelectedIndex
		//============================================================
		private int dlg_comboBox2_selectedIndex()
		{
			if (InvokeRequired)
			{
				return (int)Invoke(new Func<int>(dlg_comboBox2_selectedIndex));
			}
			else
			{
				return ComboBox2.SelectedIndex;
			}
		}

		//============================================================
		//   password パスワード
		//============================================================
		private string dlg_txtPsw_getText()
		{
			if (InvokeRequired)
			{
				return (string)Invoke(new Func<string>(dlg_txtPsw_getText));
			}
			else
			{
				return txtPsw.Text;
			}
		}
	
		//============================================================
		//   Change start button text 開始ボタン変更
		//============================================================
		private void dlg_setButton1Text(string str)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => Button1.Text = str));
			}
			else
			{
				Button1.Text = str;
			}
		}

		//============================================================
		//   Change message label メッセージラベル変更
		//============================================================
		private void dlg_setlmsg(string str)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => lblmsg.Text = str));
			}
			else
			{
				lblmsg.Text = str;
			}
		}

		#endregion

		#region "Main Thread メインスレッド "

		private long threadUpdate(System.ComponentModel.BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e)
		{
			do
			{
				System.Threading.Thread.Sleep(1000 * 10);

				//Is there a go command? go指示有るか　
				Boolean bgo = dlg_getGo();

				//If the copy thread is running, wait for it to finish.
				//コピー中なら終了待ち
				if (!bgo)
				{
					continue;
				}

				//msg out
				dlg_setButton1Text("stop");

				//zip and cut Create a work folder. ワークフォルダ作成
				string mywork = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\temp";
				try
				{
					System.IO.Directory.CreateDirectory(mywork);
				}
				catch (Exception)
				{
					continue;
				}

				//For storing the processed zip file name. 処理済みzipファイル名格納用
				List<string> z = new List<string>();
				z.Clear();

				//Process each specified folder. 指定フォルダ毎に処理する
				for (int i = 0; i < ini.g_targetPaths; i++)
				{
					//Determine zip name from target folder. 対象フォルダからzip名決定
					string zipname = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(ini.g_targetPath[i] + "\\"));
					if (zipname == "")
					{
						//If the folder name is empty, skip it. フォルダ名が空ならスキップ
						continue;
					}

					//If it already exists, it will be overwritten when you upload it, so give it a different name.
					//既に存在しているならアップロード時に上書きされるので別名を付ける
					if (z.Contains(zipname))
					{
						//Since it already exists, add "_n". すでにあるので「_n」を付ける
						zipname += "_" + i.ToString();
					}

					//Name is stored for the purpose of determining the above. ↑の判定用に名前保管
					z.Add(zipname);

					//zip start msg zip開始msg
					dlg_setlmsg(ini.g_targetPath[i] + " zipping");
					//Delete zip file from previous work 前回work内zip削除
					try
					{
						System.IO.File.Delete(mywork + "\\" + zipname + ".zip");
					}
					catch (Exception)
					{
						//Ignore errors. エラーは無視
					}

					//zip
					if (!zip.zip_createZip(ini.g_targetPath[i], mywork + "\\" + zipname + ".zip", dlg_txtPsw_getText()))
					{
						//failure 失敗
						common.textOut(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", "zip error: " + ini.g_targetPath[i]);
						continue;
					}

					//Prepare to send 送信準備

					//zip md5 acquisition. zip md5取得
					string zipmd5 = common.cmn_fileMD5(mywork + "\\" + zipname + ".zip");
					common.textOut(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", "success zip MD5: " + zipmd5);

					//Cut size カットサイズ
					int sepSize = dlg_comboBox2_selectedIndex() * 1024 * 1024;

					//Store list of file names after splitting. 分割後の送信ファイル名一覧保管
					ArrayList arrfiles = new ArrayList();
					arrfiles.Clear();
					//This is the file name in case of not splitting.
					arrfiles.Add(mywork + "\\" + zipname + ".zip");

					//Split zip into specified size. zipを指定サイズに分割

					//Get the size of a file. ファイルのサイズを取得
					System.IO.FileInfo fi = new System.IO.FileInfo(mywork + "\\" + zipname + ".zip");
					//Divide anything over the cut size. カットサイズ以上は分割
					if (sepSize > 0 && fi.Length > sepSize)
					{
						//The list of sending file names is reset in cmn_splitFile(). 送信ファイル名一覧はSplitFile内で再セットされる
						common.cmn_splitFile(mywork + "\\" + zipname + ".zip", sepSize, arrfiles);
					}

					//Send split files in sequence. 分割ファイルを順に送信
					for(int j = 0; j < arrfiles.Count; j++)
					{
						//Get the MD5 of the file. ファイルのMD5取得
						string md5 = common.cmn_fileMD5((string)arrfiles[j]);
						//Generate prm to pass to php. phpに渡すprm生成
						string prm = zipname + ".zip." + j.ToString("000") + "," + j.ToString("000") + "," + (arrfiles.Count - 1).ToString() + "," + md5 + "," + zipmd5;
						//msg
						dlg_setlmsg((string)arrfiles[j] + " sending");
						//Send the file to the server. サーバーにファイル送信
						try
							{
							//Send the file to the server. サーバーにファイル送信
							// Using Microsoft.VisualBasic.Devices.Network to upload the file [add Microsoft.VisualBasic.dll]
							Microsoft.VisualBasic.Devices.Network network =	new Microsoft.VisualBasic.Devices.Network();
							network.UploadFile(
								(string)arrfiles[j],
								ini.g_url + "?prm=" + prm,
								"username", "password",
								true, 60000,
								Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
							common.textOut(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", "upload ok: " + (string)arrfiles[j]);
						}
						catch (Exception ex)
						{
							//If an exception occurs, output the error message. 例外発生ならエラーメッセージ出力
							common.textOut(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", "upload exception: " + (string)arrfiles[j] + " " + ex.Message);
						}
					}

					//log out
					common.textOut(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", "done");
					//msg out
					myDateTime dt = new myDateTime();
					dlg_setlmsg(dt.ToString() + " done");

					//Erase go Wait for next timing. go消す 次のタイミング待ち状態にする
					dlg_setGo(false);
					//Return the button. ボタンも戻す
					dlg_setButton1Text("Start");
				}

			} while (true);

		}



		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			//BackgroundWorkerの取得
			System.ComponentModel.BackgroundWorker objWorker = sender as System.ComponentModel.BackgroundWorker;

			//ここから別世界
			//時間のかかる裏で動かしたい処理
			e.Result = threadUpdate(objWorker, e);

		}
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//Copy thread end. copyスレ終了
			fgo = false;
			fwatch = false;
			timer1.Enabled = false;
			MessageBox.Show("Copy process completed.");
		}


		#endregion


		#region "Start button processing. 開始ボタン処理"

		private void Button1_Click(object sender, EventArgs e)
		{
			ini.g_url = txtUrl.Text;
			ini.g_targetPaths = 0;
			for (int i = 0; i < txtpath.Length; i++)
			{
				if (txtpath[i].Text != "" && System.IO.Directory.Exists(txtpath[i].Text))
				{
					ini.g_targetPath[ini.g_targetPaths++] = txtpath[i].Text;
				}
			}

			if (ini.g_url == "")
			{
				MessageBox.Show("No URL specified. url指定無し");
				return;
			}

			if (ini.g_targetPaths == 0)
			{
				MessageBox.Show("No folder specified. フォルダ指定無し");
				return;
			}

			if (fwatch)
			{
				//If it is already running, stop it. すでに動いているなら止める
				if (MessageBox.Show("Already running. Stop it?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
				fwatch = false;
				dlg_setButton1Text("Start");
				return;
			}
			else
			{
				if(MessageBox.Show("Start the copy process?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}

			ini.g_sepSize = dlg_comboBox1_selectedIndex();
			ini.g_psw = txtPsw.Text;
			ini.ini_write();

			//監視timer開始
			fwatch = true;
		}

		#endregion


		#region "onload"

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
        {
			//Input box array. 入力box配列化
			txtpath = new System.Windows.Forms.TextBox[5] {
				TextBox2, TextBox3, TextBox4, TextBox5, TextBox6
			};

			//Set the drag and drop event. ドラッグ＆ドロップイベントセット
			for (int i = 0; i < txtpath.Length; i++)
			{
				txtpath[i].AllowDrop = true;
				txtpath[i].DragEnter += TextBox2_DragEnter;
				txtpath[i].DragDrop += TextBox2_DragDrop;
			}

			//time specification. 時刻指定
			ComboBox1.SelectedIndex = 24;

			//Split Size 分割サイズ
			for (int i = 0; i < 1024; i++)
			{
				ComboBox2.Items.Add(i.ToString());
			}
			ComboBox2.SelectedIndex = ini.g_sepSize;

			//Get previous value. 前回値取得
			ini.ini_read();

			//Previous value set. 前回値セット
			txtUrl.Text = ini.g_url;
			txtPsw.Text = ini.g_psw;
			for (int i = 0; i < ini.g_targetPaths; i++)
			{
				if (i > 4) break;
				txtpath[i].Text = ini.g_targetPath[i];
			}

			//Processing start flag. 処理開始フラグ
			fwatch = false;

			//Batch monitoring process started. バッチ監視処理開始
			timer1.Enabled = true;

			//Copy thread start. copyスレ開始
			backgroundWorker1.RunWorkerAsync();

		}

		#endregion

		#region "Timer processing. timer処理"

		//For current time. 現在時刻用
		private myDateTime dt = new myDateTime();

		//Next processing date and time. 次回処理日時
		private myDateTime dtbk = null;

		//This won't stop. こいつは止めない
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (!fwatch)
			{
				//No monitoring required. 監視不要
				return;
			}

			if(fgo)
			{
				//copying in progress. copy中
				return;
			}

			//Get current time. 現在時刻取得
			dt = new myDateTime();

			//Batch Start Time. バッチ開始時刻
			int h = dlg_comboBox1_selectedIndex();
			if(h < 0 || h > 23)
			{
				//Immediate start instruction. 即時開始指示
				fgo = true;
				//Stop monitoring. 監視止める
				fwatch = false;
				//Change the button text. ボタンのテキスト変更
				dlg_setButton1Text("stop");

				return;
			}

			//Batch time determination. バッチ時刻判定
			//Force execution of first batch Immediate processing. バッチ初回は強制実行 即時処理
			if(dtbk == null)
			{
				//Set next processing date. 次回処理日をセット
				//After completion, if the specified time has not passed today,
				//it will be executed again at the specified time, so the date will not be moved.
				//完了後　本日指定時刻が過ぎてなければ指定時刻に再実行するので日付移動はしない
				dtbk = (myDateTime)dt.Clone();
				if(dtbk.hour() > h)
				{
					//If the current time is past the specified time, set it to tomorrow.
					//現在時刻が指定時刻を過ぎているなら明日にセット
					dtbk.addDays(1);
				}
				//Specified time. 指定時刻
				dtbk.setHour(h);
				dtbk.setMinute(0);
				//Start instructions. 開始指示
				fgo = true;
				//Change the button text. ボタンのテキスト変更
				dlg_setButton1Text("stop");
				return;
			}



			//Time Check. 時間チェック
			if (dt.cmpDate(dtbk) < 0)
			{
				//yet
				dlg_setButton1Text("next " + dtbk.day().ToString() + " " + dtbk.hour().ToString("00") + ":00");
				return;
			}

			//Start here. ここまできたら開始
			//Set next processing date. 次回処理日をセット
			dtbk = (myDateTime)dt.Clone();
			dtbk.addDays(1);
			dtbk.setHour(h);
			dtbk.setMinute(0);

			//Immediately. 即時
			fgo = true;

			dlg_setButton1Text("stop");

			//timer continuation. timerは継続
		}

		#endregion

		#region "textbox d&d process. d&d処理"

		private void TextBox2_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void TextBox2_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length > 0)
			{
				TextBox tb = sender as TextBox;
				if (tb != null)
				{
					tb.Text = files[0];
				}
			}
		}


		#endregion
	}
}
