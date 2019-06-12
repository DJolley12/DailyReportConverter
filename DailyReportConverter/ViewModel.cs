using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DailyReportConverter.Classes;
using DailyReportConverter.Properties;

namespace DailyReportConverter
{
    public class ViewModel
    {
        private static CSVParser csvParser = new CSVParser();
        private static CSVReturn csvReturn = new CSVReturn();
        private static List<Flight> flights { get; set; }
        public static List<IncompleteFlight> IncompleteFlights = new List<IncompleteFlight>();
        private static List<BaseTotal> baseTotals { get; set; }
        private StreamReader streamReader { get; set; }
        private string[] data { get; set; }
        private static DataGridView dataGridView { get; set; }
        public string ExcelTemplatePath { get; set; }
        public string DirectoryToWatchPath { get; set; }

        public bool TemplateIsConfigured { get; set; }
        public bool DirectoryToWatchIsConfigured { get; set; }
        public static MainWindow MainWindowForm;
        public static ConfigWindow MyConfig;

        public ViewModel()
        {

        }

        public ViewModel(bool isConfigured)
        {
            CheckConfigStatus();
            RunMainWindowOrConfig();
        }

        public void CheckConfigStatus()
        {
            if (File.Exists(Settings.Default["TemplateFilePath"].ToString()) 
                && Directory.Exists(Settings.Default["CSVWatchPath"].ToString()))
            {
                TemplateIsConfigured = true;
                DirectoryToWatchIsConfigured = true;
            }
            else
            {
                TemplateIsConfigured = false;
                DirectoryToWatchIsConfigured = false;
            }
        }

        public void CheckConfigStatusWithoutDirectoryWatcher()
        {
            if (File.Exists(Settings.Default["TemplateFilePath"].ToString()))
            {
                TemplateIsConfigured = true;
            }
            else
            {
                TemplateIsConfigured = false;
            }
        }

        public void RunMainWindowOrConfig()
        {
            if (!TemplateIsConfigured == false)
                return;

            RunConfigWindow();
        }

        public void RunMainWindow()
        {
            MainWindowForm = new MainWindow();
            Application.Run(MainWindowForm);
        }

        public void RunConfigWindow()
        {
            MyConfig = new ConfigWindow();
            Application.Run(MyConfig);
        }

        public void BackToConfig()
        {
            MyConfig = new ConfigWindow();
            MyConfig.Show();
        }

        public void AssignPath(string path)
        {
            csvReturn.Path = path;
        }

        public string[] OpenFileFromUpdateChecker(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                data = csvParser.SplitData(streamReader.ReadToEnd());
            }
            return data;
        }

        public string[] OpenFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV files|*.csv", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.CheckFileExists)
                    {
                        streamReader = new StreamReader(ofd.FileName);
                        data = csvParser.SplitData(streamReader.ReadToEnd());
                    }
                    else
                    {
                        MessageBox.Show(new Exception("File " + ofd.FileName + "path does not exist, ya dingus!").ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return data;
            }
        }

        public string[] OpenFileWithRegularExpressionsParser()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV files|*.csv", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.CheckFileExists)
                    {
                        streamReader = new StreamReader(ofd.FileName);
                        data = csvParser.ParseWithRegularExpressions(streamReader.ReadToEnd());
                    }
                    else
                    {
                        MessageBox.Show(new Exception("File " + ofd.FileName + "path does not exist, ya dingus!").ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return data;
            }
        }

        public string[] OpenFileWithRegularExpressionsParserByLine()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV files|*.csv", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.CheckFileExists)
                    {
                        streamReader = new StreamReader(ofd.FileName);
                        data = csvParser.ParseWithRegularExpressionsByLine(streamReader.ReadToEnd());
                    }
                    else
                    {
                        MessageBox.Show(new Exception("File " + ofd.FileName + "path does not exist, ya dingus!").ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return data;
            }
        }

        public void BrowseFilePath()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.CheckFileExists)
                    { 
                        ExcelTemplatePath = ofd.FileName;
                    }
                    else
                    {
                        MessageBox.Show(new Exception("File " + ofd.FileName + "path does not exist, ya dingus!").ToString(), "Oops",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void BrowseDirectoryPath()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.CheckPathExists)
                    {
                        DirectoryToWatchPath = ofd.FileName;
                    }
                    else
                    {
                        MessageBox.Show(new Exception("Directory path " + ofd.FileName + " does not exist, ya dingus!").ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void SaveFilePath()
        {
            if (File.Exists(ExcelTemplatePath))
            {
                Settings.Default["TemplateFilePath"] = ExcelTemplatePath;
                Settings.Default.Save();
                TemplateIsConfigured = true;
                if (TemplateIsConfigured == true && DirectoryToWatchIsConfigured == true)
                {
                    MyConfig.Close();
                }
            }
            else
            {
                MessageBox.Show(new Exception("File " + ExcelTemplatePath + "path does not exist, ya dingus!").ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveFilePathWithoutDirectoryWatcher()
        {
            if (File.Exists(ExcelTemplatePath))
            {
                Settings.Default["TemplateFilePath"] = ExcelTemplatePath;
                Settings.Default.Save();
                TemplateIsConfigured = true;
                if (TemplateIsConfigured == true)
                {
                    MyConfig.Close();
                }
            }
            else
            {
                MessageBox.Show(new Exception("File " + ExcelTemplatePath + "path does not exist, ya dingus!").ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveDirectoryPath()
        {
            if (Directory.Exists(DirectoryToWatchPath))
            {
                Settings.Default["CSVWatchPath"] = DirectoryToWatchPath;
                Settings.Default.Save();
                DirectoryToWatchIsConfigured = true;
                if (TemplateIsConfigured == true && DirectoryToWatchIsConfigured == true)
                {
                    MyConfig.Close();
                }
            }
        }

        public void OpenCreatedFile()
        {
            csvReturn.OpenFile();
        }

        public void ParseToFlightList(string[] dataArr)
        {
            flights = csvParser.ParseDataToFlightList(dataArr);
        }

        public void ParseToFlightListByLine(string[] dataArr)
        {
            flights = csvParser.ParseDataToFlightListByLine(dataArr);
        }

        public void CheckIncompleteFlights()
        {
            if (IncompleteFlights.Count != 0)
            {
                string flightNumbers = "";
                foreach (var incompleteFlight in IncompleteFlights)
                {
                    flightNumbers += "\n" + incompleteFlight.FlightNumber;
                }
                MessageBox.Show(new Exception("The following flights do not have bases associated with them: " + flightNumbers).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FlightListToBaseTotalList()
        {
            baseTotals = csvReturn.GetBaseTotalsList(flights);
        }

        public void WriteToExcelTemplateWithFlightList()
        {
            ExcelWriter.WriteToExcelTemplate(flights);
        }

        public void WriteToExcelTemplate()
        {
            ExcelWriter.WriteToExcelTemplate(baseTotals);
        }

        public void CreateFile()
        {
            string csvString = csvReturn.FormatToCSV(baseTotals);
            csvReturn.WriteCSVFile(csvString);
        }

        public Object ReturnFormattedTable(DataGridView dGridView)
        {
            dataGridView = dGridView;
            dataGridView.DataSource = baseTotals;

            return dataGridView.DataSource;
        }

        public Object GenerateTable(DataGridView dGridView)
        {
            //Generates table template automatically

            dataGridView = dGridView;

            dataGridView.ColumnCount = 13;

            dataGridView.Columns[1].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Page);
            dataGridView.Columns[1].DataPropertyName = "ViewModel.Page";
            dataGridView.Columns[2].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Vernal);
            dataGridView.Columns[2].DataPropertyName = "ViewModel.Vernal";
            dataGridView.Columns[3].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Lander);
            dataGridView.Columns[3].DataPropertyName = "ViewModel.Lander";
            dataGridView.Columns[4].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Riverton);
            dataGridView.Columns[4].DataPropertyName = "ViewModel.Riverton";
            dataGridView.Columns[5].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Moab);
            dataGridView.Columns[5].DataPropertyName = "ViewModel.Moab";
            dataGridView.Columns[6].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Steamboat);
            dataGridView.Columns[6].DataPropertyName = "ViewModel.Steamboat";
            dataGridView.Columns[7].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Rawlins);
            dataGridView.Columns[7].DataPropertyName = "ViewModel.Rawlins";
            dataGridView.Columns[8].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Craig);
            dataGridView.Columns[8].DataPropertyName = "ViewModel.Craig";
            dataGridView.Columns[9].Name = FlightPropertiesExtensions.GetBaseNameString(Base.LosAlamos);
            dataGridView.Columns[9].DataPropertyName = "ViewModel.LosAlamos";
            dataGridView.Columns[10].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Glenwood);
            dataGridView.Columns[10].DataPropertyName = "ViewModel.Glenwood";
            dataGridView.Columns[11].Name = FlightPropertiesExtensions.GetBaseNameString(Base.FortMohave);
            dataGridView.Columns[11].DataPropertyName = "ViewModel.FortMohave";
            dataGridView.Columns[12].Name = FlightPropertiesExtensions.GetBaseNameString(Base.Pocatello);
            dataGridView.Columns[12].DataPropertyName = "ViewModel.Pocatello";

            string[] valueArray =
            {
                FlightPropertiesExtensions.GetCallTypeString(CallType.RW),
                FlightPropertiesExtensions.GetCallTypeString(CallType.FW),
                FlightPropertiesExtensions.GetCallTypeString(CallType.Ground),
                FlightPropertiesExtensions.GetStatusTypeString(Status.Turndown),
                FlightPropertiesExtensions.GetStatusTypeString(Status.Missed),
                FlightPropertiesExtensions.GetStatusTypeString(Status.Cancel),
                FlightPropertiesExtensions.GetStatusTypeString(Status.SAR_NT_AT)
            };

            foreach (string value in valueArray)
            {
                dataGridView.Rows.Add(value);
            }

            return dataGridView;
        }
    }
}
