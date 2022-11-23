using Microsoft.EntityFrameworkCore;
using ms.Models.VFmid;
namespace ms.Context.SqlServer
{
    public class DbVFmid : DbContext
    {
        public DbVFmid(DbContextOptions<DbVFmid> options) : base(options)
        {
        }
        public DbSet<md_turno_instalacion>? md_turno_instalacion { get; set; }
        public DbSet<md_sv>? md_sv { get; set; }
        public virtual DbSet<md_CRM_DIRECCION>? md_CRM_DIRECCION { get; set; }
        public virtual DbSet<tp_score_v1>? tp_score_v1 { get; set; }
        public DbSet<tp_clientes> tp_clientes { get; set; }
        public DbSet<tp_i_busquedas> tp_i_busquedas { get; set; }
    }
}