
namespace NewUi.View
{
    partial class AuthorizationForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.loginField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.btnRestorePasssword = new System.Windows.Forms.Button();
            this.Пользователь = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(119, 81);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "вход";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // loginField
            // 
            this.loginField.Location = new System.Drawing.Point(149, 12);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(125, 23);
            this.loginField.TabIndex = 2;
            this.loginField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordField
            // 
            this.passwordField.Location = new System.Drawing.Point(149, 41);
            this.passwordField.Name = "passwordField";
            this.passwordField.Size = new System.Drawing.Size(126, 23);
            this.passwordField.TabIndex = 3;
            // 
            // btnRestorePasssword
            // 
            this.btnRestorePasssword.Location = new System.Drawing.Point(12, 81);
            this.btnRestorePasssword.Name = "btnRestorePasssword";
            this.btnRestorePasssword.Size = new System.Drawing.Size(92, 23);
            this.btnRestorePasssword.TabIndex = 4;
            this.btnRestorePasssword.Text = "восстановить";
            this.btnRestorePasssword.UseVisualStyleBackColor = true;
            // 
            // Пользователь
            // 
            this.Пользователь.AutoSize = true;
            this.Пользователь.Location = new System.Drawing.Point(53, 12);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(84, 15);
            this.Пользователь.TabIndex = 5;
            this.Пользователь.Text = "Пользователь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль";
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 112);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Пользователь);
            this.Controls.Add(this.btnRestorePasssword);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.loginField);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Name = "AuthorizationForm";
            this.Text = "AuthorizationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.Button btnRestorePasssword;
        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Label label2;
    }
}