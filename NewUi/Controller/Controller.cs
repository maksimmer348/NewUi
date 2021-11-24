using Microsoft.EntityFrameworkCore;


namespace NewUi
{
    class Controller
    {
        private readonly ApplicationContext db;

        public Controller()
        {
            db = ApplicationContext.Instance;
        }


        #region работа с экземляром программы

        TestProgram currentTestProgram = new();

        /// <summary>
        /// для изменения рабочеей программы
        /// </summary>
        private bool changeCurrentTestProgramEnable;

        /// <summary>
        /// создание новой программы
        /// </summary>
        public void CreateProgram()
        {
            currentTestProgram = new();
        }

        /// <summary>
        /// додбавить модуль к списку модулей тестовой пограммы
        /// </summary>
        /// <param name="tes tModule">добавляемый модуль</param>
        public void AddModuleToProgram(TestModule testModule)
        {
            if (ChangeCycleEnable)
            {
                //изменяем в списке модулей в программе текущий модуль 
                currentTestProgram.ChangeModuleInList(testModule);
            }
            else
            {
                //добавляем в спикок модулей в программе текущий модуль 
                currentTestProgram.AddModuleToList(testModule);
            }

            //устанавливаем приоритет по умолчанию для модуля 
            testModule.Priority = SetPriorityModules(testModule, ModeEdit.Program);


            //ивент обновляющий модули в списке модулей
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        /// <summary>
        /// добавление в базу данных программы с модулями
        /// </summary>
        /// <param name="name">имя программы задается здесь</param>
        public void AddingProgramAndModuleToDb(string name = "")
        {
            currentTestProgram.Name = name;
            //елси мы меняем программу
            if (changeCurrentTestProgramEnable)
            {
                currentTestProgram.ModulesList = SortModulesList(currentTestProgram.ModulesList, ModeEdit.Program);
                db.TestPrograms?.Update(currentTestProgram);
                db.SaveChanges();
                AddProgramToList(currentTestProgram, name);
            }
            //если мы добавляем новую программу
            else
            {
                currentTestProgram.ModulesList = SortModulesList(currentTestProgram.ModulesList, ModeEdit.Program);
                db.TestPrograms?.Add(currentTestProgram);
                db.SaveChanges();
                AddProgramToList(currentTestProgram);
            }

            ChangeTestProgram(false);
        }

        /// <summary>
        /// переключаения возможности редактиирования текущей программы
        /// </summary>
        /// <param name="changeProgram">переклюлчатель инициирующий редактиврование текущей программы</param>
        public void ChangeTestProgram(bool changeProgram)
        {
            changeCurrentTestProgramEnable = changeProgram;
        }

        #endregion


        #region Работа с экземляром с цикла

        private Cycle currentCycle = new();

        /// <summary>
        /// для изменения цикла
        /// </summary>
        public bool ChangeCycleEnable;

        /// <summary>
        /// переключаения редкатирования цикла
        /// </summary>
        /// <param name="changeProgram">переклюлчатель инициирующий редактиврование текущей цикла</param>
        public void EnabledCycle(bool enableCycle)
        {
            ChangeCycleEnable = enableCycle;
        }

        public void CreateCycle(TestModule testModule)
        {
            if (testModule is Cycle cycle)
            {
                currentCycle = cycle;
                AddModuleToProgram(currentCycle);
                EnabledCycle(true);
            }
        }

        /// <summary>
        /// добавление модуля в цикл
        /// </summary>
        /// <param name="testModule">модуль</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddModuleToCycle(TestModule testModule)
        {
            //добавляем в список модулей в цикле, текущий модуль и заставляем срабоать ивент
            currentCycle.AddModuleToList(testModule);
            //устанавливаем приоритет по умолчанию для модуля
            testModule.Priority = SetPriorityModules(testModule, ModeEdit.Cycle);
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        /// <summary>
        ///записываем текущий цикл со всеми внтуреними модулями в текущую программу
        /// </summary>
        public void ChangeCycleToProgram()
        {
            AddModuleToProgram(currentCycle);
            EnabledCycle(false);
        }

        //TODO как сделать определение номера цикла решить это через стек или очередь если цввета кончились просто закинуть еще раз
        public void CycleNumLoop()
        {
            foreach (var testModule in currentTestProgram.ModulesList)
            {
                var count = 0;
                if (testModule is Cycle cycle)
                {
                    if (cycle.CycleNum == 0)
                    {
                        count += 1;
                        cycle.CycleNum = count;
                    }

                    if (count < 6)
                    {
                        cycle.CycleNum = 1;
                        continue;
                    }
                }
            }
        }

        #endregion


        #region работа со списком модулей

        /// <summary>
        ///  ивент изменения списка модулей
        /// </summary>
        public event Action<TestProgram> ModulesListChangedOnProgram;

        /// <summary>
        /// оперделение входящего модуля
        /// </summary>
        /// <param name="testModule">цикл/модуль</param>
        public void CycleOrModule(TestModule testModule)
        {
            if (testModule is Cycle)
            {
                // создаем цикл, активируем флаг цикла
                CreateCycle(testModule);
            }
            else
            {
                //если модуль не цикл но флаг цикла сохраняем модуль в цикл
                if (ChangeCycleEnable)
                {
                    AddModuleToCycle(testModule);
                }
                //если модуль не цикл и НЕ флаг цикла сохраняем модуль в программу
                else
                {
                    AddModuleToProgram(testModule);
                }
            }
        }

        /// <summary>
        /// вызвает  ивент изменения списка модулей
        /// </summary>
        /// <param name="testProgram">программа в кторой изменятеся список модулей</param>
        public void InvokeModulesListChangedOnProgram(TestProgram testProgram)
        {
            ModulesListChangedOnProgram?.Invoke(testProgram);
        }

        /// <summary>
        /// приоритет по умолчанию для модуля
        /// </summary>
        /// <param name="testModule">модуль</param>
        /// <returns></returns>
        int SetPriorityModules(TestModule testModule, ModeEdit modeEdit)
        {
            if (modeEdit == ModeEdit.Program)
            {
                return currentTestProgram.ModulesList.IndexOf(testModule);
            }
            else
            {
                return currentCycle.ModulesList.IndexOf(testModule);
            }
        }

        /// <summary>
        /// сортировка списка модулей
        /// </summary>
        /// <param name="testModulesList">списко модулей</param>
        List<TestModule> SortModulesList(List<TestModule> testModulesList, ModeEdit modeEdit)
        {
            if (modeEdit == ModeEdit.Program)
            {
                //List<TestModule> tempModuleList = new();
                testModulesList = testModulesList.OrderBy(m => m.Priority).ToList();

                foreach (var testModule in testModulesList)
                {
                    if (testModule is Cycle cycle)
                    {
                        cycle.ModulesList = cycle.ModulesList.OrderBy(m => m.Priority).ToList();
                    }
                }
            }

            if (modeEdit == ModeEdit.Cycle)
            {
                testModulesList = testModulesList.OrderBy(m => m.Priority).ToList();
            }

            return testModulesList;
        }

        #endregion


        #region работа со списком программ

        public List<TestProgram>? TestProgramsList = new();

        /// <summary>
        ///  ивент изменения списка программ
        /// </summary>
        public event Action<List<TestProgram>?> TestProgramsListChanged;

        /// <summary>
        /// добавление/изменение програмы в списке
        /// </summary>
        /// <param name="testProgram">тестовая программа</param>
        /// <param name="newNameProgram">новое имя программы в случае если изменение</param>
        public void AddProgramToList(TestProgram testProgram, string newNameProgram = "")
        {
            var tempTestProgram = TestProgramsList.FirstOrDefault(pr => pr.Id == testProgram.Id);

            if (tempTestProgram == null)
            {
                TestProgramsList.Add(testProgram);
                InvokeProgramsListChanged();
            }

            //если такая программа уже существует в списке 
            if (tempTestProgram != null)
            {
                tempTestProgram.Name = newNameProgram;
                InvokeProgramsListChanged();
            }
        }

        /// <summary>
        /// выбор программы из списка программ
        /// </summary>
        /// <param name="index">индекс выбора программы</param>
        public void SelectedTestProgram(int index)
        {
            currentTestProgram = TestProgramsList[index];
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        /// <summary>
        /// удаление тестовой программы из списка и базы данных
        /// </summary>
        /// <param name="indexTestProgram"></param>
        public void DeleteTestProgram(int indexTestProgram)
        {
            db.Remove((object) TestProgramsList[indexTestProgram]);
            db.SaveChanges();
            TestProgramsList.RemoveAt(indexTestProgram);
            InvokeProgramsListChanged();
        }

        /// <summary>
        /// изменение списка программ
        /// </summary>
        public void InvokeProgramsListChanged()
        {
            TestProgramsListChanged?.Invoke(TestProgramsList);
        }

        #endregion


        #region предзагрузка из бд

        /// <summary>
        /// загрузка из базы даннных
        /// </summary>
        public void LoadInDb()
        {
            var tempProgramList = db.TestPrograms?.Include(p =>
                p.ModulesList).ThenInclude(m => m.ModulesList).ToList();
            TestProgramsList = tempProgramList;
            foreach (var testProgram in tempProgramList)
            {
                //TODO выяснить как распределитиь приоритеты и сохранить в списки программ
                //TODO как правильно вывести программы ктороые в списке првиьлная последовательность
                testProgram.ModulesList = SortModulesList(testProgram.ModulesList, ModeEdit.Program);
            }

            InvokeProgramsListChanged();
        }

        /// <summary>
        /// создание программы по умоллчанию и базы данных, если база данных програм еще не создана
        /// </summary>
        public void Load()
        {
            //если в бд нинчего нет или она не существует, создаем одну запись по умолчанию 
            // и добавляем ее в бд
            if (!db.TestPrograms.Any())
            {
                CreateProgram();
                AddModuleToProgram(ContactCheck.Default);
                AddingProgramAndModuleToDb("По Умолчанию");
            }
            //или же загружаем данные из базы данных
            else
            {
                LoadInDb();
            }
        }

        #endregion
    }
}