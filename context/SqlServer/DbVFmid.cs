using Microsoft.EntityFrameworkCore;
using ms.Models.VFmid;

namespace ms.Context.SqlServer
{
    public class DbVFmid : DbContext
    {
        public DbVFmid(DbContextOptions<DbVFmid> options) : base(options)
        {
        }
        public DbSet<md_busquedas> md_busquedas { get; set; }
        public DbSet<md_turno_instalacion> md_turno_instalacion { get; set; }
        public DbSet<md_sv> md_sv { get; set; }
        public DbSet<md_CRM_DIRECCION> md_crm_direccion { get; set; }
    }
}