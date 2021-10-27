using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Internal;

namespace NewUi.View
{
    public partial class CreateOrChangeTestProgram : Form
    {
        private TestProgramsController _programController = new();
       
        public CreateOrChangeTestProgram()
        {
            InitializeComponent();
            _programController.TestProgram.SetTestProgramName += SetTestProgramName;
            _programController.TestProgram.ChangedTestProgram += ChangedTestProgram;
            _programController.TestProgram.TestProgramsChangedList += ChangedTestProgramsList;
        }

        private void ChangedTestProgram(TypesTestProgram programType)
        {
            
        }

        private void ChangedTestProgramsList(List<ITestProgram> programList)
        {
           
        }

        protected virtual void SetTestProgramName(string programName)
        {
           
        }



        private void CreateTestProgram_Load(object sender, EventArgs e)
        {

        }

        private void btnAddTestProgram_Click(object sender, EventArgs e)
        {
            
        }


        private void btnChangeTestProgram_Click(object sender, EventArgs e)
        {

        }

      

        private void gBoxModul_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddModul_Click(object sender, EventArgs e)
        {
            //решить ка кзапихать сюад радиобаттоны?
            if (rBtnContactCheck.Checked)
            {
                _programController.SelectTestProgram(TypesTestProgram.ContactCheck);
            }
            //...или  иначе
        }

        //пернессти в контроллер 
        //void CreateOrChangeTestPrograGroupsEnadled(bool enabled = false)
        //{
        //    gBoxModul.Enabled = enabled;
        //    gBoxCreateOrChangeTestProgram.Enabled = enabled;
        //}

    }
}
