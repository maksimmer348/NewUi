using System;
using System.Collections.Generic;
using System.Linq;


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
        public List<TestProgram> TestProgramsList = new();

        /// <summary>
        ///  ивент изменения списка программ
        /// </summary>
        public event Action<List<TestProgram>> TestProgramsListChanged;

        /// <summary>
        ///  ивент изменения списка модулей
        /// </summary>
        public event Action<TestProgram> ModulesListChangedOnProgram;

        private Cycle currentCycle = new();

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
            currentTestProgram = new();
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        /// <summary>
        /// додбавить модуль к списку модулей тестовой прогнраммы
        /// </summary>
        /// <param name="testModule">добавляемый модуль</param>
        public void AddModuleToProgram(TestModule testModule)
        {
            //обнуляем цикл 
            //Cycle = null;
            //в случае если тестовый модуль это цикл добавляем его в текущий контекст
            if (testModule is Cycle cycle)
            {
                currentCycle = cycle;
            }

            //добавляем в текущее свойство модуля текущую программу в кторой он будет находитися
            testModule.TestProgram = currentTestProgram;
            
            //добавляем в спикок модулей в программе текущий модуль 
            currentTestProgram.AddModuleToList(testModule);
            //ивент обновляющий модули в списке модулей
            InvokeModulesListChangedOnProgram(currentTestProgram);
            
            //устанавливаем приоритет по умолчанию для модуля 
            testModule.Priority = currentTestProgram.ModulesList.IndexOf(testModule);
        }

        /// <summary>
        /// добавление в базу данных программы с модулями
        /// </summary>
        /// <param name="name">имя программы задается здесь</param>
        public void AddingProgramAndModuleToDb(string name = "")
        {
            currentTestProgram.Name = name;

            foreach (var testModule in currentTestProgram.ModulesList)
            {
                switch (testModule)
                {
                    case ContactCheck contactCheck:
                        // if (contactCheck.Id == 0)
                        // {
                        //     db.ContactChecks.Add(contactCheck);
                        // }
                        // if (contactCheck.Id > 0)
                        // {
                        //     db.ContactChecks.Update(contactCheck);
                        // }
                        switch (changeCurrentTestProgramEnable)
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
                        switch (changeCurrentTestProgramEnable)
                        {
                            case false:
                                db.Cycles.Add(cycle);
                                break;
                            case true:
                                //1.костыль непонятное поведение спросить у темы
                                if (cycle.Id == 0)
                                    db.Cycles.Add(cycle);
                                else
                                    db.Cycles.Update(cycle);
                                break;
                        }

                        break;

                    case DelayBetweenMeasurement delayBetweenMeasurement:
                        switch (changeCurrentTestProgramEnable)
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
                        switch (changeCurrentTestProgramEnable)
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
                        switch (changeCurrentTestProgramEnable)
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
                        switch (changeCurrentTestProgramEnable)
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
                        switch (changeCurrentTestProgramEnable)
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
                        switch (changeCurrentTestProgramEnable)
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

            //елси мы меняем программу
            if (changeCurrentTestProgramEnable)
            {
                db.Update(currentTestProgram);
                AddProgramToList(currentTestProgram, name);
            }
            //если мы добавляем новую программу
            else
            {
                db.Add(currentTestProgram);
                AddProgramToList(currentTestProgram);
            }

            db.SaveChanges();
        }

        /// <summary>
        /// переключаения возможности реадктироавния текущей программы
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
            currentTestProgram = TestProgramsList[index];
            InvokeModulesListChangedOnProgram(currentTestProgram);
        }

        #endregion

        #region предзагрузка из бд

        /// <summary>
        /// загрузка из базы даннных
        /// </summary>
        public void LoadInDb()
        {
            //полулчаем список программ из базы данных
            var tempProgramsList = db.TestPrograms.ToList();
            //получаем модули из списка программ
            foreach (var testProgram in tempProgramsList)
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

            var tempCyclesList = db.Cycles.ToList();
            foreach (var cycle in tempCyclesList)
            {
                var delayBetweenMeasurement = db.DelayBetweenMeasurements
                    .Where(dbm => dbm.TestProgramId == cycle.Id).ToList();
                var outputVoltageMeasure =
                    db.OutputVoltageMeasures.Where(dbm => dbm.TestProgramId == cycle.Id).ToList();
                var paramMeasurementTemperature = db.ParamMeasurementTemperatures
                    .Where(pmt => pmt.TestProgramId == cycle.Id).ToList();
                cycle.AddModulesToList(delayBetweenMeasurement, outputVoltageMeasure,
                    paramMeasurementTemperature);
            }

            //отображаем при запуске первую програамму 
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
            testModule.Cycle = currentCycle;

            //добавляем в список модулей в цикле, текущий модуль и заставлляем срабоать ивент
            currentCycle.AddModuleToList(testModule);
            InvokeModulesListChangedOnCycle(currentCycle);
            //устанавливаем приоритет по умолчанию для модуля
            testModule.Priority = currentCycle.ModulesList.IndexOf(testModule);
        }

        /// <summary>
        /// изменение списка модулей в цикле
        /// </summary>
        /// <param name="cycle">цикл в ктотором изменятеся список модулей</param>
        public void InvokeModulesListChangedOnCycle(Cycle cycle)
        {
            ModulesListChangedOnCycle?.Invoke(cycle);
        }

        public void AddingModuleCycleToDb()
        {
            foreach (var testModule in currentCycle.ModulesList)
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

                //  db.SaveChanges();
                currentCycle = null;
            }
        }

        #endregion
    }
}