using System.ComponentModel.DataAnnotations;

namespace ms.Models.Winforce
{
    [Serializable]
    public class tp_clientes
    {
        [Key]
        public int ide_cli { get; set; }
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