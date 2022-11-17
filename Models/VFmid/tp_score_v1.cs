using System.ComponentModel.DataAnnotations;

namespace ms.Models.VFmid
{
    public class tp_score_v1
    {
        [Key]
        public int ide_sco { get; set; }
        public string? dni { get; set; }
        public string? id_pedido { get; set; }
        public string? nrorecibos { get; set; }
        public string? pagos_al_dia { get; set; }
        public int score { get; set; }
    }
}