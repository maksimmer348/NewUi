using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NewUi
{
    public abstract class TestModule
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Index { get; set; }
        
        /// <summary>
        /// список модулей в цикле
        /// </summary>
        public List<TestModule> ModulesList { get; set; }
        //public List<TestModule> ModulesList = new ();
        public TestModule()
        {
            ModulesList = new();
        }
        
        /// <summary>
        /// добаавить один модуль в "цикл"
        /// </summary>
        /// <param name="module">добаавляемый модуль</param>
        public void AddModuleToList(TestModule module)
        {
            if (module != null)
            {
                ModulesList.Add(module);
            }
        }
      
        // /// <summary>
        // ///  сортировка в списке модулей по приоритету
        // /// </summary>
        // /// <param name="modulesLists">сортируемый список модулей</param>
        // public void AddModulesToList(params IEnumerable<TestModule>[] modulesLists)
        // {
        //     List<TestModule> tempList = new();
        //     foreach (var modulesList in modulesLists)
        //     {
        //         if (modulesList != null || modulesList.Any())
        //         {
        //             foreach (var module in modulesList)
        //             {
        //                 tempList.Add(module);
        //             }
        //             //выстраиваем модули в списке по приоритеиту
        //             ModulesList = tempList.OrderBy(m => m.Priority).ToList();
        //         }
        //     }
        // }
        //
        public virtual string DescriptionModule()
        {
            return " ";
        }

    }
}