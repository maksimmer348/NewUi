using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Internal;

namespace NewUi.View
{
    public partial class CreateOrChangeTestProgram : Form
    {
        Controller Controller = new();


        public CreateOrChangeTestProgram()
        {
            InitializeComponent();
            dGridModulesList.AllowUserToAddRows = false;
        }

        private Random r = new Random();

        private void btnAddModul_Click(object sender, EventArgs e)
        {
            var selectedTestProgram = Controller.SelectedTestProgram;
            if (rBtnContactCheck.Checked)
            {
                ContactCheck contactCheck = new ContactCheck() {Name = "Проверка контактирования"};
                Controller.ModuleTempList.Add(contactCheck);
                //selectedTestProgram.AddModule(Controller.ContactCheck(selectedTestProgram));
            }

            if (rBtnSupplyOn.Checked)
            {
                selectedTestProgram.ModulesList.Add(new SupplyOn()
                    {TestProgram = selectedTestProgram, Name = "Включение источника"});
            }

            if (rBtnSupplyOff.Checked)
            {
                selectedTestProgram.ModulesList.Add(new SupplyOff()
                    {TestProgram = selectedTestProgram, Name = "Выключение источника"});
            }

            if (rBtnParamMeasureVoltage.Checked)
            {
                selectedTestProgram.ModulesList
                    .Add(new OutputVoltageMeasure()
                        {TestProgram = selectedTestProgram, Name = "Замер выходного напряжения"});
            }

            if (rBtnSetTemperature.Checked)
            {
                selectedTestProgram.ModulesList.Add(
                    new SetTemperature() {TestProgram = selectedTestProgram, Name = "Установка температуры"});
            }

            if (rBtnParamMeasureTemperature.Checked)
            {
                selectedTestProgram.ModulesList.Add(
                    new ParamMeasurementTemperature() {TestProgram = selectedTestProgram, Name = "Замер температуры"});
            }

            if (rBtnDelayBetwenMesaure.Checked)
            {
                selectedTestProgram.ModulesList.Add(
                    new DelayBetweenMeasurement()
                        {TestProgram = selectedTestProgram, Name = "Задержка между операциями"});
            }

            if (rBtnCycle.Checked)
            {
                selectedTestProgram.ModulesList.Add(new Cycle()
                    {TestProgram = selectedTestProgram, Name = "Цикл измерений"});
            }
        }
        private void btnCreateTestProgram_Click(object sender, EventArgs e)
        {
           Controller.
        }
        
        private void btnAddTestProgram_Click(object sender, EventArgs e) //добавить программу
        {
            // Controller.db.SaveChanges();
        }

        private void listBoxProgramsList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

      
    }
}
