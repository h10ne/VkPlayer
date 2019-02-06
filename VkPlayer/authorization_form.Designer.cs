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
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.auth_btn = new System.Windows.Forms.Button();
            this.passwordVisible = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.ForeColor = System.Drawing.Color.Gray;
            this.login.Location = new System.Drawing.Point(9, 12);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(174, 27);
            this.login.TabIndex = 1;
            this.login.Text = "Login";
            this.login.Enter += new System.EventHandler(this.login_Enter);
            // 
            // password
            // 
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.ForeColor = System.Drawing.Color.Gray;
            this.password.Location = new System.Drawing.Point(9, 45);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(174, 27);
            this.password.TabIndex = 2;
            this.password.Text = "Password";
            this.password.Enter += new System.EventHandler(this.password_Enter);
            // 
            // auth_btn
            // 
            this.auth_btn.AutoSize = true;
            this.auth_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(159)))), ((int)(((byte)(231)))));
            this.auth_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.auth_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.auth_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(199)))), ((int)(((byte)(237)))));
            this.auth_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.auth_btn.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.auth_btn.Location = new System.Drawing.Point(52, 78);
            this.auth_btn.Name = "auth_btn";
            this.auth_btn.Size = new System.Drawing.Size(90, 31);
            this.auth_btn.TabIndex = 3;
            this.auth_btn.Text = "Authorize";
            this.auth_btn.UseVisualStyleBackColor = false;
            this.auth_btn.Click += new System.EventHandler(this.auth_btn_Click);
            // 
            // passwordVisible
            // 
            this.passwordVisible.BackColor = System.Drawing.Color.White;
            this.passwordVisible.Image = global::VkPlayer.Resource1.eye;
            this.passwordVisible.Location = new System.Drawing.Point(151, 46);
            this.passwordVisible.Name = "passwordVisible";
            this.passwordVisible.Size = new System.Drawing.Size(31, 25);
            this.passwordVisible.TabIndex = 4;
            this.passwordVisible.MouseDown += new System.Windows.Forms.MouseEventHandler(this.passwordVisible_MouseDown);
            this.passwordVisible.MouseUp += new System.Windows.Forms.MouseEventHandler(this.passwordVisible_MouseUp);
            // 
            // authorization_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(162)))));
            this.BackgroundImage = global::VkPlayer.Resource1.auth_back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(195, 113);
            this.Controls.Add(this.passwordVisible);
            this.Controls.Add(this.auth_btn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "authorization_form";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button auth_btn;
        private System.Windows.Forms.Label passwordVisible;
    }
}