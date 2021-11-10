using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NewUi
{
    [Table("Cycles")]
    public class Cycle : TestModule
    {
        //в цике должны сущетсвовавать замер парамтеров, задеркжка, вклл выкл источника
        
        public decimal Hour { get; set; }
        public decimal Min { get; set; }
        
        // public DateTime CycleTime { get; set; }
        public Cycle()
        {
            //TODO придумать где будет преборазование
        }
        
        /// <summary>
        /// список модулей в цикле
        /// </summary>
        private List<TestModule> ModulesInCycleList = new List<TestModule>();
        
        /// <summary>
        /// добаавить один модуль в "цикл"
        /// </summary>
        /// <param name="module">добаавляемый модуль</param>
        public void AddModuleToList(TestModule module)
        {
            if (module != null)
            {
                ModulesInCycleList.Add(module);
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
                    //выстраиваем модули в списке по приоритеиту
                    ModulesInCycleList = tempList.OrderBy(m => m.Priority).ToList();
                }
            }
        }
        
        public override object DescriptionModule()
        {
            return $"{Hour}час. ;{Min}мин.";
        }
    }
}