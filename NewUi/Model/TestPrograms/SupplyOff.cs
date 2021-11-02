using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    [Table("SupplyOffs")]
    public class SupplyOff: TestModule
    {
       
        public  string Name { get; set; }
        public int UnquieSupplyOn = 2;
        public override string ToFormString()
        {
            return "-";
        }
    }
}