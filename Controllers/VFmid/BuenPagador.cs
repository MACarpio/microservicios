using ms.Context.SqlServer;
using Microsoft.AspNetCore.Mvc;

namespace ms.Controllers.VFmid
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuenPagador : ControllerBase
    {
        private readonly DbVFmid _dbmid;
        public BuenPagador(DbVFmid dbmid)
        {
            _dbmid = dbmid;
        }

        [HttpGet("")]
        public ActionResult<string> Get(string doc)
        {
            var result = _dbmid.tp_score_v1.Where(x => x.dni == doc).FirstOrDefault();
            if (result == null)
            {
                return NotFound(new { message = "No se encontrĂ³ el documento" });
            }
            if ((result.score / 100) >= 0.8)
            {
                return Ok(new { message = "Buen Pagador", datos = result });
            }
            else
            {
                return Ok(new { message = "Hola, muchas gracias por preferir Win. Por el momento no puedes continuar con el proceso. Disculpa por los inconvenientes", datos = result });
            }
        }

    }
}