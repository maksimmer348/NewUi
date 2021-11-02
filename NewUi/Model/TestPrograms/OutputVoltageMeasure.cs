using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewUi
{ 
    [Table("OutputVoltageMeasures")]
    public class OutputVoltageMeasure : TestModule
    {
        //проверяме ВЫХОДНОЕ напряжение на соотвествеи нормама (конфигурица в изделиях), 
        //елси испытание пройдено или НЕТ, то записиыввпем данные в временную БД (напряжение и время (Datatim.Now)когда измерено),
        //если прошол исптынаия не меняем цвет шарика и статус прибора
        //еслли НЕТ то тот источто мы меняем цвет шариков, и иключаем прибор из дальнейших испытаний
        public override string DescriptionModule()
        {
            return "См. в Изделии";
        }
    }
}