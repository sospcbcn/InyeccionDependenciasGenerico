using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace InyeccionDependencias.Services
{
    public static class Bootstrap
    {
        public static void InicializarContenedorServicios(IServiceCollection services)
        {
            // Ejemplo de un Servicio Independiente
            services.AddSingleton<IEmailService, EmailServiceDummy>();

            // Servicios Utilizados para una Demostración Práctica de Inyección de Dependencias
            services.AddScoped<IServicioA, ServicioA>();
            services.AddScoped<IServicioB, ServicioB>();
            services.AddScoped<IServicioC, ServicioC>();
            services.AddScoped<IServicioD, ServicioD>();

            // Servicios Utilizados en la parte de CicloDeVida de los Servicios Transitorios, De Ámbito y Únicos.
            // Se pretende demostrar qué instancias se llegan a generar durante una Inyección de Dependencias.
            // Servicios Transitorios. Siempre que se genere un Servicio se tratará como una Instancia Distinta.
            services.AddTransient<IOperationTransient, Operation>();
            // Servicios de Ámbito. Se utilizará siempre la misma instancia dentro de una misma petición HTTP.
            services.AddScoped<IOperationScoped, Operation>();
            // Servicios Únicos. Utilizarán siempre la misma instancia hasta que se reinicie el Web Server.
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
            services.AddTransient<OperationService, OperationService>();
        }

    }
}
