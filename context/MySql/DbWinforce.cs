using Microsoft.EntityFrameworkCore;
using ms.Models.Winforce;
namespace ms.Context.MySql
{
    public class DbWinforce : DbContext
    {
        public DbWinforce(DbContextOptions<DbWinforce> options) : base(options)
        {
        }

        public DbSet<tp_clientes> tp_clientes { get; set; }
    }
}