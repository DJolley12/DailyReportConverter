namespace DailyReportConverter
{
    partial class MainWindow
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
            this.openButton = new System.Windows.Forms.Button();
            this.dataGridViewResultDisplay = new System.Windows.Forms.DataGridView();
            this.configMenuButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Location = new System.Drawing.Point(12, 362);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(95, 32);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // dataGridViewResultDisplay
            // 
            this.dataGridViewResultDisplay.AllowUserToAddRows = false;
            this.dataGridViewResultDisplay.AllowUserToDeleteRows = false;
            this.dataGridViewResultDisplay.AllowUserToOrderColumns = true;
            this.dataGridViewResultDisplay.AllowUserToResizeColumns = false;
            this.dataGridViewResultDisplay.AllowUserToResizeRows = false;
            this.dataGridViewResultDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewResultDisplay.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewResultDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultDisplay.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewResultDisplay.Name = "dataGridViewResultDisplay";
            this.dataGridViewResultDisplay.Size = new System.Drawing.Size(684, 344);
            this.dataGridViewResultDisplay.TabIndex = 2;
            // 
            // configMenuButton
            // 
            this.configMenuButton.Location = new System.Drawing.Point(621, 385);
            this.configMenuButton.Name = "configMenuButton";
            this.configMenuButton.Size = new System.Drawing.Size(75, 23);
            this.configMenuButton.TabIndex = 3;
            this.configMenuButton.Text = "config>>";
            this.configMenuButton.UseVisualStyleBackColor = true;
            this.configMenuButton.Click += new System.EventHandler(this.configMenuButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 47);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(319, 23);
            this.progressBar1.Step = 15;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(12, 400);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 32);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saving...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(113, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 74);
            this.panel1.TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(708, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.configMenuButton);
            this.Controls.Add(this.dataGridViewResultDisplay);
            this.Controls.Add(this.openButton);
            this.Name = "MainWindow";
            this.Text = "Daily Report Converter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultDisplay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.DataGridView dataGridViewResultDisplay;
        private System.Windows.Forms.Button configMenuButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

