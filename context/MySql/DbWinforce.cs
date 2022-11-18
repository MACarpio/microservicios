using Microsoft.EntityFrameworkCore;
namespace ms.Context.MySql
{
    public class DbWinforce : DbContext
    {
        public DbWinforce(DbContextOptions<DbWinforce> options) : base(options)
        {
        }


    }
}