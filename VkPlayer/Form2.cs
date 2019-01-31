using System;
using System.Windows.Forms;
using System.IO;
namespace VkPlayer
{
    public partial class AuthForm2 : Form
    {
        public AuthForm2()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("someFile.tempdat", CodeBox.Text);
            Close();
        }
    }
}
