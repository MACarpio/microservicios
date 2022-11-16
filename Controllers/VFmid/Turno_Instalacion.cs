using ms.Context.SqlServer;
using Microsoft.AspNetCore.Mvc;
using ms.Models.VFmid;
using Microsoft.EntityFrameworkCore;

namespace ms.Controllers.VFmid
{
    [Route("api/[controller]")]
    [ApiController]
    public class Turno_Instalacion : ControllerBase
    {
        private readonly DbVFmid _dbmid;
        public Turno_Instalacion(DbVFmid dbmid)
        {
            _dbmid = dbmid;
        }

        [HttpGet]
        public ActionResult<IEnumerable<md_turno_instalacion>> Get()
        {
            return Ok(_dbmid.md_turno_instalacion.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_dbmid.md_turno_instalacion.Find(id));
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] md_turno_instalacion model)
        {
            _dbmid.Entry(model).State = EntityState.Modified;
            _dbmid.SaveChanges();
            return Ok(new { message = "Actualizado", datos = model });
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] md_turno_instalacion model)
        {
            _dbmid.md_turno_instalacion.Add(model);
            _dbmid.SaveChanges();
            return Ok(new { message = "Agregado", datos = model });
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var Turno_Instalacion = _dbmid.md_turno_instalacion.Find(id);
            if (Turno_Instalacion == null)
            {
                return NotFound();
            }
            _dbmid.md_turno_instalacion.Remove(Turno_Instalacion);
            _dbmid.SaveChanges();
            return Ok(new { message = "Eliminado", datos = Turno_Instalacion });

        }

        [HttpGet("GetTurnoInstalacion")]
        public ActionResult<string> GetTurnoInstalacion(string fecha, string distrito, int flag)
        {
            DateTime horaPeticion = DateTime.Now;
            TimeZoneInfo Peru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            var hoy = TimeZoneInfo.ConvertTime(horaPeticion, Peru, TimeZoneInfo.Local);
            var tr_instalacion = _dbmid.md_turno_instalacion.FirstAsync(x => x.Distrito == distrito);
            DateTime dateTime = DateTime.Parse(fecha);
            if (tr_instalacion.Result.Tr_noche == "")
            {
                tr_instalacion.Result.Tr_noche = "No Disponible";
            }
            if (tr_instalacion.Result == null)
            {
                return NotFound("No se encontró el distrito");
            }
            if (DateOnly.FromDateTime(dateTime) < DateOnly.FromDateTime(hoy))
            {
                return NotFound("No se puede agendar en fechas pasadas");
            }
            else
            {
                if (flag == 0)
                {
                    if (fecha == DateOnly.FromDateTime(hoy).ToString())
                    {
                        if (hoy.Hour >= 0 && hoy.Hour < 6)
                        {
                            return Ok(new { tr_mañana = tr_instalacion.Result.Tr_tarde, tr_tarde = tr_instalacion.Result.Tr_tarde, tr_noche = tr_instalacion.Result.Tr_noche });
                        }
                        else
                        {
                            if (hoy.Hour >= 6 && hoy.Hour < 11)
                            {
                                return Ok(new { tr_mañana = "No Disponible", tr_tarde = tr_instalacion.Result.Tr_tarde, tr_noche = tr_instalacion.Result.Tr_noche });
                            }
                            else
                            {
                                if (hoy.Hour >= 11 && (hoy.Hour <= 14 && hoy.Minute <= 30))
                                {
                                    return Ok(new { tr_mañana = "No Disponible", tr_tarde = "No Disponible", tr_noche = tr_instalacion.Result.Tr_noche });
                                }
                                else
                                {
                                    return Ok(new { tr_mañana = "No Disponible", tr_tarde = "No Disponible", tr_noche = "No Disponible" });
                                }
                            }
                        }

                    }
                    else
                    {
                        return Ok(new { tr_mañana = tr_instalacion.Result.Tr_mañana, tr_tarde = tr_instalacion.Result.Tr_tarde, tr_noche = tr_instalacion.Result.Tr_noche });
                    }
                }
                if (flag == 1)
                {
                    if (DateOnly.FromDateTime(dateTime) <= DateOnly.FromDateTime(hoy.AddDays(2)))
                    {
                        return Ok(new { message = "No se puede agendar antes de los 2 dias" });
                    }
                    else
                    {
                        return Ok(new { tr_mañana = tr_instalacion.Result.Tr_mañana, tr_tarde = tr_instalacion.Result.Tr_tarde, tr_noche = tr_instalacion.Result.Tr_noche });
                    }

                }
                else
                {
                    return NotFound("Flag Solo Acepta 0 o 1");
                }
            }

        }
    }
}