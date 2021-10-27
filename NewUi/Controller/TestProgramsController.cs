namespace NewUi
{
    public class TestProgramsController
    {
        public TestProgramBuilder TestProgram = new TestProgramBuilder();//при созддании программы сюда вписыват имя из тексбокса
         
        public void SelectTestProgram(TypesTestProgram typesProgram)
        {

            switch (typesProgram)
            {
                case TypesTestProgram.ContactCheck:
                    TestProgram.AddProgram(new ContactCheck());
                    break;
                case TypesTestProgram.SupplyOn:
                    TestProgram.AddProgram(new SupplyOn());
                    break;
                case TypesTestProgram.SupplyOff:
                    TestProgram.AddProgram(new SupplyOff());
                    break;
                case TypesTestProgram.OutputVoltageMeasure:
                    TestProgram.AddProgram(new OutputVoltageMeasure());
                    break;
                case TypesTestProgram.SetTemperature:
                    TestProgram.AddProgram(new SetTemperature());
                    break;
                case TypesTestProgram.ParamMeasureTemperature:
                    TestProgram.AddProgram(new ParamMeasureTemperature());
                    break;
                case TypesTestProgram.DelayBetwenMesaure:
                    TestProgram.AddProgram(new DelayBetwenMesaure());//добавить данные 
                    break;
                case TypesTestProgram.Cycle:
                    TestProgram.AddProgram(new Cycle());//добавить данные 
                    break;
            }
        }
    }
}