using System;
using System.Collections.Generic;
using System.Linq;


namespace NewUi
{
    class Controller
    {
        private readonly ApplicationContext db;

        TestProgram program = new TestProgram();

        private bool changeTestProgramEnable;

        //ивент изменения списка модулей
        public event Action<TestProgram> ModulesListChanged;

        //ивент изменения списка программ
        public event Action<List<TestProgram>> TestProgramsListChanged;

        public Controller()
        {
            db = ApplicationContext.Instance;
        }

        #region работа с экземляром программы

        //создаем новую программу
        public void CreateProgram()
        {
            program = new TestProgram();
            InvokeModulesListChanged(program);
        }

        /// <summary>
        /// додбавить модуль к списку модулей тестовой прогнраммы
        /// </summary>
        /// <param name="testModule">модуль</param>
        public void AddingModuleToProgram(TestModule testModule)
        {
            //добавляем в текущее свойство модуля текущую пролграмму в кторой он будет находитися
            testModule.TestProgram = program;
            //добавляем в спикос модулей в программе текущщий модуль и заставлляем срабоать ивент
            program.AddModuleToList(testModule);
            InvokeModulesListChanged(program);
            //устанавливаем приоритет по умолчанию для модуля
            testModule.Priority = program.ModulesList.IndexOf(testModule);
        }

        /// <summary>
        /// добавление в базу данных программы с модулями
        /// </summary>
        /// <param name="name">имя программы</param>
        public void AddingProgramAndModuleToDb(string name)
        {
            program.Name = name;
            foreach (var testModule in program.ModulesList)
            {
                switch (testModule)
                {
                    case ContactCheck contactCheck:
                        if (!changeTestProgramEnable)
                        {
                            db.ContactChecks.Add(contactCheck);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.ContactChecks.Update(contactCheck);
                        }
                        
                        break;
                    case Cycle cycle:
                        if (!changeTestProgramEnable)
                        {
                            db.Cycles.Add(cycle);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.Cycles.Update(cycle);
                        }
                        
                        break;
                    case DelayBetweenMeasurement delayBetweenMeasurement:
                        if (!changeTestProgramEnable)
                        {
                            db.DelayBetweenMeasurements.Add(delayBetweenMeasurement);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.DelayBetweenMeasurements.Update(delayBetweenMeasurement);
                        }
                        
                        break;
                    case OutputVoltageMeasure outputVoltageMeasure:
                        if (!changeTestProgramEnable)
                        {
                            db.OutputVoltageMeasures.Add(outputVoltageMeasure);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.OutputVoltageMeasures.Update(outputVoltageMeasure);
                        }
                        
                        break;
                    case ParamMeasurementTemperature paramMeasurementTemperature:
                        if (!changeTestProgramEnable)
                        {
                            db.ParamMeasurementTemperatures.Add(paramMeasurementTemperature);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.ParamMeasurementTemperatures.Update(paramMeasurementTemperature);
                        }
                        
                        break;
                    case SetTemperature setTemperature:
                        if (!changeTestProgramEnable)
                        {
                            db.SetTemperatures.Add(setTemperature);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.SetTemperatures.Update(setTemperature);
                        }

                        break;
                    case SupplyOff supplyOff:
                        if (!changeTestProgramEnable)
                        {
                            db.SupplysOff.Add(supplyOff);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.SupplysOff.Update(supplyOff);
                        }
                        
                        break;
                    case SupplyOn supplyOn:
                        if (!changeTestProgramEnable)
                        {
                            db.SupplysOn.Add(supplyOn);
                        }

                        if (changeTestProgramEnable)
                        {
                            db.SupplysOn.Update(supplyOn);
                        }
                        
                        break;
                }
            }

            //если мы добавляем новую программу
            if (!changeTestProgramEnable)
            {
                db.Add(program);
                AddProgramToList(program);
            }

            //елси мы меняем программу
            if (changeTestProgramEnable)
            {
                db.Update(program);
                AddProgramToList(program, name);
            }

            db.SaveChanges();
        }

        #endregion


        #region работа со списком программ

        public List<TestProgram> TestProgramsList = new();

        public void AddProgramToList(TestProgram testProgram, string newNameProgram = "")
        {
            var tempTestProgram = TestProgramsList.FirstOrDefault(pr => pr.Id == testProgram.Id);

            if (tempTestProgram == null)
            {
                TestProgramsList.Add(testProgram);
                InvokeProgramsListChanged();
            }

            if (tempTestProgram != null)
            {
                tempTestProgram.Name = newNameProgram;
                InvokeProgramsListChanged();
            }
        }

        public void InvokeProgramsListChanged()
        {
            TestProgramsListChanged?.Invoke(TestProgramsList);
        }

        #endregion

        #region предззагрузка из бд

        public void LoadInDb()
        {
            //полулчаем список программ из базы данных
            var tempProgramList = db.TestPrograms.ToList();
            //получаем модули из списка программ
            foreach (var testProgram in tempProgramList)
            {
                var contactCheck = db.ContactChecks.Where(cc => cc.TestProgramId == testProgram.Id).ToList();
                var cycle = db.Cycles.Where(c => c.TestProgramId == testProgram.Id).ToList();
                var delayBetweenMeasurement = db.DelayBetweenMeasurements
                    .Where(dbm => dbm.TestProgramId == testProgram.Id).ToList();
                var outputVoltageMeasure =
                    db.OutputVoltageMeasures.Where(dbm => dbm.TestProgramId == testProgram.Id).ToList();
                var paramMeasurementTemperature = db.ParamMeasurementTemperatures
                    .Where(pmt => pmt.TestProgramId == testProgram.Id).ToList();
                var setTemperature = db.SetTemperatures.Where(dbm => dbm.TestProgramId == testProgram.Id).ToList();
                var supplyOff = db.SupplysOff.Where(off => off.TestProgramId == testProgram.Id).ToList();
                var supplyOn = db.SupplysOn.Where(on => on.TestProgramId == testProgram.Id).ToList();
                //добавляем модули в testProgram 
                testProgram.AddModulesToList(contactCheck, cycle, delayBetweenMeasurement, outputVoltageMeasure,
                    paramMeasurementTemperature,
                    setTemperature, supplyOff, supplyOn);
                // добавляем testProgram 
                AddProgramToList(testProgram);
            }

            InvokeModulesListChanged(TestProgramsList[0]);
        }

        public void InvokeModulesListChanged(TestProgram testProgram)
        {
            ModulesListChanged?.Invoke(testProgram);
        }

        public void Load()
        {
            //если в бд нинчего нет или она не существует, создаем одну запись по умолчанию 
            // и добавляем ее в бд
            if (db.TestPrograms == null || !db.TestPrograms.Any())
            {
                CreateProgram();
                AddingModuleToProgram(ContactCheck.Default);
                AddingProgramAndModuleToDb("По Умолчанию");
            }
            //или же зугржэаем данные из базы данных
            else
            {
                LoadInDb();
            }
        }

        /// <summary>
        /// выбор программы из списка программ
        /// </summary>
        /// <param name="index">индекс выбора программы</param>
        public void SelectedTestProgram(int index)
        {
            program = TestProgramsList[index];
            InvokeModulesListChanged(program);
        }

        #endregion

        /// <summary>
        /// переключаения возможности реадктироавния текущей программы
        /// </summary>
        /// <param name="changeProgram"></param>
        public void ChangeTestProgram(bool changeProgram)
        {
            changeTestProgramEnable = changeProgram;
        }

        public void DeleteTestProgram(int indexTestProgram)
        {
            db.Remove(TestProgramsList[indexTestProgram]);
            db.SaveChanges();
            TestProgramsList.RemoveAt(indexTestProgram);
            InvokeProgramsListChanged();
           
        }
    }
}