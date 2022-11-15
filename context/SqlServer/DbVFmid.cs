using Microsoft.EntityFrameworkCore;
using ms.Models.VFmid;
namespace ms.Context.SqlServer
{
    public partial class DbVFmid : DbContext
    {
        public DbVFmid(DbContextOptions<DbVFmid> options) : base(options)
        {
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public DbSet<md_turno_instalacion>? md_turno_instalacion { get; set; }
        public DbSet<md_sv>? md_sv { get; set; }
        public DbSet<md_busquedas>? md_busquedas { get; set; }
        public virtual DbSet<md_CRM_DIRECCION>? md_CRM_DIRECCION { get; set; }
    }
}