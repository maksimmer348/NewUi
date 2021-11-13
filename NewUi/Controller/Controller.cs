using System;
using System.Collections.Generic;
using System.Linq;


namespace NewUi
{
    class Controller
    {
        private readonly ApplicationContext db;


        TestProgram testProgram = new TestProgram();

        /// <summary>
        /// для изменения рабочеей программы
        /// </summary>
        private bool changeTestProgramEnable;

        /// <summary>
        /// список программ
        /// </summary>
        public List<TestProgram> TestProgramsList = new();

        //ивент изменения списка программ
        public event Action<List<TestProgram>> TestProgramsListChanged;

        //ивент изменения списка модулей
        public event Action<TestProgram> ModulesListChangedOnProgram;

        private Cycle Cycle = new Cycle();

        /// <summary>
        /// для работы с циклом
        /// </summary>
        public bool EnableCycle;

        /// <summary>
        /// для изменения цикла
        /// </summary>
        private bool changeCycleEnable;

        /// <summary>
        /// ивент изменения списка модулей
        /// </summary>
        public event Action<Cycle> ModulesListChangedOnCycle;


        public Controller()
        {
            db = ApplicationContext.Instance;
        }

        #region работа с экземляром программы

        /// <summary>
        /// создание новоой программы
        /// </summary>
        public void CreateProgram()
        {
            testProgram = new TestProgram();
            InvokeModulesListChangedOnProgram(testProgram);
        }

        /// <summary>
        /// додбавить модуль к списку модулей тестовой прогнраммы
        /// </summary>
        /// <param name="testModule">добавляемый модуль</param>
        public void AddModuleToProgram(TestModule testModule)
        {
            //обнуляем цикл 
            //Cycle = null;
            //в случае если тестовый модуль это цикл дод./,ё        авляем его в текущий контекст
            if (testModule is Cycle cycle)
            {
                Cycle = cycle;
            }
            //добавляем в текущее свойство модуля текущую пролграмму в кторой он будет находитися
            testModule.TestProgram = testProgram;
            //добавляем в спикос модулей в программе текущщий модуль и заставлляем срабоать ивент
            testProgram.AddModuleToList(testModule);
            InvokeModulesListChangedOnProgram(testProgram);
            //устанавливаем приоритет по умолчанию для модуля 
            testModule.Priority = testProgram.ModulesList.IndexOf(testModule);
        }

        /// <summary>
        /// добавление в базу данных программы с модулями
        /// </summary>
        /// <param name="name">имя программы задается здесь</param>
        public void AddingProgramAndModuleToDb(string name = "")
        {
            testProgram.Name = name;

            foreach (var testModule in testProgram.ModulesList)
            {
                switch (testModule)
                {
                    case ContactCheck contactCheck:
                        switch (changeTestProgramEnable)
                        {
                            //если переклюлчатель изменения false добавить в базу данных новый модуль
                            case false:
                                db.ContactChecks.Add(contactCheck);
                                break;
                            //если переклюлчатель изменения true изменить в базе данных текущий модуль
                            case true:
                                db.ContactChecks.Update(contactCheck);
                                break;
                        }

                        break;

                    case Cycle cycle:
                        switch (changeTestProgramEnable)
                        {
                            case false:
                                db.Cycles.Add(cycle);
                                break;
                            case true:
                                db.Cycles.Update(cycle);
                                break;
                        }

                        break;

                    case DelayBetweenMeasurement delayBetweenMeasurement:
                        switch (changeTestProgramEnable)
                        {
                            case false:
                                db.DelayBetweenMeasurements.Add(delayBetweenMeasurement);
                                break;
                            case true:
                                db.DelayBetweenMeasurements.Update(delayBetweenMeasurement);
                                break;
                        }

                        break;

                    case OutputVoltageMeasure outputVoltageMeasure:
                        switch (changeTestProgramEnable)
                        {
                            case false:
                                db.OutputVoltageMeasures.Add(outputVoltageMeasure);
                                break;
                            case true:
                                db.OutputVoltageMeasures.Update(outputVoltageMeasure);
                                break;
                        }

                        break;

                    case ParamMeasurementTemperature paramMeasurementTemperature:
                        switch (changeTestProgramEnable)
                        {
                            case false:
                                db.ParamMeasurementTemperatures.Add(paramMeasurementTemperature);
                                break;
                            case true:
                                db.ParamMeasurementTemperatures.Update(paramMeasurementTemperature);
                                break;
                        }

                        break;

                    case SetTemperature setTemperature:
                        switch (changeTestProgramEnable)
                        {
                            case false:
                                db.SetTemperatures.Add(setTemperature);
                                break;
                            case true:
                                db.SetTemperatures.Update(setTemperature);
                                break;
                        }

                        break;

                    case SupplyOff supplyOff:
                        switch (changeTestProgramEnable)
                        {
                            case false:
                                db.SupplysOff.Add(supplyOff);
                                break;
                            case true:
                                db.SupplysOff.Update(supplyOff);
                                break;
                        }

                        break;

                    case SupplyOn supplyOn:
                        switch (changeTestProgramEnable)
                        {
                            case false:
                                db.SupplysOn.Add(supplyOn);
                                break;
                            case true:
                                db.SupplysOn.Update(supplyOn);
                                break;
                        }

                        break;
                }
            }

            //если мы добавляем новую программу

            //елси мы меняем программу
            if (changeTestProgramEnable)
            { 
                db.Update(testProgram);
                AddProgramToList(testProgram, name);
            }
            else
            {
                db.Add(testProgram);
                AddProgramToList(testProgram);
            }

            db.SaveChanges();
        }

        /// <summary>
        /// переключаения возможности реадктироавния текущей программы
        /// </summary>
        /// <param name="changeProgram">переклюлчатель инициирующий редактиврование текущей программы</param>
        public void ChangeTestProgram(bool changeProgram)
        {
            changeTestProgramEnable = changeProgram;
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
        /// изменение списка программ
        /// </summary>
        public void InvokeProgramsListChanged()
        {
            TestProgramsListChanged?.Invoke(TestProgramsList);
        }

        /// <summary>
        /// выбор программы из списка программ
        /// </summary>
        /// <param name="index">индекс выбора программы</param>
        public void SelectedTestProgram(int index)
        {
            testProgram = TestProgramsList[index];
            InvokeModulesListChangedOnProgram(testProgram);
        }

        #endregion

        #region предзагрузка из бд

        /// <summary>
        /// загрузка из базы даннных
        /// </summary>
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

            InvokeModulesListChangedOnProgram(TestProgramsList[0]);
        }

        /// <summary>
        /// изменение списка модулей
        /// </summary>
        /// <param name="testProgram">программа в кторой изменятеся список модулей</param>
        public void InvokeModulesListChangedOnProgram(TestProgram testProgram)
        {
            ModulesListChangedOnProgram?.Invoke(testProgram);
        }

        /// <summary>
        /// создание программы по умоллчанию и базы данных, если база данных програм еще не создана
        /// </summary>
        public void Load()
        {
            //если в бд нинчего нет или она не существует, создаем одну запись по умолчанию 
            // и добавляем ее в бд
            if (db.TestPrograms == null || !db.TestPrograms.Any())
            {
                CreateProgram();
                AddModuleToProgram(ContactCheck.Default);
                AddingProgramAndModuleToDb("По Умолчанию");
            }
            //или же зугржэаем данные из базы данных
            else
            {
                LoadInDb();
            }
        }

        #endregion

        /// <summary>
        /// переключенние режима редактирование программы/цикла
        /// </summary>
        /// <param name="mode">режим программа/цикл</param>
        public void ModeProgramOrCycle(ModeEdit mode)
        {
            EnableCycle = mode == ModeEdit.Cycle;
        }

        #region Работа с циклом

        /// <summary>
        /// добавление модуля в цикл
        /// </summary>
        /// <param name="testModule">модуль</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddModuleToCycle(TestModule testModule)
        {
            //добавляем в текущее свойство модуля текущий цикл в ктором он будет находитися
            testModule.Cycle = Cycle;
            //добавляем в спикос модулей в цикле текущий модуль и заставлляем срабоать ивент
            Cycle.AddModuleToList(testModule);
            InvokeModulesListChangedOnCycle(Cycle);
            //устанавливаем приоритет по умолчанию для модуля
            testModule.Priority = Cycle.ModulesList.IndexOf(testModule);
        }

        public void InvokeModulesListChangedOnCycle(Cycle cycle)
        {
            ModulesListChangedOnCycle?.Invoke(cycle);
        }

        public void AddingCucleAndModuleToDb()
        {
            foreach (var testModule in Cycle.ModulesList)
            {
                switch (testModule)
                {
                    case DelayBetweenMeasurement delayBetweenMeasurement:
                        switch (changeCycleEnable)
                        {
                            case false:
                                db.DelayBetweenMeasurements.Add(delayBetweenMeasurement);
                                break;
                            case true:
                                db.DelayBetweenMeasurements.Update(delayBetweenMeasurement);
                                break;
                        }

                        break;

                    case OutputVoltageMeasure outputVoltageMeasure:
                        switch (changeCycleEnable)
                        {
                            case false:
                                db.OutputVoltageMeasures.Add(outputVoltageMeasure);
                                break;
                            case true:
                                db.OutputVoltageMeasures.Update(outputVoltageMeasure);
                                break;
                        }

                        break;

                    case ParamMeasurementTemperature paramMeasurementTemperature:
                        switch (changeCycleEnable)
                        {
                            case false:
                                db.ParamMeasurementTemperatures.Add(paramMeasurementTemperature);
                                break;
                            case true:
                                db.ParamMeasurementTemperatures.Update(paramMeasurementTemperature);
                                break;
                        }

                        break;
                }
               
                db.SaveChanges();
                Cycle = null;
            }
        }

        #endregion
    }
}