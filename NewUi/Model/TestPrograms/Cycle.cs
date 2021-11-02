using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    [Table("Cycles")]
    public class Cycle : TestModule
    {
        //в цике должны сущетсвовавать замер парамтеров, задеркжка, вклл выкл источника
        [Required]
        private string _name;

        public override string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public int Hour { get; set; }
        public int Min { get; set; }
        
        // public DateTime CycleTime { get; set; }
        public Cycle()
        {
            //TODO придумать где будет преборазование
        }


        public override string ToFormString()
        {
            return $"{Hour}час. ;{Min}мин.";
        }
    }
}