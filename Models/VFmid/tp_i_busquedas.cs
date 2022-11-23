
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms.Models.VFmid
{
    public class tp_i_busquedas
    {
        [Key]
        public long ide_i_bus { get; set; }
        [Required]
        public long ide_i_cli { get; set; }
        public long? ide_i_soc { get; set; }
        public long? ide_i_pre_soc { get; set; }
        public long? i_ide_edi { get; set; }
        [Required]
        public long i_ide_tip_int { get; set; }
        [Required]
        public int i_bus_tip { get; set; }
        public string? i_bus_dir_ref { get; set; }
        [Required]
        public string i_bus_ubigeo { get; set; } = null!;
        public string? i_bus_res { get; set; }
        [Required]
        public string i_bus_lat { get; set; } = null!;
        [Required]
        public string i_bus_lng { get; set; } = null!;
        [Required]
        public string i_bus_dir { get; set; } = null!;
        public string? i_bus_obs { get; set; }
        public string? i_num_departament { get; set; }
        [Required]
        public int i_bus_seg_est { get; set; }
        public DateTime? i_seg_prox_fecha { get; set; }
        public long? i_seller_id { get; set; }
        public string? i_seller_type { get; set; }
        public string? cli_ubi_dep { get; set; }
        public string? cli_ubi_dis { get; set; }
        public string? cli_ubi_prov { get; set; }
        public string? cond_torre { get; set; }
        [StringLength(5)]
        public string? score_equifax { get; set; }
        public string? bus_cod_postal { get; set; }
        public string? bus_cod_postal_text { get; set; }
        [StringLength(4)]
        public string? num_piso { get; set; }
        public int? ide_pre_rel { get; set; }
        public long? ide_venta_origen { get; set; }
        public string? utm_source { get; set; }
        public string? utm_campaign { get; set; }
        public string? utm_medium { get; set; }
        public long? paso_proceso { get; set; }
        public long? id_consulta_web { get; set; }
        public long? estado { get; set; }
        public DateTime? updated_at { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? update_by { get; set; }
    }

    [NotMapped]
    public class ModelPrGeofinder
    {
        public string bus_ubigeo { get; set; } = null!;
        public string? bus_res { get; set; }
        public string bus_lat { get; set; } = null!;
        public string bus_lng { get; set; } = null!;
        public string bus_dir { get; set; } = null!;
    }

    [NotMapped]
    public class ModelLeadCompleto
    {
        [Required]
        public modelCliente? cliente { get; set; }
        public long? ide_i_soc { get; set; }
        public long? ide_i_pre_soc { get; set; }
        public long? i_ide_edi { get; set; }
        [Required]
        public long i_ide_tip_int { get; set; }
        [Required]
        public int i_bus_tip { get; set; }
        public string? i_bus_dir_ref { get; set; }
        [Required]
        public ModelPrGeofinder? geofinder { get; set; }
        public string? i_bus_obs { get; set; }
        public string? i_num_departament { get; set; }
        [Required]
        public int i_bus_seg_est { get; set; }
        public DateTime? i_seg_prox_fecha { get; set; }
        public string? cli_ubi_dep { get; set; }
        public string? cli_ubi_dis { get; set; }
        public string? cli_ubi_prov { get; set; }
        public string? cond_torre { get; set; }
        [StringLength(5)]
        public string? score_equifax { get; set; }
        public string? bus_cod_postal { get; set; }
        public string? bus_cod_postal_text { get; set; }
        [StringLength(4)]
        public string? num_piso { get; set; }
        public int? ide_pre_rel { get; set; }
        public long? ide_venta_origen { get; set; }
        public string? utm_source { get; set; }
        public string? utm_campaign { get; set; }
        public string? utm_medium { get; set; }
        public long? paso_proceso { get; set; }
        public long? id_consulta_web { get; set; }
        public long? estado { get; set; }
    }
}