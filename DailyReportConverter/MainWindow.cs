using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DailyReportConverter.Classes;
using DailyReportConverter.Properties;

namespace DailyReportConverter
{
    public partial class MainWindow : Form
    {
        ViewModel viewModel = new ViewModel();
        string path = "";
        private static bool isConfigured { get; set; }
        private static string[] data { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            panel1.Hide();
            //viewModel = new ViewModel(isConfigured);
            viewModel.CheckConfigStatusWithoutDirectoryWatcher();
            viewModel.RunMainWindowOrConfig();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            data = viewModel.OpenFile();
        }

        private void configMenuButton_Click(object sender, EventArgs e)
        {
            viewModel.BackToConfig();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            panel1.Show();
            progressBar1.PerformStep();
            viewModel.ParseFileToFlightList(data);
            progressBar1.PerformStep();
            viewModel.AssignPath(path);
            progressBar1.PerformStep();
            viewModel.FlightListToBaseTotalList();
            progressBar1.PerformStep();
            viewModel.WriteToExcelTemplate();
            progressBar1.PerformStep();
            label1.Text = "Writing data to excel file...";
            dataGridViewResultDisplay.DataSource = viewModel.ReturnFormattedTable(dataGridViewResultDisplay);
            progressBar1.PerformStep();
            panel1.Hide();
            Process.Start(Settings.Default["TemplateFilePath"].ToString());
        }
    }
}
