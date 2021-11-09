using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    [Table("ParamMeasurementTemperatures")]
    public class ParamMeasurementTemperature : TestModule
    {
       //замер темпертуры в камере дождатся лешу
       
       public override object DescriptionModule()
       {
           return "См. в Текущем измерении";
       }
    }
}