using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi;

    public class ParamMeasurementTemperature : TestModule
    {
       //замер темпертуры в камере дождатся лешу
       
       public override string DescriptionModule()
       {
           return "См. в Текущем измерении";
       }
    }
