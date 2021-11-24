using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {
            passwordTb.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                passwordTb.PasswordChar = '\0';
            }
            else
            {
                passwordTb.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            nameTb.Text = "";
            passwordTb.Text = "";
        }
    }
}
