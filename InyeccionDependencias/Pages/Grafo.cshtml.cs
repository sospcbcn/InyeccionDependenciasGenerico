using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InyeccionDependencias.Services;

namespace InyeccionDependencias.Pages
{
    public class GrafoModel : PageModel
    {
        /*
        public GrafoModel()
        {
            // Contructor de la Clase SIN Inyección de Dependencias
            var _servicioA = new ServicioA(new ServicioB(new ServicioC(), new ServicioD(new ServicioC())), new ServicioC());
            ServicioA = _servicioA;
        }
        */

        public GrafoModel(IServicioA servicioA)
        {            
            // Constructor de la Clase CON Inyección de Dependencias. 
            // El resultado será el mismo pero la Inyección de Dependencias nos ha simplificado mucho la codificación.
            ServicioA = servicioA;
            MensajeDelServicio = ServicioA.ObtenerMensaje();
        }

        public string MensajeDelServicio { get; private set; }
        public IServicioA ServicioA { get; }

        public void OnGet()
        {
        }
    }
}