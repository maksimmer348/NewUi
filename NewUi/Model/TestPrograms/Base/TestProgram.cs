using System;
using System.Collections.Generic;

namespace NewUi
{
    public class TestProgram
    {
        public int Id { get; set; }

        private string _name;
        public event Action<string> NameChanged;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;

                    NameChanged?.Invoke(Name);
                }
            }
        }
        
        public event Action<List<TestModule>> ModulesListChanged;
        public List<TestModule> ModulesList { get; set; } = new();
        
        public void InvokeModulesListChanged()
        {
            ModulesListChanged?.Invoke(ModulesList);
        }

    }
}