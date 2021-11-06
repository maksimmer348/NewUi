using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace NewUi
{
    class Controller
    {
        private readonly ApplicationContext db;

        TestProgram Program = new TestProgram();

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
            Program = new TestProgram();
        }

        /// <summary>
        /// додбавить модуль к списку модулей тестовой прогнраммы
        /// </summary>
        /// <param name="testModule">модуль</param>
        public void AddingModuleToProgram(TestModule testModule)
        {
            //добавляем в текущее свойство модуля текущую пролграмму в кторой он будет находитися
            testModule.TestProgram = Program;
            //добавляем в спикос модулей в программе текущщий модуль и заставлляем срабоать ивент
            Program.AddModuleToList(testModule);
            InvokeModulesListChanged(Program);
            //устанавливаем приоритет по умолчанию для модуля
            testModule.Priority = Program.ModulesList.IndexOf(testModule);
        }

        /// <summary>
        /// добавление в базу данных программы с модулями
        /// </summary>
        /// <param name="name">имя программы</param>
        public void AddingProgramAndModuleToDb(string name)
        {
            Program.Name = name;
            foreach (var testModule in Program.ModulesList)
            {
                switch (testModule)
                {
                    case ContactCheck contactCheck:
                        db.ContactChecks.Add(contactCheck);
                        break;
                    case Cycle cycle:
                        db.Cycles.Add(cycle);
                        break;
                    case DelayBetweenMeasurement delayBetweenMeasurement:
                        db.DelayBetweenMeasurements.Add(delayBetweenMeasurement);
                        break;
                    case OutputVoltageMeasure outputVoltageMeasure:
                        db.OutputVoltageMeasures.Add(outputVoltageMeasure);
                        break;
                    case ParamMeasurementTemperature paramMeasurementTemperature:
                        db.ParamMeasurementTemperatures.Add(paramMeasurementTemperature);
                        break;
                    case SetTemperature setTemperature:
                        db.SetTemperatures.Add(setTemperature);
                        break;
                    case SupplyOff supplyOff:
                        db.SupplysOff.Add(supplyOff);
                        break;
                    case SupplyOn supplyOn:
                        db.SupplysOn.Add(supplyOn);
                        break;
                }
            }

            db.Add(Program);
            db.SaveChanges();
            AddProgramToList(Program);
        }

        #endregion
        

        #region работа со списком программ

        public List<TestProgram> TestProgramsList = new();

        public void AddProgramToList(TestProgram TestProgram)
        {
            TestProgramsList.Add(TestProgram);
            InvokeProgramsListChanged();
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
            Program = TestProgramsList[index];
            InvokeModulesListChanged(Program);
        }

        #endregion
      
    }
}