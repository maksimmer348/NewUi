using System;
using System.Collections.Generic;

namespace NewUi
{
    public class TestProgram
    {
        public int Id { get; set; }

        //устанавлиаем имя программы срабатывает ивент
        // public event Action<string> NameChanged;
        //private string _name;
        public string Name { get; set; }
        // {
        //     get => _name;
        //     set
        //     {
        //         if (_name != value)
        //         {
        //             _name = value;
        //             NameChanged?.Invoke(Name);
        //         }
        //     }
        // }
        
        
        //меняем список из модулей срабатывает ивент
        public event Action<List<TestModule>> ModulesListChanged;
        public List<TestModule> ModulesList { get; set; } = new();
        
        public void InvokeModulesListChanged()
        {
            ModulesListChanged?.Invoke(ModulesList);
        }

    }
}