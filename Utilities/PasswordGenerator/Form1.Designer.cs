namespace PasswordGenerator
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
            txtNewPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPasswordLength = new TextBox();
            chkIncludeUppercase = new CheckBox();
            chkIncludeLowercase = new CheckBox();
            chkIncludeNumbers = new CheckBox();
            chkIncludeSymbols = new CheckBox();
            btnGeneratePassword = new Button();
            SuspendLayout();
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNewPassword.Location = new Point(55, 104);
            txtNewPassword.Multiline = true;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(418, 185);
            txtNewPassword.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(117, 47);
            label1.Name = "label1";
            label1.Size = new Size(280, 29);
            label1.TabIndex = 1;
            label1.Text = "Password Generator";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(145, 308);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 2;
            label2.Text = "Password Length";
            // 
            // txtPasswordLength
            // 
            txtPasswordLength.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPasswordLength.Location = new Point(306, 308);
            txtPasswordLength.Name = "txtPasswordLength";
            txtPasswordLength.Size = new Size(100, 27);
            txtPasswordLength.TabIndex = 3;
            txtPasswordLength.KeyPress += txtPasswordLength_KeyPress;
            // 
            // chkIncludeUppercase
            // 
            chkIncludeUppercase.AutoSize = true;
            chkIncludeUppercase.CheckAlign = ContentAlignment.MiddleRight;
            chkIncludeUppercase.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            chkIncludeUppercase.Location = new Point(145, 344);
            chkIncludeUppercase.Name = "chkIncludeUppercase";
            chkIncludeUppercase.Size = new Size(162, 24);
            chkIncludeUppercase.TabIndex = 4;
            chkIncludeUppercase.Text = "Include Uppercase   ";
            chkIncludeUppercase.UseVisualStyleBackColor = true;
            // 
            // chkIncludeLowercase
            // 
            chkIncludeLowercase.AutoSize = true;
            chkIncludeLowercase.CheckAlign = ContentAlignment.MiddleRight;
            chkIncludeLowercase.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            chkIncludeLowercase.Location = new Point(145, 374);
            chkIncludeLowercase.Name = "chkIncludeLowercase";
            chkIncludeLowercase.Size = new Size(161, 24);
            chkIncludeLowercase.TabIndex = 5;
            chkIncludeLowercase.Text = "Include Lowercase   ";
            chkIncludeLowercase.UseVisualStyleBackColor = true;
            // 
            // chkIncludeNumbers
            // 
            chkIncludeNumbers.AutoSize = true;
            chkIncludeNumbers.CheckAlign = ContentAlignment.MiddleRight;
            chkIncludeNumbers.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            chkIncludeNumbers.Location = new Point(145, 404);
            chkIncludeNumbers.Name = "chkIncludeNumbers";
            chkIncludeNumbers.Size = new Size(160, 24);
            chkIncludeNumbers.TabIndex = 6;
            chkIncludeNumbers.Text = "Include Numbers     ";
            chkIncludeNumbers.UseVisualStyleBackColor = true;
            // 
            // chkIncludeSymbols
            // 
            chkIncludeSymbols.AutoSize = true;
            chkIncludeSymbols.CheckAlign = ContentAlignment.MiddleRight;
            chkIncludeSymbols.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            chkIncludeSymbols.Location = new Point(145, 434);
            chkIncludeSymbols.Name = "chkIncludeSymbols";
            chkIncludeSymbols.Size = new Size(160, 24);
            chkIncludeSymbols.TabIndex = 7;
            chkIncludeSymbols.Text = "Include Symbols      ";
            chkIncludeSymbols.UseVisualStyleBackColor = true;
            // 
            // btnGeneratePassword
            // 
            btnGeneratePassword.BackColor = Color.SteelBlue;
            btnGeneratePassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGeneratePassword.ForeColor = SystemColors.ButtonFace;
            btnGeneratePassword.Location = new Point(189, 476);
            btnGeneratePassword.Name = "btnGeneratePassword";
            btnGeneratePassword.Size = new Size(153, 64);
            btnGeneratePassword.TabIndex = 8;
            btnGeneratePassword.Text = "Generate";
            btnGeneratePassword.UseVisualStyleBackColor = false;
            btnGeneratePassword.Click += btnGeneratePassword_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(534, 552);
            Controls.Add(btnGeneratePassword);
            Controls.Add(chkIncludeSymbols);
            Controls.Add(chkIncludeNumbers);
            Controls.Add(chkIncludeLowercase);
            Controls.Add(chkIncludeUppercase);
            Controls.Add(txtPasswordLength);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNewPassword);
            Name = "Form1";
            Text = "Password Generator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNewPassword;
        private Label label1;
        private Label label2;
        private TextBox txtPasswordLength;
        private CheckBox chkIncludeUppercase;
        private CheckBox chkIncludeLowercase;
        private CheckBox chkIncludeNumbers;
        private CheckBox chkIncludeSymbols;
        private Button btnGeneratePassword;
    }
}