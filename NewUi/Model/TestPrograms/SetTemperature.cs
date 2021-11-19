using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    public class SetTemperature : TestModule
    {
        public SetTemperature()
        {
            //TODO придумтаь где будет преобразование
        }

        //дождатся леши
        public decimal Temperature { get; set; }

        public void SetTemperatureMeasurement(double temperature)
        {
        }

        public override string DescriptionModule()
        {
            return $"{Temperature} °C";
        }
    }
}