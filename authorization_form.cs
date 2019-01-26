using System;
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
                label1.Font= main.Roboto_thin;
                label2.Font = main.Roboto_thin;
            }
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Width = 327;
            Height = 143;
            twoFact_check.Location = new Point(7, 74);
            auth_btn.Location = new Point(176, 66);
            auth_btn.FlatAppearance.BorderSize = 0;
            auth_btn.FlatStyle = FlatStyle.Flat;
        }

        private void auth_btn_Click(object sender, EventArgs e)
        {
            if (this.Owner is Main main)
            {
                try
                {
                     if (!twoFact_check.Checked)
                     {
                         main._Login = login.Text;
                         main._Password = password.Text;
                         main.GetAuth(null);
                         Close();
                     }
                     else
                     {
                        main._Login = login.Text;
                        main._Password = password.Text;
                        File.WriteAllText("someFile.tempdat", "");
                        Close();
                        main.GetAuth("code");
                    }
                                      
                }
                catch
                {
                    MessageBox.Show(
                        "Неверный логин/пароль",
                        "Ошибка",
                        MessageBoxButtons.OK);
                }
            }
        }
       
    }
}
