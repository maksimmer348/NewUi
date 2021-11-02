using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    [Table("ParamMeasurementTemperatures    ")]
    public class ParamMeasurementTemperature : TestModule
    {
       //замер темпертуры в камере дождатся лешу
     
       public  string Name { get; set; } 
       public override string ToFormString()
       {
           return "См. в Текущем измерении";
       }
    }
}