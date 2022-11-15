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
        [HttpGet]
        public ActionResult<IEnumerable<md_CRM_DIRECCION>> Get()
        {
            return Ok(_dbmid.md_CRM_DIRECCION.ToList());
        }

        [HttpPost]
        public void Post([FromBody] md_CRM_DIRECCION model)
        {
            _dbmid.md_CRM_DIRECCION.Add(model);
            _dbmid.SaveChanges();
        }


        [HttpPost("Flag")]
        public ActionResult<IEnumerable<md_CRM_DIRECCION>> GetFlag(ModelCrmDireccion model)
        {
            var result = _dbmid.md_CRM_DIRECCION.Where(x => x.DIRC_COD_TIPO_VIA == model.DIRC_COD_TIPO_VIA && x.DIRV_DESCRIPCION_VIA == model.DIRV_DESCRIPCION_VIA && x.DIRV_DESCRIPCION_NUMERACION == model.DIRV_DESCRIPCION_NUMERACION && x.DIRV_MANZANA == model.DIRV_MANZANA && x.DIRV_LOTE == model.DIRV_LOTE);
            if (result.Count() == 0)
            {
                return Ok(new { flag = "No" });
            }
            return Ok(new { flag = "Si" });
        }

    }
}