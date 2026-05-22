using POS_504.Class;
using POS_504.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504
{
    public partial class LoginFrm : Form
    {
        LoginCls oLogin = new LoginCls();
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string result = oLogin.Login(txtUsername.Text, txtPass.Text);
            if(result == "Login Successful")
            {
                this.Hide();
                MainFrm main = new MainFrm(txtUsername.Text);
                main.Show();
            }
            else if(result == "Wrong Password")
            {
                MessageBox.Show("Wrong Password Please Try again!");
                txtPass.Text = "";
                txtPass.Focus();
            }
            else
            {
                MessageBox.Show("User not found!");
                txtUsername.Text = "";
                txtUsername.Focus();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
