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
        public Controller()
        {
            db = ApplicationContext.Instance;
        }

        public List<TestModule> ModuleTempList = new List<TestModule>();
        
        //работа со списком программ
        public event Action<List<TestProgram>> TestProgramsListChanged;
        private List<TestProgram> testProgramsList;
        public List<TestProgram> TestProgramsList
        {
            get => testProgramsList;
            set
            {
                testProgramsList = value;
                OnTestProgramsChanged();
            }
        }
        public void OnTestProgramsChanged()
        {
            
            db.TestPrograms.UpdateRange(testProgramsList);
            db.SaveChanges();
            TestProgramsListChanged?.Invoke(TestProgramsList);
        }
        
        //выбор экземпляра программы
        public event Action<TestProgram> SelectedTestProgramChanged;
        private TestProgram selectedTestProgram;
        public TestProgram SelectedTestProgram
        {
            get => selectedTestProgram;
            set
            {
                selectedTestProgram = value;
                OnSelectedTestProgramsChanged();
            }
        }
        public void OnSelectedTestProgramsChanged()
        {
            SelectedTestProgramChanged?.Invoke(SelectedTestProgram);
            db.SaveChanges();
        }
        
        public void ContactCheck(TestProgram testProgram)
        {
           
           
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
        //     db..UpdateRange();
        //     SelectedTestProgramModulesChanged?.Invoke(SelectedTestProgramModules);
        //     db.SaveChanges();
        // }
        //
        //загрузка программм и модулей в форму TODO поменять
        public void Load()
        {
            TestProgramsList = db.TestPrograms.Include(e=>e.ModulesList).ToList();
        }
        
       
    }
}