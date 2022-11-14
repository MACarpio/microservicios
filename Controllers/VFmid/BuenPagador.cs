using ms.Context.SqlServer;
using Microsoft.AspNetCore.Mvc;
using ms.Models.VFmid;

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

        [HttpGet("{doc}")]
        public ActionResult<string> Get(string doc)
        {
            var result = _dbmid.md_sv.Where(x => x.nro_doc == doc).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            if ((result.Score / 100) >= 0.8)
            {
                return Ok(new { message = "Buen Pagador", datos = result });
            }
            else
            {
                return Ok(new { message = "Hola, muchas gracias por preferir Win. Por el momento no puedes continuar con el proceso. Disculpa por los inconvenientes", datos = result });
            }
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] md_sv model)
        {
            _dbmid.md_sv.Add(model);
            _dbmid.SaveChanges();
            return Ok(new { message = "Agregado", datos = model });
        }


    }
}