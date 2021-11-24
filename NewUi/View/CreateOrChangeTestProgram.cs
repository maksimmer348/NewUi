using System.Data;

namespace NewUi.View
{
    public partial class CreateOrChangeTestProgram : Form
    {
        Controller controller = new();
        UiController uiController = new();
        DataTable dt = new();

        public CreateOrChangeTestProgram()
        {
            InitializeComponent();

            dt.Columns.Add("Module", typeof(string));
            dt.Columns.Add("Descriprion", typeof(string));

            //при изменении списка программ
            controller.TestProgramsListChanged += ControllerOnTestProgramsListChanged;
            //при имзенениии модуля в программе
            controller.ModulesListChangedOnProgram += OnModulesListChanged;
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
        /// ивент додбавление модуля в список модулей
        /// </summary>
        /// <param name="testProgram">тестоовая программа</param>
        private void OnModulesListChanged(TestProgram testProgram)
        {
            
            dt.Clear();
            //индексы циклов для изменеия цветов
            var indexCycles =new Dictionary<int, byte[]>();
            //индексы модулей в цикле для изменеия цветов
            var indexModules = new Dictionary<int, int>();
            // Color c = default;
            // byte[] cycleColor = new byte[] {c.A,c.R,c.G,c.B};
            
            if (!string.IsNullOrWhiteSpace(testProgram.Name))
            {
                tBoxTestProgramName.Text = testProgram.Name;
            }
            
            foreach (var testModule in testProgram.ModulesList)
            {
                var dataRow = dt.Rows.Add(testModule.Name, testModule.DescriptionModule());
            
                if (testModule is Cycle cycle)
                {
                    //получаю индекс цикла
                    var indexCycle = dt.Rows.IndexOf(dataRow);
                    indexCycles.Add(indexCycle, cycle.Color);
                    
                    foreach (var testModuleCycle in testModule.ModulesList)
                    {
                        dataRow = dt.Rows.Add(testModuleCycle.Name, testModuleCycle.DescriptionModule());
                        //
                        indexModules.Add(dt.Rows.IndexOf(dataRow), indexCycle);
                    }
                }
            }
            dGridModulesList.DataSource = null;
            dGridModulesList.Rows.Clear();
            dGridModulesList.DataSource = dt;
            
            //TODO как раскарсить каждый цикл в свой цвет, и все входящие в этот индекс модули в более прозрачный цвет
            //крашу цикл
            foreach (var rowIndexCycle in indexCycles)
            {
                Color color = uiController.ColorCycleToRGB(rowIndexCycle.Value);
                dGridModulesList.Rows[rowIndexCycle.Key].DefaultCellStyle.BackColor = color;
                uiController.ChangeColorCycle(color);
                foreach (var rowIndexModuleInCycle in indexModules)
                {
                   
                    if (rowIndexModuleInCycle.Value == rowIndexCycle.Key)
                    {
                        dGridModulesList.Rows[rowIndexModuleInCycle.Key].DefaultCellStyle.BackColor =
                            uiController.ColorCycleToRGB(rowIndexCycle.Value, true);
                    }
                }
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
        private void ControllerOnTestProgramsListChanged(List<TestProgram>? testPrograms)
        {
            listBoxProgramsList.Items.Clear();
            if (testPrograms == null) return;
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
            //если не флаг цикла сохраняем текущую пограмму в бд
            if (!controller.ChangeCycleEnable)
            {
                //добавляем в бд текущю программу с именем 
                controller.AddingProgramAndModuleToDb(tBoxTestProgramName.Text);
                //перключаемся на ui списка программ
                uiController.UiModeEditProgramOrProgramList(ModeEdit.ProgramsList);
            }
            //если флаг цикла сохарняем цикл в текущую программу
            else
            {
                //записываем текущий цикл со всеми внтуреними модулями в текущую программу
                controller.ChangeCycleToProgram();
                //перключаемся на ui програмы
                uiController.UiModeEditProgramOrCycle(ModeEdit.Program);
            }
        }

        /// <summary>
        /// отменить изменение или создание программы/цикла
        /// </summary>
        /// <param name="sender">отменить</param>
        /// <param name="e"></param>
        private void btnCancelCreateTestProgram_Click(object sender, EventArgs e)
        {
            if (controller.ChangeCycleEnable)
            {
                uiController.UiModeEditProgramOrCycle(ModeEdit.Program);
            }
            else if (!controller.ChangeCycleEnable)
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

            if (rBtnCycle.Checked)
            {
                testModule = new Cycle()
                {
                    Name = "Цикл измерений",
                    Hour = numUpCycleHour.Value,
                    Min = numUpCycleMin.Value
                };
            }

            controller.CycleOrModule(testModule);
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
        }

        #endregion
    }
}