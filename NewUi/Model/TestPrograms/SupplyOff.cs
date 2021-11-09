using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    [Table("SupplysOff")]
    public class SupplyOff: TestModule
    {
        public int UnquieSupplyOn = 2;
        public override object DescriptionModule()
        {
            return "-";
        }
    }
}