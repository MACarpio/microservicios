using Microsoft.AspNetCore.Mvc;
using ms.Models.Winforce;
using ms.Context.MySql;
using ms.Context.SqlServer;
using Microsoft.EntityFrameworkCore;
using ms.Models.VFmid;

namespace ms.Controllers.Winforce
{
    [Route("winforce/[controller]")]
    [ApiController]
    public class Clientes : ControllerBase
    {
        private readonly DbWinforce _contextWinforce;
        private readonly DbVFmid _contextVFmid;

        public Clientes(DbWinforce contextWinforce, DbVFmid contextVFmid)
        {
            _contextWinforce = contextWinforce;
            _contextVFmid = contextVFmid;
        }

        [HttpPost("Leads")]
        public ActionResult<IEnumerable<tp_clientes>> Get(string motivo, ModelBusqueda model)
        {
            var cli = GetCliente(model.cliente.cli_num_doc);
            if (cli.Result == null)
            {
                RegistrarCliente(model.cliente);
                var cli2 = GetCliente(model.cliente.cli_num_doc);
                RegistrarLead(motivo, model, cli2.Result);
            }
            else
            {
                RegistrarLead(motivo, model, cli.Result);
                return Ok(cli);
            }

            return Ok(cli);

        }

        [NonAction]
        public Task<tp_clientes> GetCliente(string documento)
        {
            var cli = _contextWinforce.tp_clientes.FromSqlRaw("SELECT * FROM tp_clientes WHERE cli_num_doc = {0}", documento);
            return cli.FirstOrDefaultAsync();
        }
        [HttpGet("Cliente")]
        public ActionResult<Task<tp_clientes>> GetClientes()
        {
            var cli = _contextWinforce.tp_clientes.FromSqlRaw("SELECT * FROM tp_clientes TOP 10");
            return Ok(cli.ToListAsync());
        }

        [NonAction]
        public void RegistrarLead(string motivo, ModelBusqueda lead, tp_clientes cliente)
        {
            var busqueda = new md_busquedas
            {
                ide_cliente = cliente.ide_cli,
                latitud = lead.geofinder.latitud,
                longitud = lead.geofinder.longitud,
                direccion = lead.direccion,
                torre = lead.torre,
                bloque = lead.bloque,
                tipo_interes_Id = lead.tipo_interes_Id,
                vendedorId = lead.vendedorId,
                observaciones = motivo,
                canal = "AutoVenta",
                pasoWeb = lead.pasoWeb
            };
            _contextVFmid.md_busquedas.Add(busqueda);
            _contextVFmid.SaveChanges();
            Console.WriteLine("RegistrarLead" + motivo);
        }
        [NonAction]
        public void RegistrarCliente(tp_clientes cliente)
        {
            _contextWinforce.tp_clientes.Add(cliente);
            _contextWinforce.SaveChanges();
            Console.WriteLine("Registrar Cliente " + cliente.cli_num_doc);
        }
    }
}