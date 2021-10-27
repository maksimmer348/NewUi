using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace NewUi
{
    public class ApplicationContext : DbContext
    {
        //представляет набор сущностей, хранящихся в базе данных
        public DbSet<User> Users { get; set; }

        //Переопределение у класса контекста данных метода
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=C:\Users\specadmin\source\repos\ExcelParser\ExcelParser\Users.db");//В этот метод передается объект DbContextOptionsBuilder,
        // который позволяет создать параметры подключения. Для их создания вызывается метод UseSqlServer, в который передается строка подключения.

    }
}