using System;
using System.Windows.Forms;

namespace UI
{
    public partial class LoginWindow : Form
    {
        public string Username;
        public string Password;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = usernameField.Text;
            Password = passwordField.Text;
            this.Close();
        }
    }
}
