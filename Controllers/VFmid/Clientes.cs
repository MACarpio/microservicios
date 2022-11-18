using Microsoft.AspNetCore.Mvc;
using ms.Context.SqlServer;
using Microsoft.EntityFrameworkCore;
using ms.Models.VFmid;

namespace ms.Controllers.VFmid
{
    [Route("api/[controller]")]
    [ApiController]
    public class Clientes : ControllerBase
    {
        private readonly DbVFmid _contextVFmid;

        public Clientes(DbVFmid contextVFmid)
        {
            _contextVFmid = contextVFmid;
        }

        [HttpPost("Leads")]
        public ActionResult<IEnumerable<tp_clientes>> Get(string motivo, ModelBusqueda model)
        {
            var cli = GetCliente(model.cliente.cli_num_doc);
            if (cli.Result == null)
            {
                tp_clientes cliente = new tp_clientes
                {
                    ide_tip_viv = model.cliente.ide_tip_viv,
                    ide_tip_doc = model.cliente.ide_tip_doc,
                    cli_nom = model.cliente.cli_nom,
                    cli_ape_pat = model.cliente.cli_ape_pat,
                    cli_ape_mat = model.cliente.cli_ape_mat,
                    cli_num_doc = model.cliente.cli_num_doc,
                    cli_tel1 = model.cliente.cli_tel1,
                    cli_email = model.cliente.cli_email
                };
                RegistrarCliente(cliente);
                var cli2 = GetCliente(cliente.cli_num_doc);
                RegistrarLead(motivo, model, cli2.Result);
                return Ok(new { message = "Cliente registrado y Lead registrado", Cliente = cli2.Result });
            }
            else
            {
                RegistrarLead(motivo, model, cli.Result);
                return Ok(new { message = "Lead registrado", Cliente = cli.Result });
            }

        }

        [NonAction]
        public Task<tp_clientes> GetCliente(string documento)
        {
            var cli = _contextVFmid.tp_clientes.FromSqlRaw("SELECT * FROM tp_clientes WHERE cli_num_doc = {0}", documento);
            return cli.FirstOrDefaultAsync();
        }

        [NonAction]
        public void RegistrarLead(string motivo, ModelBusqueda lead, tp_clientes cliente)
        {
            var busqueda = new md_busquedas
            {
                ide_cliente = Convert.ToInt32(cliente.ide_cli),
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
        }
        [NonAction]
        public void RegistrarCliente(tp_clientes cliente)
        {
            _contextVFmid.tp_clientes.Add(cliente);
            _contextVFmid.SaveChanges();
        }
    }
}