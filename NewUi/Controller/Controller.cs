using Microsoft.EntityFrameworkCore;


namespace NewUi
{
    class Controller
    {
        private readonly ApplicationContext db;


        TestProgram currentTestProgram = new();

        /// <summary>
        /// для изменения рабочеей программы
        /// </summary>
        private bool changeCurrentTestProgramEnable;

        /// <summary>
        /// список программ
        /// </summary>
        public List<TestProgram>? TestProgramsList = new();

        /// <summary>
        ///  ивент изменения списка программ
        /// </summary>
        public event Action<List<TestProgram>?> TestProgramsListChanged;

        /// <summary>
        ///  ивент изменения списка модулей
        /// </summary>
        public event Action<TestProgram> ModulesListChangedOnProgram;

        private Cycle currentCycle = new();

        /// <summary>
        /// для изменения цикла
        /// </summary>
        public bool changeCycleEnable;
        
        /// <summary>
        /// ивент изменения списка модулей
        /// </summary>
        public event Action<TestModule> ModulesListChangedOnCycle;


        public Controller()
        {
            db = ApplicationContext.Instance;
        }

        #region работа с экземляром программы

        /// <summary>
        /// создание новой программы
        /// </summary>
        public void CreateProgram()
        {
            currentTestProgram = new();
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        /// <summary>
        /// додбавить модуль к списку модулей тестовой пограммы
        /// </summary>
        /// <param name="testModule">добавляемый модуль</param>
        public void AddModuleToProgram(TestModule testModule)
        {
            if (changeCurrentTestProgramEnable || changeCycleEnable)
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
            testModule.Priority = currentTestProgram.ModulesList.IndexOf(testModule);
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
                db.TestPrograms?.Update(currentTestProgram);
                db.SaveChanges();
                AddProgramToList(currentTestProgram, name);
            }
            //если мы добавляем новую программу
            else
            {
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

        /// <summary>
        /// удаление тестовой программы из списка и базы данных
        /// </summary>
        /// <param name="indexTestProgram"></param>
        public void DeleteTestProgram(int indexTestProgram)
        {
            db.Remove(TestProgramsList[indexTestProgram]);
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
        
        
        #region работа со списком программ

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

        #endregion

        #region Распознаваание цикл/тестовый модуль

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
                if (changeCycleEnable)
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

        #endregion
        
        #region Работа с циклом
        
        /// <summary>
        /// переключаения редкатирования цикла/ программы
        /// </summary>
        /// <param name="changeProgram">переклюлчатель инициирующий редактиврование текущей цикла</param>
        public void EnabledCycle(bool enableCycle)
        {
            changeCycleEnable = enableCycle;
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
            testModule.Priority = currentCycle.ModulesList.IndexOf(testModule);
            
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        
        public void ChangeCycleToProgram()
        {
            AddModuleToProgram(currentCycle);
            EnabledCycle(false);
        }
        #endregion

        #region предзагрузка из бд

        /// <summary>
        /// загрузка из базы даннных
        /// </summary>
        public void LoadInDb()
        {
            var tempProgramList = db.TestPrograms?.Include(p => p.ModulesList).ThenInclude(m => m.ModulesList).ToList();
            TestProgramsList = tempProgramList;
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

        /// <summary>
        /// вызвает  ивент изменения списка модулей
        /// </summary>
        /// <param name="testProgram">программа в кторой изменятеся список модулей</param>
        public void InvokeModulesListChangedOnProgram(TestProgram testProgram)
        {
            ModulesListChangedOnProgram?.Invoke(testProgram);
        }
        
        #endregion


     
    }
}