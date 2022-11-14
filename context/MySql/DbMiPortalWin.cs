using Microsoft.EntityFrameworkCore;

namespace ms.Context.MySql
{
    public class DbMiPortalWin : DbContext
    {
        public DbMiPortalWin(DbContextOptions<DbMiPortalWin> options) : base(options)
        {
        }
    }
}