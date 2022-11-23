using Microsoft.AspNetCore.Mvc;
using ms.Context.SqlServer;
using Microsoft.EntityFrameworkCore;
using ms.Models.VFmid;

namespace ms.Controllers.VFmid
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lead : ControllerBase
    {
        private readonly DbVFmid _contextVFmid;

        public Lead(DbVFmid contextVFmid)
        {
            _contextVFmid = contextVFmid;
        }

        [NonAction]
        public Task<tp_clientes> GetCliente(string documento)
        {
            var cli = _contextVFmid.tp_clientes.FromSqlRaw("SELECT * FROM tp_clientes WHERE cli_num_doc = {0}", documento);
            return cli.FirstOrDefaultAsync();
        }

        [NonAction]
        public void RegistrarLead(ModelLeadCompleto lead, tp_clientes cliente)
        {
            var busqueda = new tp_i_busquedas
            {
                ide_i_cli = Convert.ToInt32(cliente.ide_cli),
                ide_i_soc = lead.ide_i_soc,
                ide_i_pre_soc = lead.ide_i_pre_soc,
                i_ide_edi = lead.i_ide_edi,
                i_ide_tip_int = lead.i_ide_tip_int,
                i_bus_tip = lead.i_bus_tip,
                i_bus_dir_ref = lead.i_bus_dir_ref,
                i_bus_ubigeo = lead.geofinder.bus_ubigeo,
                i_bus_res = lead.geofinder.bus_res,
                i_bus_lat = lead.geofinder.bus_lat,
                i_bus_lng = lead.geofinder.bus_lng,
                i_bus_dir = lead.geofinder.bus_dir,
                i_bus_obs = lead.i_bus_obs,
                i_num_departament = lead.i_num_departament,
                i_bus_seg_est = lead.i_bus_seg_est,
                i_seg_prox_fecha = lead.i_seg_prox_fecha,
                i_seller_id = 15,
                i_seller_type = "Autoventa",
                cli_ubi_dep = lead.cli_ubi_dep,
                cli_ubi_dis = lead.cli_ubi_dis,
                cli_ubi_prov = lead.cli_ubi_prov,
                cond_torre = lead.cond_torre,
                score_equifax = lead.score_equifax,
                bus_cod_postal = lead.bus_cod_postal,
                bus_cod_postal_text = lead.bus_cod_postal_text,
                num_piso = lead.num_piso,
                ide_venta_origen = lead.ide_venta_origen,
                utm_source = lead.utm_source,
                utm_medium = lead.utm_medium,
                utm_campaign = lead.utm_campaign,
                paso_proceso = lead.paso_proceso,
                id_consulta_web = lead.id_consulta_web,
                estado = lead.estado,
                updated_at = DateTime.Now,
                created_at = DateTime.Now
            };
            _contextVFmid.tp_i_busquedas.Add(busqueda);
            _contextVFmid.SaveChanges();
        }
        [NonAction]
        public void RegistrarCliente(tp_clientes cliente)
        {
            _contextVFmid.tp_clientes.Add(cliente);
            _contextVFmid.SaveChanges();
        }


        [HttpPost("Nuevo")]
        public ActionResult<IEnumerable<tp_clientes>> NuevoLead(ModelLeadCompleto model)
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
                RegistrarLead(model, cli2.Result);
                return Ok(new { message = "Cliente registrado y Lead registrado", Cliente = cli2.Result });
            }
            else
            {
                RegistrarLead(model, cli.Result);
                return Ok(new { message = "Lead registrado", Cliente = cli.Result });
            }

        }
    }
}