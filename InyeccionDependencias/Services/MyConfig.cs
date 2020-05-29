using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias.Services
{
    public class MyConfig
    {
        public string ResultadoInyeccionDependencias { get; set; }
        public string ResultadoEnviarMensaje { get; set; }

        public static void InicializarArchivoConfiguracion(IServiceCollection services, IConfiguration Configuration)
        {
            // Inyectar al Servicio MyConfig los parámetros del apartado "MyConfig" del appsettings.json 
            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));
        }
    }
}
