using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace NewUi.View
{
    public partial class CreateOrChangeTestProgram : Form
    {
        Controller controller = new();
        UiController uiController = new();
        DataTable dt = new ();
        public CreateOrChangeTestProgram()
        {
            InitializeComponent();
            
            dt.Columns.Add("Module", typeof(string));
            dt.Columns.Add("Descriprion", typeof(string));
            
            //при изменении списка программ
            controller.TestProgramsListChanged += ControllerOnTestProgramsListChanged;
            //при имзенениии модуля в программе
            controller.ModulesListChangedOnProgram += OnModulesListChanged;
            //при изменении модуля в цикле
            controller.ModulesListChangedOnCycle += ControllerOnModulesListChangedOnCycle;
            //удаляет лишние записи в гридвью
            dGridModulesList.AllowUserToAddRows = false;

            //подгружаем данные из базы данных, создаем если нет первую програамму по умолчанию
            controller.Load();

            //подгружаем в контроллер интерфейса связанные с тестовой программой ui элменты
            uiController.ProgramUiElementListAdd(gBoxModule, gBoxCreateOrChangeTestProgramOrCycle,
                btnUpModule, btnDownModule, btnAddModule, btnDelModule);
            //подгружаем в контроллер интерфейса связанные с списсокм тестовых программ ui элменты
            uiController.ProgramsListUiElementListAdd(gBoxTestProgramList);
            //подгружаем в контроллер интерфейса связанные с циклом ui элменты
            uiController.NoneCycleUiElementListAdd(gBoxTestProgramList);
            //подгружаем в контроллер интерфейса ui элменты кторые будут менять цвет при изменении цикла 
            uiController.CycleUiElementChangeColorListAdd(rBtnCycle, pBoxCycle, labelCycleHour,
                labelCycleMin,
                pBoxCreateOrChangeTestProgramOrCycle, rBtnParamMeasureVoltage, rBtnParamMeasureTemperature,
                pBoxModuleInProgramOrCycle, rBtnDelayBetwenMesaure, labelDelayBetwenMesaureMin,
                labelDelayBetwenMesaureSec);

            // uiController.ChangeColor(CycleColor.Green);
            //при запуске программы запускается отображение связанных с списокм тестовых программ ui элменты
            uiController.UiModeEditProgramOrProgramList(ModeEdit.ProgramsList);
            
           
        }

        /// <summary>
        /// ивент добавления модуля в цикл
        /// </summary>
        /// <param name="cycle">цикл</param>
        private void ControllerOnModulesListChangedOnCycle(Cycle cycle)
        {

            foreach (var module in cycle.ModulesList)
            {
                dt.Rows.Add(module.Name, module.DescriptionModule());
            }
            //
            // var row = new DataGridViewRow();
            //     row.DefaultCellStyle.BackColor = Color.Red;
            //     row.Cells.Add(new DataGridViewTextBoxCell() {Value = module.Priority + " " + module.Name});
            //     row.Cells.Add(new DataGridViewTextBoxCell() {Value = module.DescriptionModule()});
            //     dGridModulesList.Rows.Add(row);
            // }
            dGridModulesList.DataSource = dt;
        }

        /// <summary>
        /// ивент додбавление модуля в список модулей
        /// </summary>
        /// <param name="testProgram">тестоовая программа</param>
        private void OnModulesListChanged(TestProgram testProgram)
        {
            
            tBoxTestProgramName.Clear();
            tBoxTestProgramName.Text = testProgram.Name;
            for (int i = 0; i < testProgram.ModulesList.Count; i++)
            {
                dt.Rows.Add(testProgram.ModulesList[i].Name, testProgram.ModulesList[i].DescriptionModule());
            }
            
            dGridModulesList.DataSource = dt;
            
            // foreach (var module in testProgram.ModulesList)
            // {
            //     
            //     // var row = new DataGridViewRow();
            //     // row.Cells.Add(new DataGridViewTextBoxCell() {Value = module.Priority + " " + module.Name});
            //     // row.Cells.Add(new DataGridViewTextBoxCell() {Value = module.DescriptionModule()});
            //     // dGridModulesList.Rows.Add(row);
            // }
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
            controller.ChangeTestProgram(false);

            uiController.UiModeEditProgramOrProgramList(ModeEdit.Program);
            //создаем заготовку программы
            controller.CreateProgram();

            //dGridModulesList.Rows.Clear();
        }

        /// <summary>
        /// изменить программу
        /// </summary>
        /// <param name="sender">измениить</param>
        /// <param name="e"></param>
        private void btnChangeTestProgram_Click(object sender, EventArgs e)
        {
            uiController.UiModeEditProgramOrProgramList(ModeEdit.Program);
            //подлючаем возмоносьт редактировать программу
            controller.ChangeTestProgram(true);
        }

        /// <summary>
        /// удалить программу
        /// </summary>
        /// <param name="sender">удалить</param>
        /// <param name="e"></param>
        private void btnDelTestProgram_Click(object sender, EventArgs e)
        {
            controller.DeleteTestProgram(listBoxProgramsList.SelectedIndex);
            dGridModulesList.Rows.Clear();
        }

        /// <summary>
        /// выбрать программу из списка для изменения, удаления илли применения
        /// </summary>
        /// <param name="sender">listBoxProgramList</param>
        /// <param name="e"></param>
        private void listBoxProgramsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = listBoxProgramsList.SelectedIndex;
            controller.SelectedTestProgram(index);
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
        /// сохранить программу/цикл в список программ/в программу
        /// </summary>
        /// <param name="sender">сохранить</param>
        /// <param name="e"></param>
        private void btnSaveTestProgram_Click(object sender, EventArgs e)
        {
            if (controller.EnableCycle)
            {
                controller.AddingModuleCycleToDb();
                controller.ModeProgramOrCycle(ModeEdit.Program);
            }
            else if (!controller.EnableCycle)
            {
                uiController.UiModeEditProgramOrProgramList(ModeEdit.ProgramsList);
                controller.AddingProgramAndModuleToDb(tBoxTestProgramName.Text);
                controller.ChangeTestProgram(false);
            }
        }

        /// <summary>
        /// отменить изменение или создание программы/цикла
        /// </summary>
        /// <param name="sender">отменить</param>
        /// <param name="e"></param>
        private void btnCancelCreateTestProgram_Click(object sender, EventArgs e)
        {
            if (controller.EnableCycle)
            {
                uiController.UiModeEditProgramOrCycle(ModeEdit.Program);
            }
            else if (!controller.EnableCycle)
            {
                uiController.UiModeEditProgramOrProgramList(ModeEdit.ProgramsList);
            }
        }

        /// <summary>
        /// добавление модуля в программу
        /// </summary>
        /// <param name="sender">добавить</param>
        /// <param name="e"></param>
        private void btnAddModule_Click(object sender, EventArgs e)
        {
            TestModule testModule = null;
            if (rBtnContactCheck.Checked)
            {
                testModule = new ContactCheck()
                {
                    Name = "Проверка контактирования",
                    ContactsCount = 1
                };
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
                testModule = new OutputVoltageMeasure() {Name = "Замер выходного напряжения"};
            }

            if (rBtnSetTemperature.Checked)
            {
                testModule = new SetTemperature()
                {
                    Name = "Установка температуры",
                    Temperature = numUpSetTemperature.Value
                };
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

            //работа с циклом
            if (rBtnCycle.Checked)
            {
                testModule = new Cycle()
                {
                    Name = "Цикл измерений",
                    Hour = numUpCycleHour.Value,
                    Min = numUpCycleMin.Value
                };

                controller.ModeProgramOrCycle(ModeEdit.Cycle);
                //UiController.UiModeEditProgramOrCycle(ModeEdit.Cycle);
            }

            //если флаг цикла
            if (controller.EnableCycle)
            {
                //если модуль является циклом 
                if (testModule is Cycle)
                {
                    //добавить его в программу
                    controller.AddModuleToProgram(testModule);
                }
                //если модуль не цикл и при этом флаг цикла, добавляем модуль в текущий цикл
                else
                {
                    controller.AddModuleToCycle(testModule);
                }
            }
            //если флага цикла нет добавляем модуль в тестовую программу
            else
            {
                controller.AddModuleToProgram(testModule);
            }
        }

        /// <summary>
        /// удаление модуля из программы
        /// </summary>
        /// <param name="sender">удалить</param>
        /// <param name="e"></param>
        private void btnDelModule_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// подвинут ьмодуль в проргамме на одно позицию вверх
        /// </summary>
        /// <param name="sender">↑</param>
        /// <param name="e"></param>
        private void btnUpModule_Click(object sender, EventArgs e)
        {
            count -= 1;

            changeColor();
        }

        int count = 0;

        /// <summary>
        ///  подвинуть модуль в проргамме на одно позицию вниз
        /// </summary>
        /// <param name="sender">↓</param>
        /// <param name="e"></param>
        private void btnDownModule_Click(object sender, EventArgs e)
        {
            count += 1;
            changeColor();
        }

        void changeColor()
        {
            if (count < 1)
            {
                count = 6;
            }

            if (count > 6)
            {
                count = 1;
            }

            switch (count)
            {
                case 1:
                    uiController.ChangeColorCycle(CycleColor.Blue);
                    break;
                case 2:
                    uiController.ChangeColorCycle(CycleColor.Green);
                    break;
                case 3:
                    uiController.ChangeColorCycle(CycleColor.Olive);
                    break;
                case 4:
                    uiController.ChangeColorCycle(CycleColor.Purpule);
                    break;
                case 5:
                    uiController.ChangeColorCycle(CycleColor.Red);
                    break;
                case 6:
                    uiController.ChangeColorCycle(CycleColor.Yellow);
                    break;
            }
        }

        #endregion
    }
}