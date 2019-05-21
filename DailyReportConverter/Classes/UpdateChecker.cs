using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyReportConverter.Classes
{
    public class UpdateChecker
    {
        ViewModel viewModel = new ViewModel();
        FileSystemWatcher FileWatcher = new FileSystemWatcher();
        public string FilePath { get; set; }
        private static string[] data { get; set; }

        public UpdateChecker(string path)
        {
            FileWatcher.Path = path;
            FileWatcher.NotifyFilter = NotifyFilters.CreationTime;
            FileWatcher.Filter = "*.csv";
            FileWatcher.Created += new FileSystemEventHandler(OnCreated);
            FileWatcher.EnableRaisingEvents = true;
            FileWatcher.BeginInit();
        }

        public void WatchDirectory()
        { 
            FileWatcher.Created += new FileSystemEventHandler(OnCreated);
        }

        public void OnCreated(object sender, FileSystemEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Do you want to use {e.Name} to generate a Daily Report?", "Saved File Found", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FileWatcher.EnableRaisingEvents = false;
                FileWatcher.EndInit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
