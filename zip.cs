using System;

static class zip
{

	public static Boolean zip_createZip(string szFromPath, string topath, string psw)
	{

		ICSharpCode.SharpZipLib.Zip.FastZip fastZip = new ICSharpCode.SharpZipLib.Zip.FastZip();

		//Put empty folders in the archive. 空のフォルダも書庫に入れるか。デフォルトはfalse 
		fastZip.CreateEmptyDirectories = true;
		//ZIP64を使うか。デフォルトはDynamicで、状況に応じてZIP64を使う 
		fastZip.UseZip64 = ICSharpCode.SharpZipLib.Zip.UseZip64.Dynamic;
		//Set Password. パスワードを設定するには次のようにする 
		fastZip.Password = psw;

		try
		{
			fastZip.CreateZip(topath, szFromPath, true, null);
		}
		catch (Exception)
		{
			return false;
		}

		return true;
	}

}