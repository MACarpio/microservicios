using System.ComponentModel.DataAnnotations;

namespace ms.Models.VFmid
{
    public class md_sv
    {
        [Key]
        public int id { get; set; }
        public string? nro_doc { get; set; }
        public int Score { get; set; }
    }
}