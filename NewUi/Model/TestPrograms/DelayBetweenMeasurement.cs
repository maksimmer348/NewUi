using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    public class DelayBetweenMeasurement : TestModule
    {
        //просто задержка между операциями без изменения их 
        
        
        public decimal Min { get; set; }
        public decimal Sec { get; set; }
        
        public DelayBetweenMeasurement()
        {
            //TODO где производить каст
        }
        
        public override string DescriptionModule()
        {
            return $"{Min}мин. ;{Sec}сек.";
        }
    }
}