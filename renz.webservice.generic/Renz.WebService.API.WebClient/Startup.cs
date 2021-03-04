using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RivTech.WebService.Generic.DataProvider;
using RivTech.WebService.Generic.DataProvider.Repository;
using RivTech.WebService.Generic.Service;
using RivTech.WebService.Generic.Service.Services;
using RivTech.WebService.Security;
using System;
using RivTech.WebService.Generic.Data.Context;
using AutoMapper;
using RivTech.WebService.Generic.DTO.DTOMapping;
using Autofac;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.WebClient
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
            RegisterDatabase(services);
            services.AddCors(o => o.AddPolicy("TestEnvironment", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers()
                    .AddFluentValidation();

            services.AddSwaggerGen(cc =>
            {
                cc.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Services",
                    Version = "v1",
                    Description = "An API to perform",
                });


                cc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });


                cc.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });


            });





            var conn = Configuration.GetConnectionString("ConDefinedData");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

            SetAutoMapper(services); //Set AutoMapper
            SetUpValidators(services);
            JWTSecurity.RegisterJWTAuthentication(services);            
        }        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("TestEnvironment");
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                });
                endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
                {
                    Predicate = r => r.Name.Contains("self"),
                });
            });

            app.UseStaticFiles();

            app.UseSwagger(o =>
            {
                o.RouteTemplate = "Documents/{documentName}/docs.json";
            });

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.DefaultModelsExpandDepth(-1); //Hide Model
                // c.DefaultModelsExpandDepth(0); //Show Model
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

                c.RoutePrefix = "Documents"; //OK
                c.SwaggerEndpoint("/Documents/v1/docs.json", "API Services");

            });
        }

        private void RegisterDatabase(IServiceCollection services)
        {
            var databaseSection = Configuration.GetSection("ConnectionStrings");
            var connectionString = databaseSection.GetValue<string>("ConDefinedData");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        // Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    }));
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddSqlServer(
                    connectionString,
                    name: "RivTech.Generic-check",
                    tags: new string[] { "RivTech.Generic" });
        }

        
       


        private void SetUpValidators(IServiceCollection services)
        {
        }        

        private void SetAutoMapper(IServiceCollection services)
        {            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        #region Dependency Injection        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<DefinedDataContext>().As<IDefinedDataContext>().InstancePerLifetimeScope();

            #region Service
            builder.RegisterType<ShapeService>().As<IShapeService>().InstancePerLifetimeScope();
            builder.RegisterType<WeightService>().As<IWeightService>().InstancePerLifetimeScope();
            builder.RegisterType<ItemService>().As<IItemService>().InstancePerLifetimeScope();
            #endregion

            #region DataProvider
            builder.RegisterType<WeightRepository>().As<IWeightRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ItemRepository>().As<IItemRepository>().InstancePerLifetimeScope();
            #endregion
        }
        #endregion
    }
}
