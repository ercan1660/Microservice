using Microsoft.EntityFrameworkCore;

namespace P_CRUD_MS.Entity
{
    //veritabana bağlantısı...
    public class Context : DbContext
    {
       public Context(DbContextOptions<Context> options)
            :base(options)
        {

        }
            public DbSet<Phone> Phones { get; set; }
    }
}
