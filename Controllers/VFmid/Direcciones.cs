using Microsoft.AspNetCore.Mvc;
using ms.Models.VFmid;
using ms.Context.SqlServer;

namespace ms.Controllers.VFmid
{
    [Route("api/[controller]")]
    [ApiController]
    public class Direcciones : ControllerBase
    {
        private readonly DbVFmid _dbmid;
        public Direcciones(DbVFmid dbmid)
        {
            _dbmid = dbmid;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<md_CRM_DIRECCION>> Get()
        // {
        //     return Ok(_dbmid.md_CRM_DIRECCION.ToList());
        // }
        // [HttpPost]
        // public void Post([FromBody] md_CRM_DIRECCION model)
        // {
        //     _dbmid.md_CRM_DIRECCION.Add(model);
        //     _dbmid.SaveChanges();
        // }


        [HttpGet("ValidarFlag")]
        public ActionResult<IEnumerable<md_CRM_DIRECCION>> GetFlag(string TIPO_VIA, string DESCRIPCION_VIA, string DESCRIPCION_NUMERACION, string MANZANA, string LOTE)
        {
            var result = _dbmid.md_CRM_DIRECCION.Where(x => x.DIRC_COD_TIPO_VIA == TIPO_VIA && x.DIRV_DESCRIPCION_VIA == DESCRIPCION_VIA && x.DIRV_DESCRIPCION_NUMERACION == DESCRIPCION_NUMERACION && x.DIRV_MANZANA == MANZANA && x.DIRV_LOTE == LOTE);
            if (result.Count() == 0)
            {
                return Ok(new { flag = 0 });
            }
            return Ok(new { flag = 1 });
        }

    }
}