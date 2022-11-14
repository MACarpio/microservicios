using System.ComponentModel.DataAnnotations;

namespace ms.Models.VFmid
{
    public class md_turno_instalacion
    {
        [Key]
        public int Id { get; set; }
        public String? Departamento { get; set; }
        public String? Provincia { get; set; }
        public String? Distrito { get; set; }
        public String? Tr_mañana { get; set; }
        public String? Tr_tarde { get; set; }
        public String? Tr_noche { get; set; }
        public String? Observacion { get; set; }
    }
}