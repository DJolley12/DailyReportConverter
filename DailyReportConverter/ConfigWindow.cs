using System;
using System.Windows.Forms;

namespace DailyReportConverter.Classes
{
    public partial class ConfigWindow : Form
    {
        ViewModel viewModel = new ViewModel();

        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void saveTemplateFileAddress_Click(object sender, EventArgs e)
        {
            viewModel.ExcelTemplatePath = templateFileAddressTextBox.Text;
            viewModel.SaveFilePathWithoutDirectoryWatcher();
        }

        private void browseTemplateFileAddressButton_Click(object sender, EventArgs e)
        {
            viewModel.BrowseFilePath();
            templateFileAddressTextBox.Text = viewModel.ExcelTemplatePath;
        }

        private void saveDirectoryButton_Click(object sender, EventArgs e)
        {
            viewModel.DirectoryToWatchPath = directoryTextBox.Text;
            viewModel.SaveDirectoryPath();
        }

        private void browseDirectoryButton_Click(object sender, EventArgs e)
        {
            viewModel.BrowseDirectoryPath();
            directoryTextBox.Text = viewModel.DirectoryToWatchPath;
        }
    }
}
