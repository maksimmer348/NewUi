using Microsoft.EntityFrameworkCore;

namespace NewUi
{
    class Controller
    {
        private readonly ApplicationContext db;
        // private UiController uiController = new();

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
        /// <param name="testModule">добавляемый модуль</param>
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
            testModule.Priority = SetPriorityModule(testModule, ModeEdit.Program);


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
        /// переключение редкатирования цикла
        /// </summary>
        /// <param name="enableCycle">перелючатель редактирования цикла</param>
        public void EnabledEditingCycle(bool enableCycle)
        {
            ChangeCycleEnable = enableCycle;
        }

        /// <summary>
        /// создание цикла
        /// </summary>
        /// <param name="testModule">модуль цикла</param>
        public void CreateCycle(TestModule testModule)
        {
            if (testModule is Cycle cycle)
            {
                currentCycle = cycle;

                AddModuleToProgram(currentCycle);
                EnabledEditingCycle(true);
            }
        }

        /// <summary>
        /// добавление модуля в цикл
        /// </summary>
        /// <param name="testModule">модуль</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddModuleToCycle(TestModule testModule)
        {
            //добавляем в список модулей в цикле, текущий модуль и заставляем сработать ивент
            currentCycle.AddModuleToList(testModule);
            //устанавливаем приоритет по умолчанию для модуля
            testModule.Priority = SetPriorityModule(testModule, ModeEdit.Cycle);
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        /// <summary>
        ///записываем текущий цикл со всеми внтуреними модулями в текущую программу
        /// </summary>
        public void ChangeCycleToProgram()
        {
            AddModuleToProgram(currentCycle);
            EnabledEditingCycle(false);
        }

        #endregion


        #region работа со списком модулей

        /// <summary>
        ///  ивент изменения списка модулей
        /// </summary>
        public event Action<TestProgram> ModulesListChangedOnProgram;

        /// <summary>
        /// определение входящего модуля
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
        /// вызвает ивент изменения списка модулей
        /// </summary>
        /// <param name="testProgram">программа в кторой изменятеся список модулей</param>
        public void InvokeModulesListChangedOnProgram(TestProgram testProgram)
        {
            ModulesListChangedOnProgram?.Invoke(testProgram);
        }

        /// <summary>
        /// получить значение приоритет по умолчанию для модуля
        /// </summary>
        /// <param name="testModule">модуль</param>
        /// <param name="modeEdit">переклюлчатьель режима программа/цикл</param>
        /// <returns></returns>
        int SetPriorityModule(TestModule testModule, ModeEdit modeEdit)
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

        List<TestModule> SetPrioritiesModules(List<TestModule> testModules)
        {
            foreach (var testModule in testModules)
            {
                testModule.Priority = testModules.IndexOf(testModule);
            }
            return testModules;
        }

        /// <summary>
        /// сортировка списка модулей
        /// </summary>
        /// <param name="testModulesList">списко модулей</param>
        /// <param name="modeEdit">переключатель режима программа/цикл</param>
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

        //TODO уменьщитиь метод вдвое
        /// <summary>
        /// выбор модуля по индексу из программы или цикла, и его перемещение
        /// </summary>
        /// <param name="indexModule">индекс модуля из dGridModulesList</param>
        /// <param name="mode">прееклуючатель режима выбора и перемещения модуля в программе/цикле</param>
        /// <param name="move">направление перемещения модуля</param>
        public int SelectedAndMoveModule(int indexModule, ModeEdit mode, MoveDirection move)
        {
            var index = 0;
            List<TestModule> tempList = null;
            TestModule item = null;
            tempList = currentTestProgram.ModulesList;
            
            index = tempList.FindIndex(s => s.Index == indexModule);
            var upIndex = index - 1;
            var downIndex = index + 1;
            
            if (index != -1)
            {
                item = tempList[index];

                if (move == MoveDirection.Up)
                {
                    if (index > 0)
                    {
                        tempList.RemoveAt(index);
                        tempList.Insert(upIndex, item);
                        currentTestProgram.ModulesList = SetPrioritiesModules(tempList);   
                        //if (item != null) item.Priority = SetPriorityModule(item, ModeEdit.Program);
                        //currentTestProgram.ModulesList = tempList;
                        InvokeModulesListChangedOnProgram(currentTestProgram);
                        index = item.Index;
                    }
                }
                else if (move == MoveDirection.Down)
                {
                    if (index < tempList.Count -1)
                    {
                        tempList.RemoveAt(index);
                        tempList.Insert(downIndex, item);
                        currentTestProgram.ModulesList = SetPrioritiesModules(tempList);   
                        //if (item != null) item.Priority = SetPriorityModule(item, ModeEdit.Program);
                        //currentTestProgram.ModulesList = tempList;
                        InvokeModulesListChangedOnProgram(currentTestProgram);
                        index = item.Index;
                    }
                }
                else if(move == MoveDirection.Delete)
                {
                    tempList.RemoveAt(index);
                    currentTestProgram.ModulesList = SetPrioritiesModules(tempList);   
                    //if (item != null) item.Priority = SetPriorityModule(item, ModeEdit.Program);
                    //currentTestProgram.ModulesList = tempList;
                    InvokeModulesListChangedOnProgram(currentTestProgram);
                }
            }
            else
            {
                for (var i = 0; i < currentTestProgram.ModulesList.Count; i++)
                {
                    tempList = currentTestProgram.ModulesList[i].ModulesList;
                    index = tempList.FindIndex(s => s.Index == indexModule);
                    upIndex = index - 1;
                    downIndex = index + 1;
                    
                    if (index != -1)
                    {
                        if (move == MoveDirection.Up)
                        {
                            if (index > 0)
                            {
                                item = tempList[index];
                                tempList.RemoveAt(index);
                                tempList.Insert(upIndex, item);
                                currentTestProgram.ModulesList[i].ModulesList = SetPrioritiesModules(tempList);   
                                //currentTestProgram.ModulesList[i].ModulesList = tempList;
                                InvokeModulesListChangedOnProgram(currentTestProgram);
                                return item.Index;
                            }
                        }
                        else if (move == MoveDirection.Down)
                        {
                            if (index < tempList.Count -1)
                            {
                                item = tempList[index];
                                tempList.RemoveAt(index);
                                tempList.Insert(downIndex, item);
                                currentTestProgram.ModulesList[i].ModulesList = SetPrioritiesModules(tempList); 
                                //currentTestProgram.ModulesList[i].ModulesList = tempList;
                                InvokeModulesListChangedOnProgram(currentTestProgram);
                                return item.Index;
                            }
                        }
                        else if (move == MoveDirection.Delete)
                        {
                            
                                item = tempList[index];
                                tempList.RemoveAt(index);
                                currentTestProgram.ModulesList[i].ModulesList = SetPrioritiesModules(tempList); 
                                //currentTestProgram.ModulesList[i].ModulesList = tempList;
                                InvokeModulesListChangedOnProgram(currentTestProgram);
                               
                            
                        }
                    }
                }
            }

            return index;
        }

        #endregion


        
        #region работа со списком программ

        public List<TestProgram> TestProgramsList = new();

        /// <summary>
        ///  ивент изменения списка программ
        /// </summary>
        public event Action<List<TestProgram>> TestProgramsListChanged;

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
            //
            try
            {
                currentTestProgram = TestProgramsList[index];
                InvokeModulesListChangedOnProgram(currentTestProgram);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Выберите элемент");
            }
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
            if (tempProgramList != null)
                foreach (var testProgram in tempProgramList)
                {
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