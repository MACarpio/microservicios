using System.ComponentModel.DataAnnotations;

namespace ms.Models.VFmid
{
    public class md_CRM_DIRECCION
    {
        [Key]
        public int DIRI_COD_DIRECCION { get; set; }
        public string? DIRC_UBIGEO { get; set; }
        public string? DIRV_NOMBRE { get; set; }
        public double? DIRN_LATITUD { get; set; }
        public double? DIRN_LONGITUD { get; set; }
        public string? DIRV_DIRECCION { get; set; }
        public string? DIRC_COD_TIPO_VIA { get; set; }
        public string? DIRV_DESCRIPCION_VIA { get; set; }
        public string? DIRC_COD_TIPO_NUMERACION { get; set; }
        public string? DIRV_DESCRIPCION_NUMERACION { get; set; }
        public string? DIRC_COD_TIPO_NIVEL { get; set; }
        public string? DIRV_DESCRIPCION_NIVEL { get; set; }
        public string? DIRC_COD_TIPO_INMUEBLE { get; set; }
        public string? DIRV_DESCRIPCION_INMUEBLE { get; set; }
        public string? DIRV_MANZANA { get; set; }
        public string? DIRV_LOTE { get; set; }
        public string? DIRC_COD_TIPO_UBICACION { get; set; }
        public string? DIRV_DESCRIPCION_UBICACION { get; set; }
        public string? DIRC_COD_TIPO_SUBUBICACION { get; set; }
        public string? DIRV_DESCRIPCION_SUBUBICACION { get; set; }
        public string? DIRV_SECTOR { get; set; }
        public string? DIRV_ETAPA { get; set; }
        public string? DIRV_REFERENCIA { get; set; }
        public int DIRI_COD_DIRECCION_PADRE { get; set; }
        public int? DIRI_EST_REGISTRO { get; set; }
        public string? DIRV_USUARIO_CREACION { get; set; }
        public DateTime? DIRD_FECHA_CREACION { get; set; }
        public string? DIRV_USUARIO_ACTUALIZACION { get; set; }
        public DateTime? DIRD_FECHA_ACTUALIZACION { get; set; }
        public int? DIRI_COD_ECOM { get; set; }
        public int? DIRI_COD_COBERTURA { get; set; }
    }
}