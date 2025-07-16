using phpuploaderCS;
using System;
using System.Collections;
using System.Reflection;
using System.Security.Policy;

static class common
{

	#region "Splitting and merging files. ファイル分割　結合"

	public static void cmn_splitFile(string filePath, int chunkSize, ArrayList arr)
	{
		Byte[] buffer = new Byte[chunkSize];
		int fileIndex = 0;

		arr.Clear();

		using (System.IO.FileStream inputFile = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
		{
			int bytesRead;
			while ((bytesRead = inputFile.Read(buffer, 0, buffer.Length)) > 0)
			{
				string partFileName = $"{filePath}.{fileIndex:D3}";
				using (System.IO.FileStream partFs = new System.IO.FileStream(partFileName, System.IO.FileMode.Create))
				{
					partFs.Write(buffer, 0, bytesRead);
				}
				arr.Add(partFileName);
				fileIndex++;
			}
		}
	}

	#endregion

	#region "MD5"

	public static string cmn_fileMD5(string path)
	{
		//open file
		System.IO.FileStream fs = new System.IO.FileStream(
			path,
			System.IO.FileMode.Open,
			System.IO.FileAccess.Read,
			System.IO.FileShare.Read);

		//Create an MD5CryptoServiceProvider object. MD5CryptoServiceProviderオブジェクトを作成 
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = 
			new System.Security.Cryptography.MD5CryptoServiceProvider();

		//Calculate the hash value. ハッシュ値を計算する 
		byte[] hash = md5.ComputeHash(fs);

		//Freeing up resources. リソースを解放
		md5.Clear();
		//Close File. ファイルを閉じる 
		fs.Close();

		//Convert a byte array to a hexadecimal string. byte型配列を16進数の文字列に変換 
		System.Text.StringBuilder result = new System.Text.StringBuilder();
		foreach (byte b in hash)
		{
			result.Append(b.ToString("x2"));
		}

		return result.ToString();
	}



	#endregion

	#region "Text Output"

	public static void textOut(string path, string msg)
	{
		myDateTime dt = new myDateTime();
		try
		{
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true, System.Text.Encoding.UTF8))
			{
				sw.WriteLine(dt.ToString("yyyy/MM/dd HH:mm ") + msg);
			}
		}
		catch
		{
		}
	}


	#endregion





















}