﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace VkPlayer
{
    public partial class authorization_form : Form
    {
        public authorization_form()
        {
            InitializeComponent();
            if (this.Owner is Main main)
            {
                main.LoadText();
                login.Font = main.Roboto_thin;
                password.Font = main.Roboto_thin;
            }
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void auth_btn_Click(object sender, EventArgs e)
        {
            if (this.Owner is Main main)
            {
                try
                {
                    main.GetAuth(login.Text, password.Text);
                }
                catch
                { }
                if (main.isAuth == true)
                    Close();
            }
        }

        private void login_Enter(object sender, EventArgs e)
        {
            if (login.Text=="Login")
            {
                login.Text = "";
                login.ForeColor = Color.Black;
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text=="Password")
            {
                password.Text = "";
                password.ForeColor = Color.Black;
                password.PasswordChar = '•';
            }
        }        

        private void passwordVisible_MouseDown(object sender, MouseEventArgs e)
        {
            passwordVisible.Image = Resource1.eye_click;
            password.PasswordChar = '\0';
        }

        private void passwordVisible_MouseUp(object sender, MouseEventArgs e)
        {
            if (password.Text!="Password")
                password.PasswordChar = '•';
            passwordVisible.Image = Resource1.eye;
        }
    }
}
