

using System;
using System.Reflection;

static class ini
{

	#region "globals"

	public static string g_url = "";
	public static string g_psw = "";
	public static int g_sepSize = 10;

	public static string[] g_targetPath = new string[5];
	public static int g_targetPaths = 0;

	#endregion


	#region "ini io"

	//============================================================
    //   read
    //============================================================
	public static Boolean ini_read()
	{
		string sztemp;
		g_targetPaths = 0;

		try
			{
			sztemp = System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\prof.ini");
			string[] lines = sztemp.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			foreach (string line in lines)
			{
				if (line.StartsWith("url="))
				{
					g_url = line.Substring(4);
				}
				else if (line.StartsWith("psw="))
				{
					g_psw = line.Substring(4);
				}
				else if (line.StartsWith("sep="))
				{
					g_sepSize = int.Parse(line.Substring(4));
				}
				else if (line.StartsWith("path="))
				{
					if (g_targetPaths < g_targetPath.Length)
					{
						g_targetPath[g_targetPaths++] = line.Substring(5);
					}
				}
			}
			return true;
		}
		catch
		{
			return false;
		}

	}

	//============================================================
	//   Write
	//============================================================
	public static Boolean ini_write()
	{
		try
		{
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\prof.ini"))
			{
				sw.WriteLine("url=" + g_url);
				sw.WriteLine("psw=" + g_psw);
				sw.WriteLine("sep=" + g_sepSize);
				for (int i = 0; i < g_targetPaths; i++)
				{
					sw.WriteLine("path=" + g_targetPath[i]);
				}
			}
			return true;
		}
		catch
		{
			return false;
		}
	}


	#endregion







}












