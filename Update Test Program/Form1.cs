using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Update_Test_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForUpdates();
            AddVersionNumber();
        }

        private async Task CheckForUpdates()
        {
            using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/hatcherj17/UpdateTestProgram"))
            {
                await mgr.Result.UpdateApp();
            }
        }

        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text += $" v.{versionInfo.FileVersion}";
            this.textBox1.Text = versionInfo.FileVersion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
