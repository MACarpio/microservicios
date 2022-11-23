using Microsoft.EntityFrameworkCore;

namespace ms.Models.CRM
{
    [Keyless]
    public class query
    {
        public string? CLIV_NUMERO_DOCUMENTO { get; set; }
        public string? DOCC_COD_TIPO_ESTADO { get; set; }
        public string? DOCC_COD_TIPO_SUB_ESTADO { get; set; }
    }
}