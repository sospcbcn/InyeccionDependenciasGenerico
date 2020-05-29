using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias.Services
{
    public interface IServicioA {
        string ObtenerMensaje();
    }
    public interface IServicioB {}
    public interface IServicioC {}
    public interface IServicioD {}

    public class ServicioA : IServicioA
    {
        private IOptions<MyConfig> config;
        public ServicioA(IServicioB servicioB, IServicioC servicioC, IOptions<MyConfig> _config)
        {
            config = _config;
        }

        public string ObtenerMensaje()
        {
            return config.Value.ResultadoInyeccionDependencias;
        }
    }

    public class ServicioB : IServicioB
    {
        public ServicioB(IServicioC servicioC ,IServicioD servicioD)
        {

        }
    }

    // Ejemplo de Uso: Gestión de Login
    public class ServicioC : IServicioC
    {

    }

    public class ServicioD : IServicioD
    {
        public ServicioD(IServicioC servicioC)
        {

        }
    }

}
