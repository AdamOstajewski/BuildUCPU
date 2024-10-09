using Microsoft.EntityFrameworkCore;

namespace BuildUCPU.Models
{
    public class AppDBcontext: DbContext
    { 
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ustawienia połączenia
            optionsBuilder.UseMySql(
                "Server=localhost;Database=builducpu1;User=root;",
                new MySqlServerVersion(new Version(8, 0, 21)) // Upewnij się, że wersja pasuje do Twojej instalacji MySQL
            );
        }
    }
}

