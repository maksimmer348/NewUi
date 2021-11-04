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
        private TestProgram program;

        public Controller()
        {
            db = ApplicationContext.Instance;
        }

        // public event Action<TestModule> SelectedTestProgramModulesChanged;
        // private TestModule selectedTestProgramModules;
        // public TestModule SelectedTestProgramModules
        // {
        //     get => selectedTestProgramModules;
        //     set
        //     {
        //         selectedTestProgramModules = value;
        //         OnSelectedTestProgramModulesChanged();
        //     }
        // }
        // public void OnSelectedTestProgramModulesChanged()
        // {
        //     db.UpdateRange();
        //     SelectedTestProgramModulesChanged?.Invoke(SelectedTestProgramModules);
        //     db.SaveChanges();
        // }
        //загрузка программм и модулей в форму TODO поменять?
        // public void Load()
        // {
        //     TestProgramsList = db.TestPrograms.Include(e => e.ModulesList).ToList();
        // }

        #region выбор экземпляра программы

        // public event Action<TestProgram> SelectedTestProgramChanged;
        // private TestProgram selectedTestProgram;
        //
        // public TestProgram SelectedTestProgram
        // {
        //     get => selectedTestProgram;
        //     set
        //     {
        //         selectedTestProgram = value;
        //         OnSelectedTestProgramsChanged();
        //     }
        // }
        //
        // public void OnSelectedTestProgramsChanged()
        // {
        //     SelectedTestProgramChanged?.Invoke(SelectedTestProgram);
        //     db.SaveChanges();
        // }

        #endregion

        public void CreateProgram()
        {
            //создаем новую программу
            program = new TestProgram();
        }

        public void AddingModuleToProgram(TestModule testModule)
        {
            //добавляем в текущее свойство модуля текущую пролграмму в кторой он будет находитися
            testModule.TestProgram = program;
            //добавляем в спикос модулей в программе текущщий модуль и заставлляем срабоать ивент
            program.AddModuleToList(testModule);
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

            //TestProgramsList.Add(program);
            db.Add(program);
            db.SaveChanges();
            AddProgramToList(program);
        }

        #region работа со списком программ

        public event Action<List<TestProgram>> TestProgramsListChanged;
        public List<TestProgram> TestProgramsList = new();

        public void AddProgramToList(TestProgram TestProgram)
        {
            TestProgramsList.Add(TestProgram);
            InvokeModulesListChanged();
        }

        public void InvokeModulesListChanged()
        {
            TestProgramsListChanged?.Invoke(TestProgramsList);
        }

        // public List<TestProgram> TestProgramsList
        // {
        //     get => testProgramsList;
        //     set
        //     {
        //         testProgramsList = value;
        //         OnTestProgramsChanged();
        //     }
        // }
        //
        // public void OnTestProgramsChanged()
        // {
        //     db.TestPrograms.UpdateRange(testProgramsList);
        //     db.SaveChanges();
        //     TestProgramsListChanged?.Invoke(TestProgramsList);
        // }

        #endregion

        void LoadInDB()
        {
            var tempProgramList = db.TestPrograms.ToList();
            foreach (var testProgram in tempProgramList)
            {
                var contactCheck = db.ContactChecks.Where(cc => cc.TestProgramId == testProgram.Id).ToList();
                var cycle = db.Cycles.Where(c => c.TestProgramId == testProgram.Id).ToList();
                var delayBetweenMeasurement = db.DelayBetweenMeasurements.Where(dbm => dbm.TestProgramId == testProgram.Id).ToList();
                var outputVoltageMeasure = db.OutputVoltageMeasures.Where(dbm => dbm.TestProgramId == testProgram.Id).ToList();
                var paramMeasurementTemperature = db.ParamMeasurementTemperatures .Where(pmt => pmt.TestProgramId == testProgram.Id).ToList();
                var setTemperature = db.SetTemperatures.Where(dbm => dbm.TestProgramId == testProgram.Id).ToList();
                var supplyOff = db.SupplysOff.Where(off => off.TestProgramId == testProgram.Id).ToList();
                var supplyOn = db.SupplysOn.Where(on => on.TestProgramId == testProgram.Id).ToList();
                //testProgram.AddModuleToList(contactCheck);
                //
                AddProgramToList(testProgram);
            }
        }

        public void Load()
        {

            LoadInDB();
            if (TestProgramsList == null || TestProgramsList.Count < 1)
            {
                CreateProgram();
                AddingModuleToProgram(ContactCheck.Default);
                AddingProgramAndModuleToDb("По Умолчанию");
            }
        }
    }
}