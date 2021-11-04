using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace NewUi
{
    public class ApplicationContext : DbContext
    {
        private static ApplicationContext instance; 
        public static ApplicationContext Instance => instance ??= new ApplicationContext();

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        //представляет набор сущностей, хранящихся в базе данных
        public DbSet<TestProgram> TestPrograms { get; set; }
        //public DbSet<TestModule> TestModules { get; set; }
        public DbSet<ContactCheck> ContactChecks { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<DelayBetweenMeasurement> DelayBetweenMeasurements { get; set; }
        public DbSet<ParamMeasurementTemperature> ParamMeasurementTemperatures { get; set; }
        public DbSet<OutputVoltageMeasure> OutputVoltageMeasures { get; set; }
        public DbSet<SetTemperature> SetTemperatures { get; set; }
        public DbSet<SupplyOn> SupplysOn { get; set; }
        public DbSet<SupplyOff> SupplysOff { get; set; }
        //Переопределение у класса контекста данных метода
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=TestPrograms.db");//В этот метод передается объект DbContextOptionsBuilder,
                                                                                                                   // который позволяет создать параметры подключения. Для их создания вызывается метод UseSqlServer, в который передается строка подключения.
       
    }
}