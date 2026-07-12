using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GPX.Negocio.Aceria
{
    public  class AceriaService
    {
        private readonly string cnn;

        public AceriaService(IConfiguration configuration)
        {
            cnn = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");
        }







        public async Task<List<BeamBlankNecesidad>> DameNecesidadBeamBlankTrenV2Async(string Sociedad, string CodMaquina)
        {
            try
            {
                using (var connection = new SqlConnection(cnn))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@Sociedad", Sociedad, DbType.String);
                    parametros.Add("@CodMaquina", CodMaquina, DbType.Int32);

                    var resultado = await connection.QueryAsync<BeamBlankNecesidad>(
                        "sp_DameNecesidadVirtualBeamBlankTrenV2",
                        parametros,
                        commandType: CommandType.StoredProcedure
                    );

                    return resultado.AsList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_DameNecesidadVirtualBeamBlankTrenV2 detalle: \n" + ex.Message, ex);
            }
        }


        public async Task<List<ListTundishDisponibles>> ConsultaTundishDisponiblesAsync(int horasRequeridas, DateTime fechaInicial, string TipoSemi)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    var resultado = await db.QueryAsync<ListTundishDisponibles>(
                        sql: "sp_CosultaTundishDisponiblesEnCalendario", param: new
                        {
                            horasRequeridas,
                            fechaInicial,
                            TipoSemi

                        }, commandType: CommandType.StoredProcedure);

                    return resultado.AsList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar sp_CosultaTundishDisponiblesEnCalendario, detalle: \n" + ex.Message, ex);
            }

        }



    }
}
