using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InyeccionDependencias.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace InyeccionDependencias
{
    public class EnviarMensajeModel : PageModel
    {
        public EnviarMensajeModel()
        {           
        }
        public string Mensaje { get; set; }
        /*
        public IEmailService EmailService { get; }

        public IndexModel(IEmailService emailService)
        {
            EmailService = emailService;
        }
        
        public void OnGet()
        {
            Mensaje = EmailService.EnviarCorreo();
        }
        */

        public void OnGet([FromServices] IEmailService email)
        {
            Mensaje = email.EnviarCorreo();
        }
    }
}