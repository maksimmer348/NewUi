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
        private TestProgramController testProgramController = new();

        public CreateOrChangeTestProgram()
        {
            InitializeComponent();

            dGridModulesList.AllowUserToAddRows = false;
            dGridTestProgramList.AllowUserToAddRows = false;

            testProgramController.TestProgramsListChanged += TestProgramsChangedList;
            testProgramController.SelectedTestProgramChanged += SelectedTestProgramChanged;

            testProgramController.Load();
        }

        private void SelectedTestProgramChanged(TestProgram testProgram)
        {
            testProgram.ModulesListChanged -= ModulesListChanged;
            testProgram.ModulesListChanged += ModulesListChanged;
            testProgram.InvokeModulesListChanged();
        }

        private void TestProgramsChangedList(List<TestProgram> programsList)
        {
            dGridTestProgramList.Rows.Clear();
            foreach (var program in programsList)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell() {Value = program.Name, Tag = program});
                dGridTestProgramList.Rows.Add(row);
            }
        }

        private void ModulesListChanged(List<TestModule> programsModulesList)
        {
            dGridModulesList.Rows.Clear();
            foreach (var module in programsModulesList)
            {
                dGridModulesList.Rows.Add(module.Name, module.ToFormString());
            }
        }


        private void CreateTestProgram_Load(object sender, EventArgs e)
        {
        }

        private void btnAddTestProgram_Click(object sender, EventArgs e) //добавить программу
        {
            TestProgram program = new()
            {
                Name = tBoxTestProgramName.Text
            };

            testProgramController.TestProgramsList.Add(program);
            testProgramController.OnTestProgramsChanged();
        }


        private void btnChangeTestProgram_Click(object sender, EventArgs e)
        {
        }


        private void gBoxModul_Enter(object sender, EventArgs e)
        {
        }

        private void btnAddModul_Click(object sender, EventArgs e)
        {
            var selectedTestProgram = testProgramController.SelectedTestProgram;
            selectedTestProgram.ModulesList ??= new List<TestModule>();
            if (rBtnContactCheck.Checked)
            {
                selectedTestProgram.ModulesList.Add(new ContactCheck() {Name = "Проверка контактирования"});
            }

            if (rBtnSupplyOn.Checked)
            {
                selectedTestProgram.ModulesList.Add(new SupplyOn() {Name = "Включение источника"});
            }

            if (rBtnSupplyOff.Checked)
            {
                selectedTestProgram.ModulesList.Add(new SupplyOff() {Name = "Выключение источника"});
            }

            if (rBtnParamMeasureVoltage.Checked)
            {
                selectedTestProgram.ModulesList
                    .Add(new OutputVoltageMeasure() {Name = "Замер выходного напряжения"});
            }

            if (rBtnSetTemperature.Checked)
            {
                selectedTestProgram.ModulesList.Add(
                    new SetTemperature() {Name = "Установка температуры"});
            }

            if (rBtnParamMeasureTemperature.Checked)
            {
                selectedTestProgram.ModulesList.Add(
                    new ParamMeasurementTemperature() {Name = "Замер температуры"});
            }

            if (rBtnDelayBetwenMesaure.Checked)
            {
                selectedTestProgram.ModulesList.Add(
                    new DelayBetweenMeasurement() {Name = "Задержка между операциями"});
            }

            if (rBtnCycle.Checked)
            {
                selectedTestProgram.ModulesList.Add(new Cycle() {Name = "Цикл измерений"});
            }

            testProgramController.OnSelectedTestProgramsChanged();
        }

        private void dGridTestProgramList_SelectionChanged(object sender, EventArgs e)
        {
            var cells = dGridTestProgramList.SelectedCells;

            if (cells.Count > 0)
                testProgramController.SelectedTestProgram = (TestProgram) cells[0].Tag;
        }
    }
}