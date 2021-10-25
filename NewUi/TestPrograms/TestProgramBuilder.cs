using System.Collections.Generic;

namespace NewUi
{
    public class TestProgramBuilder
    {
        private List<ITestProgram> TestPrograms = new();

        public void AddPrograms(ITestProgram program)
        {
            TestPrograms.Add(program);
        }
        public void DelPrograms(int item)
        {
            TestPrograms.RemoveAt(item);
        }
        public List<ITestProgram> DisplayTestPrograms()
        {
            return TestPrograms;
        }

    }
}