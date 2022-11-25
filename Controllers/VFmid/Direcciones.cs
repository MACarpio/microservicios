using Microsoft.AspNetCore.Mvc;
using ms.Context.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace ms.Controllers.VFmid
{
    [Route("api/[controller]")]
    [ApiController]
    public class Direcciones : ControllerBase
    {
        private readonly DbVFmid _dbmid;
        private readonly DbCRM _dbcrm;
        private readonly DbECOM _dbecom;
        public Direcciones(DbVFmid dbmid, DbCRM dbcrm, DbECOM dbecom)
        {
            _dbmid = dbmid;
            _dbcrm = dbcrm;
            _dbecom = dbecom;
        }

        [HttpGet("ValidarFlag")]
        public ActionResult<IEnumerable<String>> GetFlag(string TipoVia, string DescVia, string Numeracion, string Manzana, string Lote, string DescNivel, string DescInmueble)
        {
            var cli = _dbcrm.query.FromSqlRaw("SELECT DISTINCT cd.DOCI_COD_DOCUMENTO ,cc.CLIV_NUMERO_DOCUMENTO ,cd.DOCC_COD_TIPO_ESTADO ,cd.DOCC_COD_TIPO_SUB_ESTADO FROM CRM.CRM_DOCUMENTO cd inner join CRM.CRM_CLIENTE_DIRECCION ccd on cd.DOCI_COD_CLIENTE = ccd.RCDI_COD_CLIENTE inner join CRM.CRM_CLIENTE cc on ccd.RCDI_COD_CLIENTE = cc.CLII_COD_CLIENTE inner join CRM.CRM_DIRECCION cd2 on ccd.RCDI_COD_DIRECCION =cd2.DIRI_COD_DIRECCION where cd2.DIRC_COD_TIPO_VIA = {0} AND cd2.DIRV_DESCRIPCION_VIA = {1} AND cd2.DIRV_DESCRIPCION_NUMERACION = {2} AND cd2.DIRV_MANZANA = {3} AND cd2.DIRV_LOTE = {4} and cd2.DIRV_DESCRIPCION_NIVEL = {5} and cd2.DIRV_DESCRIPCION_INMUEBLE = {6}", TipoVia, DescVia, Numeracion, Manzana, Lote, DescNivel, DescInmueble).ToList();
            if (cli.Count == 0)
            {
                return Ok(new { flag = 0, data = cli });
            }
            else
            {
                int susDueda = 0;
                int susAPC = 0;
                int bajaAPC = 0;
                int bajaFraude = 0;
                int serActivoDeuda = 0;
                for (int i = 0; i < cli.Count; i++)
                {
                    if (cli[i].DOCC_COD_TIPO_ESTADO == "03")
                    {
                        var cantidad = _dbecom.Cantidad.FromSqlRaw("SELECT TOP 10 Count(*) as cantidad FROM ECOM.COMPROBANTE C INNER JOIN ECOM.ECOM_EMPRESA_CLIENTE ECL ON C.EMCI_ID_EMP_CLI = ECL.EMCI_ID_EMP_CLI INNER JOIN ECOM.ECOM_CLIENTE CL ON ECL.CLII_ID_CLIENTE = CL.CLII_ID_CLIENTE WHERE COMC_COD_EMPRESA = 15 AND CL.CLIV_NRO_RUC = {0} AND C.ESTI_ID_ESTADO = 7 AND C.COMC_FEC_VENCIMIENTO < GETDATE() ORDER BY 1 DESC", cli[i].CLIV_NUMERO_DOCUMENTO).FirstOrDefault();
                        serActivoDeuda = serActivoDeuda + cantidad.cantidad;
                    }
                    if (cli[i].DOCC_COD_TIPO_ESTADO == "07" || cli[i].DOCC_COD_TIPO_ESTADO == "06")
                    {
                        //Validar Dueda, Sus-APC, Baja-APC o Baja-Fraude

                        if (cli[i].DOCC_COD_TIPO_SUB_ESTADO == null)
                        {
                            susDueda++;
                        }
                        if (cli[i].DOCC_COD_TIPO_SUB_ESTADO == "01")
                        {
                            susAPC++;
                        }
                        if (cli[i].DOCC_COD_TIPO_SUB_ESTADO == "02")
                        {
                            bajaAPC++;
                        }
                        if (cli[i].DOCC_COD_TIPO_SUB_ESTADO == "03")
                        {
                            bajaFraude++;
                        }
                    }
                }
                string mensaje = Mensaje(serActivoDeuda, "SER-ACTIVO-DEUDA") + Mensaje(susDueda, "SUS-DEUDA") + Mensaje(susAPC, "SUS-APC") + Mensaje(bajaAPC, "BAJA-APC") + Mensaje(bajaFraude, "BAJA-FRAUDE");
                return Ok(new { flag = 1, mensaje = mensaje });
            }
        }

        [NonAction]
        public string Mensaje(int cant, string mensaje)
        {
            if (cant == 0)
            {
                return "";
            }
            else
            {
                return cant + " " + mensaje + ",";
            }
        }

    }
}