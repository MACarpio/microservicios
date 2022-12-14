using System.ComponentModel.DataAnnotations;

namespace ms.Models.VFmid
{
    [Serializable]
    public class tp_clientes
    {
        [Key]
        public long ide_cli { get; set; }
        public long ide_tip_viv { get; set; }
        public long ide_tip_doc { get; set; }
        public string? cli_nom { get; set; }
        public string? cli_ape_pat { get; set; }
        public string? cli_ape_mat { get; set; }
        public string? cli_num_doc { get; set; }
        public string? cli_tel1 { get; set; }
        public string? cli_email { get; set; }

    }
    public class modelCliente
    {
        public int ide_tip_viv { get; set; }
        public int ide_tip_doc { get; set; }
        public string? cli_nom { get; set; }
        public string? cli_ape_pat { get; set; }
        public string? cli_ape_mat { get; set; }
        public string? cli_num_doc { get; set; }
        public string? cli_tel1 { get; set; }
        public string? cli_email { get; set; }
    }
}