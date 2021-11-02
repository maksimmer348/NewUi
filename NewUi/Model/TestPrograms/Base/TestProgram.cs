using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace NewUi
{
    public class TestProgram
    {
        public int Id { get; set; }
        
        //меняем или ищменяем имя вызывается ивент
        public event Action<string> NameChanged;
        private string _name;
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
        //меняем список из модулей срабатывает ивент
        public event Action<List<TestModule>> ModulesListChanged;
        
         public void InvokeModulesListChanged()
         {
             ModulesListChanged?.Invoke(ModulesList);
         }
        public List<TestModule> ModulesList = new();
        public void AddModule(TestModule module)
        {
            ModulesList.Add(module);
        }
    }


}