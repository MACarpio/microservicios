
using Microsoft.EntityFrameworkCore;

namespace ms.Context.MySql
{
    public class DbCRM : DbContext
    {
        public DbCRM(DbContextOptions<DbCRM> options) : base(options)
        {
        }
    }
}