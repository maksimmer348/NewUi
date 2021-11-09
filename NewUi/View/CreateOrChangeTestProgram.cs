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
        UiController UiController = new();

        public CreateOrChangeTestProgram()
        {
            InitializeComponent();
            Controller.TestProgramsListChanged += ControllerOnTestProgramsListChanged;

            //Controller.Program.NameChanged += ProgramOnNameChanged;
            Controller.ModulesListChanged += OnModulesListChanged;

            dGridModulesList.AllowUserToAddRows = false;
            Controller.Load();

            UiController.ProgramUiElementListAdd(gBoxModule,
                gBoxCreateOrChangeTestProgram, btnUpModul, btnDownModul, btnAddModul, btnDelModul);

            UiController.ProgramsListUiElementListAdd(gBoxTestProgramList);

            UiController.ProgramOrProgramsListUiMode(ModeEdit.ProgramsList);
        }

        /// <summary>
        /// ивент додбавление модуля в список модулей
        /// </summary>
        /// <param name="testProgram">тестоовая программа</param>
        private void OnModulesListChanged(TestProgram testProgram)
        {
            tBoxTestProgramName.Clear();
            tBoxTestProgramName.Text = testProgram.Name;
            dGridModulesList.Rows.Clear();
            foreach (var module in testProgram.ModulesList)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell() {Value = module.Priority +" "+ module.Name});
                row.Cells.Add(new DataGridViewTextBoxCell() {Value = module.DescriptionModule()});
                dGridModulesList.Rows.Add(row);
            }
        }

        /// <summary>
        /// ивент изменение имени программы
        /// </summary>
        /// <param name="testProgramName"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ProgramOnNameChanged(string testProgramName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ивент добавлление программы в список программ
        /// </summary>
        /// <param name="testPrograms">тестовая программа</param>
        private void ControllerOnTestProgramsListChanged(List<TestProgram> testPrograms)
        {
            listBoxProgramsList.Items.Clear();
            foreach (var program in testPrograms)
            {
                listBoxProgramsList.Items.Add(program.Name + " " + program.Id);
            }
        }

        #region додбавление программы в список и работа с этим списком

        /// <summary>
        /// создать новую программу
        /// </summary>
        /// <param name="sender">создать</param>
        /// <param name="e"></param>
        private void btnCreateTestProgram_Click(object sender, EventArgs e)
        {
            //откллюлчаем возмонжсть редактирования программы
            Controller.ChangeTestProgram(false);
            
            UiController.ProgramOrProgramsListUiMode(ModeEdit.Program);
            //создаем заготовкуу программы
            Controller.CreateProgram();
            dGridModulesList.Rows.Clear();
        }

        /// <summary>
        /// изменить программу
        /// </summary>
        /// <param name="sender">измениить</param>
        /// <param name="e"></param>
        private void btnChangeTestProgram_Click(object sender, EventArgs e)
        {
            UiController.ProgramOrProgramsListUiMode(ModeEdit.Program);
            var selectedIndexTestProgram = listBoxProgramsList.SelectedIndex;
            
            //подлючаем возмоносьт редактировать программу
            Controller.ChangeTestProgram(true);
        }

        /// <summary>
        /// удалить программу
        /// </summary>
        /// <param name="sender">удалить</param>
        /// <param name="e"></param>
        private void btnDelTestProgram_Click(object sender, EventArgs e)
        {
            Controller.DeleteTestProgram(listBoxProgramsList.SelectedIndex);
            dGridModulesList.Rows.Clear();
        }


        /// <summary>
        /// выбрать программу из списка для изменения, удаления илли применения
        /// </summary>
        /// <param name="sender">listBoxProgramList</param>
        /// <param name="e"></param>
        private void listBoxProgramsList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var index = listBoxProgramsList.SelectedIndex;
            Controller.SelectedTestProgram(index);
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
           
            UiController.ProgramOrProgramsListUiMode(ModeEdit.ProgramsList);
            Controller.AddingProgramAndModuleToDb(tBoxTestProgramName.Text);
            Controller.ChangeTestProgram(false);
        }

        /// <summary>
        /// отменить изменение или создание программы
        /// </summary>
        /// <param name="sender">отменить</param>
        /// <param name="e"></param>
        private void btnCancelCreateTestProgram_Click(object sender, EventArgs e)
        {
            UiController.ProgramOrProgramsListUiMode(ModeEdit.ProgramsList);
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
                testModule = new ContactCheck() {Name = "Проверка контактирования", ContactsCount = 1};
            }

            if (rBtnSupplyOn.Checked)
            {
                testModule = new SupplyOn() {Name = "Включение источника"};
            }

            if (rBtnSupplyOff.Checked)
            {
                testModule = new SupplyOff() {Name = "Выключение источника"};
            }

            if (rBtnParamMeasureVoltage.Checked)
            {
                testModule = new SupplyOff() {Name = "Замер выходного напряжения"};
            }

            if (rBtnSetTemperature.Checked)
            {
                testModule = new SetTemperature()
                    {Name = "Установка температуры", Temperature = numUpSetTemperature.Value};
            }

            if (rBtnParamMeasureTemperature.Checked)
            {
                testModule = new ParamMeasurementTemperature() {Name = "Замер температуры"};
            }

            if (rBtnDelayBetwenMesaure.Checked)
            {
                testModule = new DelayBetweenMeasurement()
                {
                    Name = "Задержка между операциями",
                    Min = numUpDelayBetwenMesaureMin.Value,
                    Sec = numUpDelayBetwenMesaureSec.Value
                };
            }

            if (rBtnCycle.Checked)
            {
                testModule = new Cycle()
                {
                    Name = "Цикл измерений",
                    Hour = numUpCycleHour.Value,
                    Min = numUpCycleMin.Value
                };
            }

            Controller.AddingModuleToProgram(testModule);
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
        /// <param name="sender">↓</param>
        /// <param name="e"></param>
        private void btnDownModul_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}