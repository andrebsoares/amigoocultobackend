using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Interfaces.Services;
using AmigoOculto.Repository.Context;
using AmigoOculto.Repository.Repositories;
using AmigoOculto.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Buffers;

namespace AmigoOculto.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AmigoOcultoContext>(options => 
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
              sqlOptions => sqlOptions.MigrationsAssembly("AmigoOculto.Repository")));

            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,                 
                }, ArrayPool<char>.Shared));
            });

            //services.AddMvc();

            // Configuração das services
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IGrupoUsuarioService, GrupoUsuarioService>();

            // Configuração dos repositories
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IGrupoUsuarioRepository, GrupoUsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
