using Microsoft.EntityFrameworkCore;
using ms.Models.CRM;

namespace ms.Context.SqlServer
{
    public class DbECOM : DbContext
    {
        public DbECOM(DbContextOptions<DbECOM> options) : base(options)
        {
        }
        public DbSet<Cantidad>? Cantidad { get; set; }
    }
}