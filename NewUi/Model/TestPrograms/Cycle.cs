using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        public override object DescriptionModule()
        {
            return $"{Hour}час. ;{Min}мин.";
        }
    }
}