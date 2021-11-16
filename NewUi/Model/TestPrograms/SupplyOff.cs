using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    [Table("SupplysOff")]
    public class SupplyOff: TestModule
    {
        public override string DescriptionModule()
        {
            return "-";
        }
    }
}