using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    [Table("TestModule")]
    public abstract class TestModule
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProgramId { get; set; }
        public TestProgram TestProgram { get; set; }
        public virtual string DescriptionModule()
        {
            return null;
        }

    }
}