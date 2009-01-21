using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using EnterpriseDT.Net.Ftp;


namespace bakkappah
{
	public class bakkappah
	{
		static private NotifyIcon systray = new NotifyIcon();
		static private Properties props;
		static private Timer timer = new Timer();

		public static void Main() 
		{
			System.IO.Stream icon = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("bakkappah.bakkappah.ico");
			systray.Icon = new System.Drawing.Icon(icon);
			systray.Text = "bakkappah";
			props = new Properties();
			EventHandler quitHandler = new EventHandler(quit);

			ContextMenu menu = new ContextMenu();
			MenuItem item = new MenuItem("Backup now!", new EventHandler(sync));
			menu.MenuItems.Add(item);
			item = new MenuItem("Configuration", new EventHandler(config));
			menu.MenuItems.Add(item);
			item = new MenuItem("-");
			menu.MenuItems.Add(item);
			item = new MenuItem("Quit", quitHandler);
            menu.MenuItems.Add(item);

			systray.ContextMenu = menu;
			systray.Visible = true;

			timer.Tick += new EventHandler(sync);
			timer.Interval = props.Interval * 60000;
			timer.Start();

			Application.ApplicationExit += quitHandler;
			Application.Run();
		}

		private static void sync(object sender, EventArgs e)
		{
			RegistryKey key = getDataKey();
			FTPClient ftp = null;			

			DirectoryInfo dir = new DirectoryInfo(props.Folder);
			Regex regex = new Regex(props.Regex);

			try 
			{
				systray.Text = "bakkappah - connecting...";
				ftp = new FTPClient(props.Server, props.Port, 30000);
				ftp.Login(props.User, props.Password);
				ftp.ConnectMode = FTPConnectMode.ACTIVE;
				ftp.TransferType = FTPTransferType.BINARY;
				systray.Text = "bakkappah - uploading...";
				backup(ftp, dir, regex, key);
			} 
			catch 
			{
				return;
			}
			finally
			{
				try { ftp.Quit(); } 
				catch {}	
				systray.Text = "bakkappah";
			}

		}

		private static bool stringSearch(string[] haystack, string needle)
		{
			foreach (string str in haystack)
			{
				if (str == needle)
					return true;
			}
			return false;
		}

		private static void RecRm(FTPClient ftp, string name) 
		{
			ftp.ChDir(name);
			string[] list;
			if ((list = ftp.Dir(null, true)).Length > 0)
			{
				foreach (string thing in list)
				{
					string thingname = thing.Substring(56);
					if (thing.Substring(0,1) == "d")
						RecRm(ftp, thingname);
					else
						ftp.Delete(thingname);
				}
			}
			ftp.ChDir("..");
			ftp.RmDir(name);
		}

		private static void backup(FTPClient ftp, DirectoryInfo dir, Regex regex, RegistryKey key)
		{
				string[] files = ftp.Dir(null, true);
				string[] names = new string[files.Length];
				int i = 0;
				foreach (string file in files)
				{
					names[i] = file.Substring(56);
					if (file.Substring(0,1) == "d") 
					{
						// A directory!
						if (dir.GetDirectories(names[i]).Length != 1 && !names[i].Substring(0,1).Equals(".")) 
							RecRm(ftp, names[i]);
					}
					else 
						// A file!
						if (regex.IsMatch(names[i]) && dir.GetFiles(names[i]).Length != 1)
							ftp.Delete(names[i]);
					i++;
				}

				foreach (DirectoryInfo subdir in dir.GetDirectories())
				{
					if (!stringSearch(names, subdir.Name))
						ftp.MkDir(subdir.Name);

					ftp.ChDir(subdir.Name);
					backup(ftp, subdir, regex, getDataKey(ref key, subdir.Name));
					ftp.ChDir("..");
				}

				foreach (FileInfo file in dir.GetFiles())
				{
					if (!regex.IsMatch(file.Name))
						continue;

					if (file.LastWriteTime > getDateTime(key.GetValue(file.Name, "0001-01-01 00:00:00").ToString()))
					{
						ftp.Put(file.FullName, file.Name, false);
						key.SetValue(file.Name, DateTime.Now.ToString());
					}
				}
		}

		private static DateTime getDateTime(string date)
		{
			try 
			{
				int year = Int32.Parse(date.Substring(0, 4));
				int month = Int32.Parse(date.Substring(5, 2));
				int day = Int32.Parse(date.Substring(8, 2));
				int hour = Int32.Parse(date.Substring(11, 2));
				int minute = Int32.Parse(date.Substring(14, 2));
				int second = Int32.Parse(date.Substring(17, 2));
				return new DateTime(year, month, day, hour, minute, second);
			}
			catch
			{
				return new DateTime();
			}
		}

		private static RegistryKey getDataKey(string name)
		{
			RegistryKey key;
			if ((key = Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\data\\" + name, true)) == null)
				return Registry.CurrentUser.CreateSubKey("Software\\KdK\\bakkappah\\data\\" + name);
			return key;
		}

		private static RegistryKey getDataKey()
		{
			RegistryKey key;
			if ((key = Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\data", true)) == null)
				return Registry.CurrentUser.CreateSubKey("Software\\KdK\\bakkappah\\data");
			return key;
		}

		private static RegistryKey getDataKey(ref RegistryKey key, string name)
		{
			RegistryKey key2;
			if ((key2 = key.OpenSubKey(name, true)) == null)
				return key.CreateSubKey(name);
			return key2;
		}

		private static void config(object sender, EventArgs e)
		{
			props.Show();
			timer.Interval = props.Interval * 60000;
		}

		private static void quit(object sender, EventArgs e)
		{
			systray.Visible = false;
			Application.Exit();
		}
	}
}