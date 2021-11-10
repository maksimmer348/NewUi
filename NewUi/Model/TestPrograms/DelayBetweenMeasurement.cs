using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
   [Table("DelayBetweenMeasurements")]
    public class DelayBetweenMeasurement : TestModule
    {
        //просто задержка между операциями без изменения их 
        
        public int CycleId { get; set; }
        public Cycle Cycle { get; set; }
        
        public decimal Min { get; set; }
        public decimal Sec { get; set; }
        
        public DelayBetweenMeasurement()
        {
            //TODO где производить каст
        }
        
        public override object DescriptionModule()
        {
            return $"{Min}мин. ;{Sec}сек.";
        }
    }
}