using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NewUi
{
    class TestProgramController
    {
        private readonly ApplicationContext db;
    
        public TestProgram TestProgram = new TestProgram();
        
    
        public event Action<List<TestProgram>> TestProgramsListChanged;
        public event Action<TestProgram> SelectedTestProgramChanged;
        
        private List<TestProgram> testProgramsList;
        private TestProgram selectedTestProgram;
        
        public List<TestProgram> TestProgramsList
        {
            get => testProgramsList;
            set
            {
                testProgramsList = value;
                OnTestProgramsChanged();
            }
        }
        
        public TestProgram SelectedTestProgram
        {
            get => selectedTestProgram;
            set
            {
                selectedTestProgram = value;
                OnSelectedTestProgramsChanged();
            }
        }
        
        public TestProgramController()
        {
            db = ApplicationContext.Instance;
        }
        
        
        public void Load()
        {
            TestProgramsList = db.TestPrograms.Include(e=>e.ModulesList).ToList();
        }
        
        public void OnTestProgramsChanged()
        {
            
            db.TestPrograms.UpdateRange(testProgramsList);
            db.SaveChanges();
            
            TestProgramsListChanged?.Invoke(TestProgramsList);
            
        }
        
        
        public void OnSelectedTestProgramsChanged()
        {
            SelectedTestProgramChanged?.Invoke(SelectedTestProgram);
            db.SaveChanges();
        }
    }
}