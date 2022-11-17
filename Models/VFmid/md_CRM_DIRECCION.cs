using System.ComponentModel.DataAnnotations;

namespace ms.Models.VFmid
{
    public partial class md_CRM_DIRECCION
    {
        [Key]
        public long DIRI_COD_DIRECCION { get; set; }
        public string DIRC_UBIGEO { get; set; } = null!;
        public string DIRV_NOMBRE { get; set; } = null!;
        public decimal DIRN_LATITUD { get; set; }
        public decimal DIRN_LONGITUD { get; set; }
        public string? DIRV_DIRECCION { get; set; }
        public string DIRC_COD_TIPO_VIA { get; set; } = null!;
        public string DIRV_DESCRIPCION_VIA { get; set; } = null!;
        public string DIRC_COD_TIPO_NUMERACION { get; set; } = null!;
        public string DIRV_DESCRIPCION_NUMERACION { get; set; } = null!;
        public string DIRC_COD_TIPO_NIVEL { get; set; } = null!;
        public string DIRV_DESCRIPCION_NIVEL { get; set; } = null!;
        public string DIRC_COD_TIPO_INMUEBLE { get; set; } = null!;
        public string DIRV_DESCRIPCION_INMUEBLE { get; set; } = null!;
        public string DIRV_MANZANA { get; set; } = null!;
        public string DIRV_LOTE { get; set; } = null!;
        public string DIRC_COD_TIPO_UBICACION { get; set; } = null!;
        public string DIRV_DESCRIPCION_UBICACION { get; set; } = null!;
        public string DIRC_COD_TIPO_SUBUBICACION { get; set; } = null!;
        public string DIRV_DESCRIPCION_SUBUBICACION { get; set; } = null!;
        public string DIRV_SECTOR { get; set; } = null!;
        public string DIRV_ETAPA { get; set; } = null!;
        public string DIRV_REFERENCIA { get; set; } = null!;
        public long? DIRI_COD_DIRECCION_PADRE { get; set; }
        public int DIRI_EST_REGISTRO { get; set; }
        public string DIRV_USUARIO_CREACION { get; set; } = null!;
        public DateTime DIRD_FECHA_CREACION { get; set; }
        public string DIRV_USUARIO_ACTUALIZACION { get; set; } = null!;
        public DateTime DIRD_FECHA_ACTUALIZACION { get; set; }
        public int? DIRI_COD_ECOM { get; set; }
        public long? DIRI_COD_COBERTURA { get; set; }
    }
    public partial class ModelCrmDireccion
    {
        public string TIPO_VIA { get; set; } = null!;
        public string DESCRIPCION_VIA { get; set; } = null!;
        public string DESCRIPCION_NUMERACION { get; set; } = null!;
        public string MANZANA { get; set; } = null!;
        public string LOTE { get; set; } = null!;

    }
}
