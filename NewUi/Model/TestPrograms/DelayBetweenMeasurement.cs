using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
   [Table("DelayBetweenMeasurements")]
    public class DelayBetweenMeasurement : TestModule
    {
        //просто задержка между операциями без изменения их 
        
        [Required]
        public override string Name { get; set; }
        //public DateTime CycleTime { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; }
        public DelayBetweenMeasurement()
        {
            //TODO где производить каст
         
        }
        public override string ToFormString()
        {
            return $"{Min}мин. ;{Sec}сек.";
        }
    }
}