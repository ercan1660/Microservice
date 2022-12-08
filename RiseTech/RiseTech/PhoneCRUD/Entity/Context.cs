using Microsoft.EntityFrameworkCore;

namespace PhoneCRUD.Entity
{
    public class Context : DbContext
    {
       public Context(DbContextOptions<Context> options)
            :base(options)
        {

        }
            public DbSet<Phone> Phones { get; set; }
    }
}
