
using Microsoft.EntityFrameworkCore;
using ms.Models.CRM;

namespace ms.Context.SqlServer
{
    public class DbCRM : DbContext
    {
        public DbCRM(DbContextOptions<DbCRM> options) : base(options)
        {
        }
        public virtual DbSet<query> query { get; set; }
    }
}