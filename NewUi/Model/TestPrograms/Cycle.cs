using System;

namespace NewUi
{
    public class Cycle : ITestProgram
    {
        //в цике должны сущетсвовавать замер парамтеров, задеркжка, вклл выкл источника
        //
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hour { get; set; }
        public DateTime CycleTime { get; set; }

        void CucleTimeSet(int hour,int min)
        {
            
        }

        public string ToFormString()
        {
            return $"{CycleTime.Hour}час. ;{CycleTime.Minute}мин.";
        }
    }
}