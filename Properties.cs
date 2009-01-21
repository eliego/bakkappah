using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace bakkappah
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Properties : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.TextBox interval;
		private System.Windows.Forms.TextBox user;
		private System.Windows.Forms.TextBox server;
		private System.Windows.Forms.TextBox regex;
		private System.Windows.Forms.TextBox folder;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.TextBox port;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;

		public Properties()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Closing += new CancelEventHandler(Cancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (this.firstTimeInit()) 
			{
				this.Show("No configuration found, please inspect defaults");
			}
			this.Load += new EventHandler(this.loadData);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		public void Cancel(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Properties));
			this.save = new System.Windows.Forms.Button();
			this.password = new System.Windows.Forms.TextBox();
			this.interval = new System.Windows.Forms.TextBox();
			this.user = new System.Windows.Forms.TextBox();
			this.server = new System.Windows.Forms.TextBox();
			this.regex = new System.Windows.Forms.TextBox();
			this.folder = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.browse = new System.Windows.Forms.Button();
			this.port = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(288, 168);
			this.save.Name = "save";
			this.save.TabIndex = 9;
			this.save.Text = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(80, 136);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(192, 20);
			this.password.TabIndex = 7;
			this.password.Text = "";
			// 
			// interval
			// 
			this.interval.Location = new System.Drawing.Point(80, 168);
			this.interval.MaxLength = 3;
			this.interval.Name = "interval";
			this.interval.Size = new System.Drawing.Size(32, 20);
			this.interval.TabIndex = 8;
			this.interval.Text = "";
			// 
			// user
			// 
			this.user.Location = new System.Drawing.Point(80, 104);
			this.user.Name = "user";
			this.user.Size = new System.Drawing.Size(192, 20);
			this.user.TabIndex = 6;
			this.user.Text = "";
			// 
			// server
			// 
			this.server.Location = new System.Drawing.Point(80, 72);
			this.server.Name = "server";
			this.server.Size = new System.Drawing.Size(192, 20);
			this.server.TabIndex = 4;
			this.server.Text = "";
			// 
			// regex
			// 
			this.regex.Location = new System.Drawing.Point(80, 40);
			this.regex.Name = "regex";
			this.regex.Size = new System.Drawing.Size(192, 20);
			this.regex.TabIndex = 3;
			this.regex.Text = "";
			// 
			// folder
			// 
			this.folder.Location = new System.Drawing.Point(80, 8);
			this.folder.Name = "folder";
			this.folder.Size = new System.Drawing.Size(192, 20);
			this.folder.TabIndex = 1;
			this.folder.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Folder:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Regex:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Server:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "User:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 12;
			this.label5.Text = "Password:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 13;
			this.label6.Text = "Interval:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(120, 168);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "minutes";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// browse
			// 
			this.browse.Location = new System.Drawing.Point(288, 8);
			this.browse.Name = "browse";
			this.browse.TabIndex = 2;
			this.browse.Text = "Browse...";
			this.browse.Click += new System.EventHandler(this.browse_Click);
			// 
			// port
			// 
			this.port.Location = new System.Drawing.Point(288, 72);
			this.port.MaxLength = 4;
			this.port.Name = "port";
			this.port.Size = new System.Drawing.Size(36, 20);
			this.port.TabIndex = 5;
			this.port.Text = "";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(276, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(8, 23);
			this.label8.TabIndex = 17;
			this.label8.Text = ":";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Properties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 198);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.port);
			this.Controls.Add(this.browse);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.regex);
			this.Controls.Add(this.server);
			this.Controls.Add(this.user);
			this.Controls.Add(this.interval);
			this.Controls.Add(this.password);
			this.Controls.Add(this.folder);
			this.Controls.Add(this.save);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Properties";
			this.Text = "bakkappah properties";
			this.ResumeLayout(false);

		}
		#endregion

		private void browse_Click(object sender, System.EventArgs e)
		{
			folderBrowserDialog1.ShowDialog();
			folder.Text = folderBrowserDialog1.SelectedPath;
		}

		private bool firstTimeInit()
		{
			if (Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config") == null) 
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\KdK\\bakkappah\\config");
				key.SetValue("folder", "C:\\");
				key.SetValue("regex", ".");
				key.SetValue("server", "localhost");
				key.SetValue("user", "anonymous");
				key.SetValue("password", "none@none.no");
				key.SetValue("interval", 15);
				return true;
			}
			return false;
		}

		private void loadData(object sender, EventArgs e)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config");
			this.folder.Text = (string)key.GetValue("folder");
			this.regex.Text = (string)key.GetValue("regex");
			this.server.Text = (string)key.GetValue("server");
			this.user.Text = (string)key.GetValue("user");
			this.password.Text = (string)key.GetValue("password");
			this.interval.Text = ((int)key.GetValue("interval")).ToString();
			this.port.Text = ((int)key.GetValue("port")).ToString();
		}

		private void saveData()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config", true);
			key.SetValue("folder", this.folder.Text);
			key.SetValue("regex", this.regex.Text);
			key.SetValue("server", this.server.Text);
			key.SetValue("user", this.user.Text);
			key.SetValue("password", this.password.Text);
			key.SetValue("interval", Int32.Parse(this.interval.Text));
			key.SetValue("port", Int32.Parse(this.port.Text));
		}

		private void save_Click(object sender, System.EventArgs e)
		{
			try 
			{
				saveData();
				this.Hide();
			} 
			catch
			{
				MessageBox.Show("Interval and port must be numerical", "bakkappah");
			}
		}

		public int Interval 
		{
			get 
			{
				return (int)Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config").GetValue("interval");
			}
		}

		public int Port
		{
			get
			{
				return (int)Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config").GetValue("port");
			}
		}

		public string Folder
		{
			get
			{
				return (string)Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config").GetValue("folder");
			}
		}

		public string Regex
		{
			get
			{
				return (string)Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config").GetValue("regex");
			}
		}

		public string Server
		{
			get
			{
				return (string)Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config").GetValue("server");
			}
		}

		public string User
		{
			get
			{
				return (string)Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config").GetValue("user");
			}
		}

		public string Password
		{
			get
			{
				return (string)Registry.CurrentUser.OpenSubKey("Software\\KdK\\bakkappah\\config").GetValue("password");
			}
		}

		public void Show(string msg) 
		{
			this.Show();
			MessageBox.Show(msg, "bakkappah");
		}
	}
}
