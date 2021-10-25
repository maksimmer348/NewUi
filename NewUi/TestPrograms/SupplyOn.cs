using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUi
{
    class SupplyOn : ITestProgram
    {
        //задана таблица слотов взять из новое испытание, если номер не нулевой знаачит там стоит источник,
        //подается ПОЛОВИННАЯ нагрузка и входное напряжение в зависивимости от подключаемого изделия (конфигурица в изделиях), 
        //проверяется ВЫХОДНОЕ напряжение всех изделлий, если все в норме то подается ПОЛНАЯ нагрузка,
        //индиктаоры меняют цвет

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
