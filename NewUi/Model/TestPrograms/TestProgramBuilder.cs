using System;
using System.Collections.Generic;

namespace NewUi
{
    public enum TypesTestProgram
    {
        None = 0,
        ContactCheck,
        SupplyOff,
        SupplyOn,
        OutputVoltageMeasure,
        SetTemperature,
        ParamMeasureTemperature,
        DelayBetwenMesaure,
        Cycle,
    }

    public class TestProgramBuilder
    {
        public TestProgramBuilder(string testProgramName)
        {
            TestProgramName = testProgramName;
        }

        private string _testProgramName;
        public event Action<string> SetTestProgramName;
        public string TestProgramName
        {
            get => _testProgramName;
            set
            {
                if (_testProgramName != value)
                {
                    _testProgramName = value;

                    SetTestProgramName?.Invoke(TestProgramName);//запись в бд вызватьь здесь?
                }
            }
        }

        private TypesTestProgram _typesTestProgram = TypesTestProgram.None;
        public event Action<TypesTestProgram> ChangedTestProgram;
        public TypesTestProgram SelectTestProgram
        {
            get => _typesTestProgram;
            set
            {
                if (_typesTestProgram != value)
                {
                    _typesTestProgram = value;

                    ChangedTestProgram?.Invoke(SelectTestProgram);
                }
            }
        }

        public event Action<List<ITestProgram>> TestProgramsChangedList;
        private List<ITestProgram> _testProgramsList;
        public List<ITestProgram> TestProgramsList
        {
            get => _testProgramsList;
            set
            {
                if (_testProgramsList != value)
                {
                    _testProgramsList = value;

                    TestProgramsChangedList?.Invoke(value);
                }
            }
        }
        public void AddProgram(ITestProgram program)
        {
            TestProgramsList.Add(program);
        }
        public void DelPrograms(int item)
        {
            TestProgramsList.RemoveAt(item);
        }
        //public List<ITestProgram> DisplayTestPrograms()
        //{
        //    return TestPrograms;
        //}
        public void InvokeAll()
        {
            foreach (var prop in GetType().GetProperties())
            {
                prop.SetValue(this, prop.GetValue(this));
            }
        }
    }
}