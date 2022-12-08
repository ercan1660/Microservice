using Microsoft.EntityFrameworkCore;
using ReportServices.Entity;

namespace ReportServices.Entity
{
    public class Context : DbContext
    {
       public Context(DbContextOptions<Context> options)
            :base(options)
        {

        }
            public DbSet<PhoneReport> PhoneReports { get; set; }
    }
}
