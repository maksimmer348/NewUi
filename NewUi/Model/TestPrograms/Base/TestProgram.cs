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

        /// <summary>
        /// список модулей
        /// </summary>
        public List<TestModule> ModulesList = new();

      
        /// <summary>
        /// добаавить один модуль в программу
        /// </summary>
        /// <param name="module">добаавляемый модуль</param>
        public void AddModuleToList(TestModule module)
        {
            if (module != null)
            {
                ModulesList.Add(module);
            }
        }

        /// <summary>
        ///  сортировка в списке модулей по приоритету
        /// </summary>
        /// <param name="modulesLists">сортируемый список модулей</param>
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