using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace NewUi
{
    public class TestProgram
    {
        public int Id { get; set; }
        
        //меняем или изменяем имя вызывается ивент
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
      
        
         public List<TestModule> ModulesList = new();
        /// <summary>
        /// положвить один модуль в программу
        /// </summary>
        /// <param name="module">модуль</param>
        public void AddModuleToList(TestModule module)
        {
            if (module!= null)
            {
                ModulesList.Add(module);
            }
        }
        
        /// <summary>
        ///  положить списко модулей в програамму
        /// </summary>
        /// <param name="modulesLists">список модулей</param>
        public void AddModulesToList(params IEnumerable<TestModule>[] modulesLists)
        {
            List<TestModule> tempList = new();
            foreach (var modulesList in modulesLists)
            {
                if (modulesList != null || modulesList.Any())
                {
                    foreach (var module in modulesList)
                    {
                        tempList.Add(module);
                    }
                    ModulesList = tempList.OrderBy(m => m.Priority).ToList();
                    
                }
            }
        }
    }


}