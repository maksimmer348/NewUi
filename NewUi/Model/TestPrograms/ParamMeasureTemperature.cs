﻿namespace NewUi
{
    public class ParamMeasureTemperature : ITestProgram
    {
       //замер темпертуры в камере дождатся лешу
       public int Id { get; set; }
       public string Name { get; set; }
       public string ToFormString()
       {
           return "См. в Текущем измерении";
       }
    }
}