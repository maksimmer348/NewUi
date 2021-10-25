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
        private TestProgramBuilder testProgram = new TestProgramBuilder();
        public CreateOrChangeTestProgram()
        {
            InitializeComponent();
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

        void CreateOrChangeTestPrograGroupsEnadled(bool enabled = false)
        {
            gBoxModul.Enabled = enabled;
            gBoxCreateOrChangeTestProgram.Enabled = enabled;
        }

        private void gBoxModul_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddModul_Click(object sender, EventArgs e)
        {
            if (rBtnContactCheck.Checked)
            {
                testProgram.AddPrograms(new ContactCheck());
            }
            if (rBtnSupplyOn.Checked)
            {
                testProgram.AddPrograms(new SupplyOn());
            }
            if (rBtnSupplyOff.Checked)
            {
                testProgram.AddPrograms(new SupplyOff());
            }
            if (rBtnParamMeasureVoltage.Checked)
            {
                testProgram.AddPrograms(new ParamMeasureTemperature());
            }
            if (rBtnSetTemperature.Checked)
            {
                testProgram.AddPrograms(new SetTemperature());
            }
            if (rBtnDelayBetwenMesaure.Checked)
            {
                testProgram.AddPrograms(new DelayBetwenMesaure());//добавить данные 
            }
            if (rBtnCycle.Checked)
            {
                testProgram.AddPrograms(new Cycle());//добавить данные 
            }
        }


    }
}
