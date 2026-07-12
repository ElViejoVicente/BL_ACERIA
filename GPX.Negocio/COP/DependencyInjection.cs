using GPX.Negocio.Aceria;
using GPX.Negocio.CRUD;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.COP
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNegocio(this IServiceCollection services)
        {
            services.AddScoped<CrudRepository>();
            services.AddScoped<AceriaService>();
            services.AddScoped<CalendarioFusionHornoService>();
            services.AddScoped<ConfiguracionTundishService>();


            // STATE CONTAINER
            services.AddScoped<VersionTundishSeleccionadoState>();

            return services;
        }
    }
}
