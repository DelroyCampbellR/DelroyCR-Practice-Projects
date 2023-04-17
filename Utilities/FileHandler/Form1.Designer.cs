namespace FileHandler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboSystemDriver = new ComboBox();
            txtSystemDetails = new TextBox();
            label1 = new Label();
            txtNewDirectory = new TextBox();
            btnCreateDirectory = new Button();
            txtNewSubdirectory = new TextBox();
            label2 = new Label();
            btnCreateSubdirectory = new Button();
            label3 = new Label();
            cboDirectoryFiles = new ComboBox();
            btnShowDirectoryFiles = new Button();
            panel1 = new Panel();
            label6 = new Label();
            txtCopyDirectoryDestination = new TextBox();
            txtCopyDirectorySource = new TextBox();
            label5 = new Label();
            label4 = new Label();
            btnCopyDirectory = new Button();
            btnNewFile = new Button();
            txtNewFile = new TextBox();
            label7 = new Label();
            btnOpenFile = new Button();
            txtSelectedFile = new TextBox();
            lbSelectFile = new Label();
            openFileDialog1 = new OpenFileDialog();
            btnRenameFile = new Button();
            txtRenameFile = new TextBox();
            label8 = new Label();
            toolStrip1 = new ToolStrip();
            txtWrite = new TextBox();
            label9 = new Label();
            btnWrite = new Button();
            btnRead = new Button();
            label10 = new Label();
            txtRead = new TextBox();
            btnFind = new Button();
            label11 = new Label();
            txtFind = new TextBox();
            btnUpdate = new Button();
            label12 = new Label();
            txtUpdate = new TextBox();
            label13 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cboSystemDriver
            // 
            cboSystemDriver.FormattingEnabled = true;
            cboSystemDriver.Location = new Point(13, 47);
            cboSystemDriver.Name = "cboSystemDriver";
            cboSystemDriver.Size = new Size(50, 23);
            cboSystemDriver.TabIndex = 0;
            cboSystemDriver.SelectedIndexChanged += cboSystemDriver_SelectedIndexChanged;
            // 
            // txtSystemDetails
            // 
            txtSystemDetails.Location = new Point(13, 90);
            txtSystemDetails.Multiline = true;
            txtSystemDetails.Name = "txtSystemDetails";
            txtSystemDetails.Size = new Size(306, 224);
            txtSystemDetails.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(340, 47);
            label1.Name = "label1";
            label1.Size = new Size(168, 15);
            label1.TabIndex = 2;
            label1.Text = "New Directory (include path)";
            // 
            // txtNewDirectory
            // 
            txtNewDirectory.Location = new Point(514, 44);
            txtNewDirectory.Name = "txtNewDirectory";
            txtNewDirectory.Size = new Size(193, 23);
            txtNewDirectory.TabIndex = 3;
            // 
            // btnCreateDirectory
            // 
            btnCreateDirectory.Location = new Point(713, 31);
            btnCreateDirectory.Name = "btnCreateDirectory";
            btnCreateDirectory.Size = new Size(75, 46);
            btnCreateDirectory.TabIndex = 4;
            btnCreateDirectory.Text = "Create Directory";
            btnCreateDirectory.UseVisualStyleBackColor = true;
            btnCreateDirectory.Click += btnCreateDirectory_Click;
            // 
            // txtNewSubdirectory
            // 
            txtNewSubdirectory.Location = new Point(514, 101);
            txtNewSubdirectory.Name = "txtNewSubdirectory";
            txtNewSubdirectory.Size = new Size(193, 23);
            txtNewSubdirectory.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(340, 101);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 7;
            label2.Text = "New Subdirectory";
            // 
            // btnCreateSubdirectory
            // 
            btnCreateSubdirectory.Location = new Point(713, 83);
            btnCreateSubdirectory.Name = "btnCreateSubdirectory";
            btnCreateSubdirectory.Size = new Size(86, 46);
            btnCreateSubdirectory.TabIndex = 8;
            btnCreateSubdirectory.Text = "Create Subdirectory";
            btnCreateSubdirectory.UseVisualStyleBackColor = true;
            btnCreateSubdirectory.Click += btnCreateSubdirectory_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(340, 153);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 9;
            label3.Text = "Show Directory Details";
            // 
            // cboDirectoryFiles
            // 
            cboDirectoryFiles.FormattingEnabled = true;
            cboDirectoryFiles.Location = new Point(514, 150);
            cboDirectoryFiles.Name = "cboDirectoryFiles";
            cboDirectoryFiles.Size = new Size(121, 23);
            cboDirectoryFiles.TabIndex = 10;
            // 
            // btnShowDirectoryFiles
            // 
            btnShowDirectoryFiles.Location = new Point(713, 150);
            btnShowDirectoryFiles.Name = "btnShowDirectoryFiles";
            btnShowDirectoryFiles.Size = new Size(99, 46);
            btnShowDirectoryFiles.TabIndex = 11;
            btnShowDirectoryFiles.Text = "Show Directory Files";
            btnShowDirectoryFiles.UseVisualStyleBackColor = true;
            btnShowDirectoryFiles.Click += btnShowDirectoryFiles_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtCopyDirectoryDestination);
            panel1.Controls.Add(txtCopyDirectorySource);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(340, 214);
            panel1.Name = "panel1";
            panel1.Size = new Size(411, 100);
            panel1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(10, 69);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 18;
            label6.Text = "Destination";
            // 
            // txtCopyDirectoryDestination
            // 
            txtCopyDirectoryDestination.Location = new Point(184, 66);
            txtCopyDirectoryDestination.Name = "txtCopyDirectoryDestination";
            txtCopyDirectoryDestination.Size = new Size(193, 23);
            txtCopyDirectoryDestination.TabIndex = 17;
            // 
            // txtCopyDirectorySource
            // 
            txtCopyDirectorySource.Location = new Point(184, 41);
            txtCopyDirectorySource.Name = "txtCopyDirectorySource";
            txtCopyDirectorySource.Size = new Size(193, 23);
            txtCopyDirectorySource.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(10, 44);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 14;
            label5.Text = "Source";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(8, 9);
            label4.Name = "label4";
            label4.Size = new Size(127, 21);
            label4.TabIndex = 13;
            label4.Text = "Copy Directory";
            // 
            // btnCopyDirectory
            // 
            btnCopyDirectory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCopyDirectory.Location = new Point(772, 214);
            btnCopyDirectory.Name = "btnCopyDirectory";
            btnCopyDirectory.Size = new Size(132, 100);
            btnCopyDirectory.TabIndex = 13;
            btnCopyDirectory.Text = "Copy";
            btnCopyDirectory.UseVisualStyleBackColor = true;
            btnCopyDirectory.Click += btnCopyDirectory_Click;
            // 
            // btnNewFile
            // 
            btnNewFile.Location = new Point(713, 327);
            btnNewFile.Name = "btnNewFile";
            btnNewFile.Size = new Size(75, 46);
            btnNewFile.TabIndex = 16;
            btnNewFile.Text = "Create File";
            btnNewFile.UseVisualStyleBackColor = true;
            btnNewFile.Click += btnNewFile_Click;
            // 
            // txtNewFile
            // 
            txtNewFile.Location = new Point(514, 340);
            txtNewFile.Name = "txtNewFile";
            txtNewFile.Size = new Size(193, 23);
            txtNewFile.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(340, 343);
            label7.Name = "label7";
            label7.Size = new Size(134, 15);
            label7.TabIndex = 14;
            label7.Text = "New File (include path)";
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(295, 388);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(75, 46);
            btnOpenFile.TabIndex = 19;
            btnOpenFile.Text = "Open";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // txtSelectedFile
            // 
            txtSelectedFile.Location = new Point(82, 401);
            txtSelectedFile.Name = "txtSelectedFile";
            txtSelectedFile.Size = new Size(193, 23);
            txtSelectedFile.TabIndex = 18;
            // 
            // lbSelectFile
            // 
            lbSelectFile.AutoSize = true;
            lbSelectFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbSelectFile.Location = new Point(12, 405);
            lbSelectFile.Name = "lbSelectFile";
            lbSelectFile.Size = new Size(64, 15);
            lbSelectFile.TabIndex = 17;
            lbSelectFile.Text = "Select File";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnRenameFile
            // 
            btnRenameFile.Location = new Point(295, 447);
            btnRenameFile.Name = "btnRenameFile";
            btnRenameFile.Size = new Size(75, 46);
            btnRenameFile.TabIndex = 22;
            btnRenameFile.Text = "Rename";
            btnRenameFile.UseVisualStyleBackColor = true;
            btnRenameFile.Click += btnRenameFile_Click;
            // 
            // txtRenameFile
            // 
            txtRenameFile.Location = new Point(82, 460);
            txtRenameFile.Name = "txtRenameFile";
            txtRenameFile.Size = new Size(193, 23);
            txtRenameFile.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(12, 465);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 20;
            label8.Text = "Rename";
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1101, 25);
            toolStrip1.TabIndex = 23;
            toolStrip1.Text = "toolStrip1";
            // 
            // txtWrite
            // 
            txtWrite.Location = new Point(83, 543);
            txtWrite.Multiline = true;
            txtWrite.Name = "txtWrite";
            txtWrite.Size = new Size(138, 83);
            txtWrite.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(130, 515);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 25;
            label9.Text = "Write";
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(117, 632);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(77, 31);
            btnWrite.TabIndex = 26;
            btnWrite.Text = "Write";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(292, 632);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(77, 31);
            btnRead.TabIndex = 29;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(315, 515);
            label10.Name = "label10";
            label10.Size = new Size(35, 15);
            label10.TabIndex = 28;
            label10.Text = "Read";
            label10.Click += label10_Click;
            // 
            // txtRead
            // 
            txtRead.Location = new Point(258, 543);
            txtRead.Multiline = true;
            txtRead.Name = "txtRead";
            txtRead.Size = new Size(138, 83);
            txtRead.TabIndex = 27;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(463, 632);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(77, 31);
            btnFind.TabIndex = 32;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(478, 515);
            label11.Name = "label11";
            label11.Size = new Size(30, 15);
            label11.TabIndex = 31;
            label11.Text = "Find";
            // 
            // txtFind
            // 
            txtFind.Location = new Point(429, 543);
            txtFind.Multiline = true;
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(138, 83);
            txtFind.TabIndex = 30;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(635, 632);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(77, 31);
            btnUpdate.TabIndex = 35;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(650, 515);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 34;
            label12.Text = "Update";
            // 
            // txtUpdate
            // 
            txtUpdate.Location = new Point(601, 543);
            txtUpdate.Multiline = true;
            txtUpdate.Name = "txtUpdate";
            txtUpdate.Size = new Size(138, 83);
            txtUpdate.TabIndex = 33;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(13, 25);
            label13.Name = "label13";
            label13.Size = new Size(62, 15);
            label13.TabIndex = 36;
            label13.Text = "Disks Info";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 714);
            Controls.Add(label13);
            Controls.Add(btnUpdate);
            Controls.Add(label12);
            Controls.Add(txtUpdate);
            Controls.Add(btnFind);
            Controls.Add(label11);
            Controls.Add(txtFind);
            Controls.Add(btnRead);
            Controls.Add(label10);
            Controls.Add(txtRead);
            Controls.Add(btnWrite);
            Controls.Add(label9);
            Controls.Add(txtWrite);
            Controls.Add(toolStrip1);
            Controls.Add(btnRenameFile);
            Controls.Add(txtRenameFile);
            Controls.Add(label8);
            Controls.Add(btnOpenFile);
            Controls.Add(txtSelectedFile);
            Controls.Add(lbSelectFile);
            Controls.Add(btnNewFile);
            Controls.Add(txtNewFile);
            Controls.Add(label7);
            Controls.Add(btnCopyDirectory);
            Controls.Add(panel1);
            Controls.Add(btnShowDirectoryFiles);
            Controls.Add(cboDirectoryFiles);
            Controls.Add(label3);
            Controls.Add(btnCreateSubdirectory);
            Controls.Add(label2);
            Controls.Add(txtNewSubdirectory);
            Controls.Add(btnCreateDirectory);
            Controls.Add(txtNewDirectory);
            Controls.Add(label1);
            Controls.Add(txtSystemDetails);
            Controls.Add(cboSystemDriver);
            Name = "Form1";
            Text = "File Handler";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboSystemDriver;
        private TextBox txtSystemDetails;
        private Label label1;
        private TextBox txtNewDirectory;
        private Button btnCreateDirectory;
        private TextBox txtNewSubdirectory;
        private Label label2;
        private Button btnCreateSubdirectory;
        private Label label3;
        private ComboBox cboDirectoryFiles;
        private Button btnShowDirectoryFiles;
        private Panel panel1;
        private TextBox txtCopyDirectoryDestination;
        private TextBox txtCopyDirectorySource;
        private Label label5;
        private Label label4;
        private Label label6;
        private Button btnCopyDirectory;
        private Button btnNewFile;
        private TextBox txtNewFile;
        private Label label7;
        private Button btnOpenFile;
        private TextBox txtSelectedFile;
        private Label lbSelectFile;
        private OpenFileDialog openFileDialog1;
        private Button btnRenameFile;
        private TextBox txtRenameFile;
        private Label label8;
        private ToolStrip toolStrip1;
        private TextBox txtWrite;
        private Label label9;
        private Button btnWrite;
        private Button btnRead;
        private Label label10;
        private TextBox txtRead;
        private Button btnFind;
        private Label label11;
        private TextBox txtFind;
        private Button btnUpdate;
        private Label label12;
        private TextBox txtUpdate;
        private Label label13;
    }
}