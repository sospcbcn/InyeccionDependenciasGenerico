using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InyeccionDependencias.Services;

namespace InyeccionDependencias
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Configurar el Contenedor de Servicios
            InyeccionDependencias.Services.Bootstrap.InicializarContenedorServicios(services);
            
            // Add functionality to inject IOptions<T>
            services.AddOptions();

            //Configurar appsettings.json para aceptar Parametros Propios
            InyeccionDependencias.Services.MyConfig.InicializarArchivoConfiguracion(services, Configuration);
        }

        /*
        private void InicializarContenedorServicios(IServiceCollection services)
        {
            services.AddSingleton<IEmailService, EmailServiceDummy>();

            services.AddScoped<IServicioA, ServicioA>();
            services.AddScoped<IServicioB, ServicioB>();
            services.AddScoped<IServicioC, ServicioC>();
            services.AddScoped<IServicioD, ServicioD>();

            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
            services.AddTransient<OperationService, OperationService>();
        }
        */

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
