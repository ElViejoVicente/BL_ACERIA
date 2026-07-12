using Dapper;
using GPX.Negocio.ORM;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public class ConfiguracionTundishService
    {

        private readonly string cnn;

        public ConfiguracionTundishService(IConfiguration configuration)
        {
            cnn = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");
        }



        public async Task<Boolean> ActivaVersionTundish(string IdVersion)
        {
            try
            {
                using (var db = new SqlConnection(cnn))
                {
                    await db.ExecuteAsync(sql: "sp_ActivaVersionTundish", param: new
                    {
                        IdVersion,
                    }, commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_ActivaVersionTundish, detalle: \n" + ex.Message, ex);
            }

        }



        public async Task<List<ConfiguracionTundishControl>> CansultaVercionXRango(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                using var db = new SqlConnection(cnn);

                var resultado = await db.QueryAsync<ConfiguracionTundishControl>(
                    sql: "sp_ConsultaConfiguracionTundishControlxRango",
                    param: new
                    {
                        FechaInicio,
                        FechaFin
                    },
                    commandType: CommandType.StoredProcedure
                );

                return resultado.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_ConsultaConfiguracionTundishControlxRango, detalle: \n" + ex.Message, ex);
            }
        }



    }
}
