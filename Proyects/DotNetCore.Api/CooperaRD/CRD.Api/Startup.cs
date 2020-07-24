using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CRD.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using CRD.Domain.Interfaces;
using CRD.InfraData.Repositories;
using Microsoft.OpenApi.Models;
using CRD.AplicationCore.Interfaces.Validations;
using CRD.AplicationCore.Validations;
using CRD.AplicationCore.Interfaces;
using CRD.AplicationCore.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using CRD.Api.Route_transformer;

namespace CRD.Api
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
            services.AddControllers();
            
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            });

            services.AddDbContext<CooperaDBContext>(confi =>
            confi.UseSqlServer(Configuration.GetConnectionString("CooperaRDData")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CooperaRD", Version = "v1" });
            });

            //TODO validar cuando los GetAll esten vacios diga: No existen datos registrados 
            services.AddScoped<IMasterRepository, MasterRepository>();

            services.AddScoped<IGeneralValidationService, GeneralValidationService>();

            services.AddScoped<IRegionValidationService, RegionValidationService>();
            services.AddScoped<IRegionService, RegionService>();

            services.AddScoped<IProvinciaService, ProvinciaService>();
            services.AddScoped<IProvinciaValidationService, ProvinciaValidationService>();

            services.AddScoped<IMunicipioService, MunicipioService>();
            services.AddScoped<IMunicipioValidationService, MunicipioValidationService>();

            services.AddScoped<IDistritoMunicipalService, DistritoMunicipalService>();
            services.AddScoped<IDistritoMunicipalValidationService, DistritoMunicipalValidationService>();

            services.AddScoped<ISeccionService, SeccionService>();
            services.AddScoped<ISeccionValidationService, SeccionValidationService>();

            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<ISectorValidationService, SectorValidationService>();

            services.AddScoped<IBarrioService, BarrioService>();
            services.AddScoped<IBarrioValidationService, BarrioValidationService>();

            services.AddScoped<IStatusIncidenciaService, StatusIncidenciaService>();
            services.AddScoped<IStatusIncidenciaValidationService, StatusIncidenciaValidationService>();

            services.AddScoped<ITipoIncidenciaService, TipoIncidenciaService>();
            services.AddScoped<ITipoIncidenciaValidationService, TipoIncidenciaValidationService>();

            services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
            services.AddScoped<ITipoDocumentoValidationService, TipoDocumentoValidationService>();

            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<ICargoValidationService, CargoValidationService>();

            services.AddScoped<IEntidadMunicipalService, EntidadMunicipalService>();
            services.AddScoped<IEntidadMunicipalValidationService, EntidadMunicipalValidationService>();

            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
            services.AddScoped<ITipoUsuarioValidationService, TipoUsuarioValidationService>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioValidationService, UsuarioValidationService>();

            services.AddScoped<IIncidenciaService, IncidenciaService>();
            services.AddScoped<IIncidenciaValidationService, IncidenciaValidationService>();

            services.AddScoped<IIncidenciaUsuarioService, IncidenciaUsuarioService>();
            services.AddScoped<IIncidenciaUsuarioValidationService, IncidenciaUsuarioValidationService>();

            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IRolValidationService, RolValidationService>();

            services.AddScoped<IJuntaDeVecinosService, JuntaDeVecinosService>();
            services.AddScoped<IJuntaDeVecinosValidationService, JuntaDeVecinosValidationService>();

            services.AddScoped<IIntegranteJdVService, IntegranteJdVService>();
            services.AddScoped<IIntegranteJdVValidationService, IntegranteJdVValidationService>();

            services.AddScoped<ILoginService, LoginService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
       
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coopera RD V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
