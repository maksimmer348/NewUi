using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{
    public abstract class TestModule
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Priority { get; set; }
        
        public int? TestProgramId { get; set; }
        public TestProgram TestProgram { get; set; }
        
        public int? CycleId { get; set; }
        public Cycle Cycle { get; set; }
        
        public virtual object DescriptionModule()
        {
            return " ";
        }

    }
}