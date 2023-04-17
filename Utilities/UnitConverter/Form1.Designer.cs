namespace UnitConverter
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
            label1 = new Label();
            txtAmount = new TextBox();
            panel1 = new Panel();
            label2 = new Label();
            cmbType = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            lstFrom = new ListBox();
            lstTo = new ListBox();
            btnConvert = new Button();
            label5 = new Label();
            txtConvertedAmount = new TextBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 20);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(85, 17);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtAmount);
            panel1.Location = new Point(97, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 56);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 118);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "Type";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(86, 115);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(277, 23);
            cmbType.TabIndex = 4;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 179);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "From:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(266, 179);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 6;
            label4.Text = "To:";
            // 
            // lstFrom
            // 
            lstFrom.FormattingEnabled = true;
            lstFrom.ItemHeight = 15;
            lstFrom.Location = new Point(39, 216);
            lstFrom.Name = "lstFrom";
            lstFrom.Size = new Size(122, 124);
            lstFrom.TabIndex = 7;
            // 
            // lstTo
            // 
            lstTo.FormattingEnabled = true;
            lstTo.ItemHeight = 15;
            lstTo.Location = new Point(266, 216);
            lstTo.Name = "lstTo";
            lstTo.Size = new Size(118, 124);
            lstTo.TabIndex = 8;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(182, 360);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(75, 23);
            btnConvert.TabIndex = 9;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 20);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 0;
            label5.Text = "Converted Amount";
            // 
            // txtConvertedAmount
            // 
            txtConvertedAmount.Location = new Point(143, 17);
            txtConvertedAmount.Name = "txtConvertedAmount";
            txtConvertedAmount.Size = new Size(181, 23);
            txtConvertedAmount.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtConvertedAmount);
            panel2.Location = new Point(39, 402);
            panel2.Name = "panel2";
            panel2.Size = new Size(345, 56);
            panel2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 493);
            Controls.Add(panel2);
            Controls.Add(btnConvert);
            Controls.Add(lstTo);
            Controls.Add(lstFrom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbType);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "UnitConverter";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAmount;
        private Panel panel1;
        private Label label2;
        private ComboBox cmbType;
        private Label label3;
        private Label label4;
        private ListBox lstFrom;
        private ListBox lstTo;
        private Button btnConvert;
        private Label label5;
        private TextBox txtConvertedAmount;
        private Panel panel2;
    }
}