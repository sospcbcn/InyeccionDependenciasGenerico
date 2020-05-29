using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias.Services
{
    public class EmailServiceDummy : IEmailService
    {
        private IOptions<MyConfig> config;

        public EmailServiceDummy(IOptions<MyConfig> _config)
        {
            this.config = _config;
        }

        public string EnviarCorreo()
        {                     
            return config.Value.ResultadoEnviarMensaje;
        }
    }
}
