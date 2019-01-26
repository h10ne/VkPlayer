namespace VkPlayer
{
    partial class authorization_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(authorization_form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.auth_btn = new System.Windows.Forms.Button();
            this.twoFact_check = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.Location = new System.Drawing.Point(146, 6);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(157, 27);
            this.login.TabIndex = 1;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.Location = new System.Drawing.Point(146, 34);
            this.password.Name = "password";
            this.password.PasswordChar = '•';
            this.password.Size = new System.Drawing.Size(157, 27);
            this.password.TabIndex = 1;
            // 
            // auth_btn
            // 
            this.auth_btn.AutoSize = true;
            this.auth_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.auth_btn.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.auth_btn.Location = new System.Drawing.Point(185, 67);
            this.auth_btn.Name = "auth_btn";
            this.auth_btn.Size = new System.Drawing.Size(100, 29);
            this.auth_btn.TabIndex = 2;
            this.auth_btn.Text = "Authorize";
            this.auth_btn.UseVisualStyleBackColor = false;
            this.auth_btn.Click += new System.EventHandler(this.auth_btn_Click);
            // 
            // twoFact_check
            // 
            this.twoFact_check.AutoSize = true;
            this.twoFact_check.BackColor = System.Drawing.Color.Transparent;
            this.twoFact_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.twoFact_check.Location = new System.Drawing.Point(7, 75);
            this.twoFact_check.Name = "twoFact_check";
            this.twoFact_check.Size = new System.Drawing.Size(147, 17);
            this.twoFact_check.TabIndex = 3;
            this.twoFact_check.Text = "Two-factor authentication";
            this.twoFact_check.UseVisualStyleBackColor = false;
            // 
            // authorization_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(311, 100);
            this.Controls.Add(this.twoFact_check);
            this.Controls.Add(this.auth_btn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "authorization_form";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button auth_btn;
        private System.Windows.Forms.CheckBox twoFact_check;
    }
}