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

        #region додбавление программы в список и работа с этим списком

        /// <summary>
        /// создатьь новую программу
        /// </summary>
        /// <param name="sender">создатьь</param>
        /// <param name="e"></param>
        private void btnCreateTestProgram_Click(object sender, EventArgs e)
        {
            //создаем заготовкуу программы
            Controller.CreateProgram();
        }

        /// <summary>
        /// изменить программу
        /// </summary>
        /// <param name="sender">измениить</param>
        /// <param name="e"></param>
        private void btnChangeTestProgram_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// удалить программу
        /// </summary>
        /// <param name="sender">удалить</param>
        /// <param name="e"></param>
        private void btnDelTestProgram_Click(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// выбрать программу из списка для изменения, удаления илли применения
        /// </summary>
        /// <param name="sender">listBoxProgramList</param>
        /// <param name="e"></param>
        private void listBoxProgramsList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///  выбрать программу и применить
        /// </summary>
        /// <param name="sender">ок</param>
        /// <param name="e"></param>
        private void btnSelectTestProgram_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// отменить операцию выбора програамы
        /// </summary>
        /// <param name="sender">отмена</param>
        /// <param name="e"></param>
        private void btnCancelTestProgram_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region создание программы и работа с модулями

        /// <summary>
        /// сохранить программу в список программ
        /// </summary>
        /// <param name="sender">сохранить</param>
        /// <param name="e"></param>
        private void btnSaveTestProgram_Click(object sender, EventArgs e)
        {
            Controller.AddingProgramToDb(tBoxTestProgramName.Text);
        }

        /// <summary>
        /// отменить изменение или создание программы
        /// </summary>
        /// <param name="sender">отменить</param>
        /// <param name="e"></param>
        private void btnCancelCreateTestProgram_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// добавление модуля в программу
        /// </summary>
        /// <param name="sender">добавить</param>
        /// <param name="e"></param>
        private void btnAddModul_Click(object sender, EventArgs e)
        {
            TestModule testModule = null;
            if (rBtnContactCheck.Checked)
            {
                testModule = new ContactCheck() {Name = "Проверка контактирования"};
            }
            if (rBtnSupplyOn.Checked)
            {
                testModule = new SupplyOn() { Name = "Включение источника"};
            }

            Controller.AddingModuleToProgram(testModule);
            //
            // if (rBtnSupplyOff.Checked)
            // {
            //     selectedTestProgram.ModulesList.Add(new SupplyOff()
            //         {TestProgram = selectedTestProgram, Name = "Выключение источника"});
            // }
            //
            // if (rBtnParamMeasureVoltage.Checked)
            // {
            //     selectedTestProgram.ModulesList
            //         .Add(new OutputVoltageMeasure()
            //             {TestProgram = selectedTestProgram, Name = "Замер выходного напряжения"});
            // }
            //
            // if (rBtnSetTemperature.Checked)
            // {
            //     selectedTestProgram.ModulesList.Add(
            //         new SetTemperature() {TestProgram = selectedTestProgram, Name = "Установка температуры"});
            // }
            //
            // if (rBtnParamMeasureTemperature.Checked)
            // {
            //     selectedTestProgram.ModulesList.Add(
            //         new ParamMeasurementTemperature() {TestProgram = selectedTestProgram, Name = "Замер температуры"});
            // }
            //
            // if (rBtnDelayBetwenMesaure.Checked)
            // {
            //     selectedTestProgram.ModulesList.Add(
            //         new DelayBetweenMeasurement()
            //             {TestProgram = selectedTestProgram, Name = "Задержка между операциями"});
            // }
            // if (rBtnCycle.Checked)
            // {
            //     selectedTestProgram.ModulesList.Add(new Cycle()
            //         {TestProgram = selectedTestProgram, Name = "Цикл измерений"});
            // }

        }

        /// <summary>
        /// удаление модуля из программы
        /// </summary>
        /// <param name="sender">удалить</param>
        /// <param name="e"></param>
        private void btnDelModul_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// подвинут ьмодуль в проргамме на одно позицию вверх
        /// </summary>
        /// <param name="sender">↑</param>
        /// <param name="e"></param>
        private void btnUpModul_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///  подвинуть модуль в проргамме на одно позицию вниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">↓</param>
        private void btnDownModul_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}