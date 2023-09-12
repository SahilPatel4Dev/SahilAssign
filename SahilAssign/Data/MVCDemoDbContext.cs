using Microsoft.EntityFrameworkCore;
using SahilAssign.Models.Domain;

namespace SahilAssign.Data
{
    public class MVCDemoDbContext:DbContext
    {
        public MVCDemoDbContext(DbContextOptions options):base(options) 
        { 

        }

        public DbSet<Setting> Settings { get; set; }
    }
}
