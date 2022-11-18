using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms.Models.VFmid
{
    public class md_busquedas
    {
        [Key]
        public int? id_busqueda { get; set; }
        public int ide_cliente { get; set; }
        public string? latitud { get; set; }

        public string? longitud { get; set; }

        public string? direccion { get; set; }

        public string? torre { get; set; }

        public string? bloque { get; set; }

        public int? tipo_interes_Id { get; set; }

        public int? vendedorId { get; set; }

        public string? observaciones { get; set; }
        public string? canal { get; set; }
        public int pasoWeb { get; set; }
    }

    [NotMapped]
    public class ModelBusqueda
    {
        public ModelGeofinder? geofinder { get; set; }
        public string? direccion { get; set; }
        public modelCliente? cliente { get; set; }
        public string? torre { get; set; }
        public string? bloque { get; set; }
        public int? tipo_interes_Id { get; set; }
        public int? vendedorId { get; set; }
        public int pasoWeb { get; set; }
    }
    [NotMapped]
    public class ModelGeofinder
    {
        public string? latitud { get; set; }
        public string? longitud { get; set; }
    }
}

