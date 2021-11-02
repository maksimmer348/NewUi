using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUi
{  
    [Table("SetTemperatures")]
    public class SetTemperature : TestModule
    {
        public SetTemperature()
        {
            //TODO придумтаь где будет преобразование
           
        }
        //дождатся леши
        public int Temperature { get; set; }

        public void SetTemperatureMeasurement(double temperature)
        {
           
        }
        
        public override string DescriptionModule()
        {
            return $"{Temperature} °C";
        }
    }
}
