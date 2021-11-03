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
        
        //временный сискок для модулей до создания программы
        public List<TestModule> ModuleTempList = new List<TestModule>();

        
        // #region работа со списком программ
        //
        // public event Action<List<TestProgram>> TestProgramsListChanged;
        // private List<TestProgram> testProgramsList = new List<TestProgram>();
        //
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
        //
        // #endregion
        //
       
        //
        //
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
        
        //загрузка программм и модулей в форму TODO поменять
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


            // program.ModulesList = ModuleTempList;
            // //очищаем временный список он больше ненужен
            // //ModuleTempList.Clear();
            // //присваиваем в модули из списка текущей программы принадлежность к текущей программе
            // foreach (var module in program.ModulesList)
            // {
            //     module.TestProgram = program;
            //     ModuleInDB(module);
            // }
            // TestProgramsList.Add(program);
            // OnTestProgramsChanged();
        }

        public void AddingModuleToProgram(TestModule testModule)
        {
            testModule.TestProgram = program;
            program.ModulesList.Add(testModule);
        }
        public void AddingProgramToDb(string name)
        {
            foreach (var testModule in program.ModulesList)
            {
                if (testModule is ContactCheck cc)
                {
                    db.ContactChecks.Add(cc);
                }
                if (testModule is SupplyOn so)
                {
                    db.SupplysOn.Add(so);
                }
            }
            db.Add(program);
            db.SaveChanges();
        }
    }
}