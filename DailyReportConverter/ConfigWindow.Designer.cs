namespace DailyReportConverter.Classes
{
    partial class ConfigWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.templateFileAddressTextBox = new System.Windows.Forms.TextBox();
            this.saveTemplateFileAddress = new System.Windows.Forms.Button();
            this.templateAddressLabel = new System.Windows.Forms.Label();
            this.browseTemplateFileAddressButton = new System.Windows.Forms.Button();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.saveDirectoryButton = new System.Windows.Forms.Button();
            this.browseDirectoryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // templateFileAddressTextBox
            // 
            this.templateFileAddressTextBox.Location = new System.Drawing.Point(93, 25);
            this.templateFileAddressTextBox.Name = "templateFileAddressTextBox";
            this.templateFileAddressTextBox.Size = new System.Drawing.Size(213, 20);
            this.templateFileAddressTextBox.TabIndex = 1;
            // 
            // saveTemplateFileAddress
            // 
            this.saveTemplateFileAddress.Location = new System.Drawing.Point(12, 22);
            this.saveTemplateFileAddress.Name = "saveTemplateFileAddress";
            this.saveTemplateFileAddress.Size = new System.Drawing.Size(75, 23);
            this.saveTemplateFileAddress.TabIndex = 2;
            this.saveTemplateFileAddress.Text = "Save";
            this.saveTemplateFileAddress.UseVisualStyleBackColor = true;
            this.saveTemplateFileAddress.Click += new System.EventHandler(this.saveTemplateFileAddress_Click);
            // 
            // templateAddressLabel
            // 
            this.templateAddressLabel.AutoSize = true;
            this.templateAddressLabel.Location = new System.Drawing.Point(90, 9);
            this.templateAddressLabel.Name = "templateAddressLabel";
            this.templateAddressLabel.Size = new System.Drawing.Size(208, 13);
            this.templateAddressLabel.TabIndex = 3;
            this.templateAddressLabel.Text = "Template Address-Select a file to write to...";
            // 
            // browseTemplateFileAddressButton
            // 
            this.browseTemplateFileAddressButton.Location = new System.Drawing.Point(12, 51);
            this.browseTemplateFileAddressButton.Name = "browseTemplateFileAddressButton";
            this.browseTemplateFileAddressButton.Size = new System.Drawing.Size(75, 23);
            this.browseTemplateFileAddressButton.TabIndex = 0;
            this.browseTemplateFileAddressButton.Text = "Browse";
            this.browseTemplateFileAddressButton.UseVisualStyleBackColor = true;
            this.browseTemplateFileAddressButton.Click += new System.EventHandler(this.browseTemplateFileAddressButton_Click);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(93, 114);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(213, 20);
            this.directoryTextBox.TabIndex = 4;
            // 
            // saveDirectoryButton
            // 
            this.saveDirectoryButton.Location = new System.Drawing.Point(12, 111);
            this.saveDirectoryButton.Name = "saveDirectoryButton";
            this.saveDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.saveDirectoryButton.TabIndex = 5;
            this.saveDirectoryButton.Text = "Save";
            this.saveDirectoryButton.UseVisualStyleBackColor = true;
            this.saveDirectoryButton.Click += new System.EventHandler(this.saveDirectoryButton_Click);
            // 
            // browseDirectoryButton
            // 
            this.browseDirectoryButton.Location = new System.Drawing.Point(12, 140);
            this.browseDirectoryButton.Name = "browseDirectoryButton";
            this.browseDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.browseDirectoryButton.TabIndex = 6;
            this.browseDirectoryButton.Text = "Browse";
            this.browseDirectoryButton.UseVisualStyleBackColor = true;
            this.browseDirectoryButton.Click += new System.EventHandler(this.browseDirectoryButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter a file directory to watch...";
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseDirectoryButton);
            this.Controls.Add(this.saveDirectoryButton);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.templateAddressLabel);
            this.Controls.Add(this.saveTemplateFileAddress);
            this.Controls.Add(this.templateFileAddressTextBox);
            this.Controls.Add(this.browseTemplateFileAddressButton);
            this.Name = "ConfigWindow";
            this.Text = "Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox templateFileAddressTextBox;
        private System.Windows.Forms.Button saveTemplateFileAddress;
        private System.Windows.Forms.Label templateAddressLabel;
        private System.Windows.Forms.Button browseTemplateFileAddressButton;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Button saveDirectoryButton;
        private System.Windows.Forms.Button browseDirectoryButton;
        private System.Windows.Forms.Label label1;
    }
}