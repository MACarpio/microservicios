namespace ms.Models.VFmid
{
    public class tp_busquedas
    {
        public long ide_bus { get; set; }
        public long ide_cli { get; set; }
        public long? ide_soc { get; set; }
        public long? ide_pre_soc { get; set; }
        public long? ide_edi { get; set; }
        public long ide_tip_int { get; set; }
        public int bus_tip { get; set; }
        public string? bus_dir_ref { get; set; }
        public string bus_ubigeo { get; set; } = null!;
        public string? bus_res { get; set; }
        public string bus_lat { get; set; } = null!;
        public string bus_lng { get; set; } = null!;
        public string bus_dir { get; set; } = null!;
        public string? bus_obs { get; set; }
        public string? num_departament { get; set; }
        public int bus_seg_est { get; set; }
        public DateTime? seg_prox_fecha { get; set; }
        public long? seller_id { get; set; }
        public string? seller_type { get; set; }
        public string? cli_ubi_dep { get; set; }
        public string? cli_ubi_dis { get; set; }
        public string? cli_ubi_prov { get; set; }
        public string? cond_torre { get; set; }
        public string? score_equifax { get; set; }
        public string? bus_cod_postal { get; set; }
        public string? bus_cod_postal_text { get; set; }
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
}