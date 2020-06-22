using System;
using System.IO;
using System.Windows.Forms;

namespace Desk_Cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string watchpath = @"C:\Users\User\Downloads";
                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = watchpath
                };
                watcher.Changed += Watcher_Changed;
                watcher.Created += Watcher_Created;
                watcher.Renamed += Watcher_Renamed;

                watcher.EnableRaisingEvents = true;
                //while (btnStart.Enabled) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string watchpath = @"C:\Users\User\Downloads";
            string destination_path = @"C:\Users\User\Desktop\folder1";

            EventHandler.On_modified(watchpath, destination_path);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string watchpath = @"C:\Users\User\Downloads";
            string destination_path = @"C:\Users\User\Desktop\folder1";

            EventHandler.On_modified(watchpath, destination_path);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string watchpath = @"C:\Users\User\Downloads";
            string destination_path = @"C:\Users\User\Desktop\folder1";

            EventHandler.On_modified(watchpath, destination_path);
        }
    }
}