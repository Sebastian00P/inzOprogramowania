using inzOprogramowania.Modeles;
using Microsoft.EntityFrameworkCore;

namespace inzOprogramowania.DataContext
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        { 

        }
       
        public DbSet<User> Users { get; set; }

       
    }
}
