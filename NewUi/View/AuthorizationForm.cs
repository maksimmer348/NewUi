using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewUi.View
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginUser = loginField.Text;
            string passwordUser = passwordField.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
