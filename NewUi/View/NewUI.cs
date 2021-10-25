using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewUi.View;

namespace NewUi
{
    public partial class NewUI : Form
    {
        public NewUI()
        {
            InitializeComponent();
        }

        private void NewUI_Load(object sender, EventArgs e)
        {
            CreateOrChangeTestProgram createOrChangeTestProgram = new CreateOrChangeTestProgram();
            createOrChangeTestProgram.ShowDialog();
            this.Close();
        }
    }
}
