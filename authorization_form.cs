using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void auth_btn_Click(object sender, EventArgs e)
        {
            if (this.Owner is Main main)
            {
                try
                 {
                    main._Login = login.Text;
                    main._Password =password.Text;
                    main.GetAuth();
                    Close();                    
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
