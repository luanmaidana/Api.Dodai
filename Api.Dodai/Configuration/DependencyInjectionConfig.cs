using Api.Dodai.Services.interfaces;
using Api.Dodai.Services;
using System.Text.Json.Serialization;
using System;
using Api.Dodai.Repository.Interface;
using Api.Dodai.Repository;
using Api.Dodai.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Dodai.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DodaiDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DodaiDB"));
            });
            var connectionString = configuration.GetConnectionString("DodaiDB");


            services.AddHealthChecks();
            services.AddTransient<IDodaiRepository, DodaiRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddControllers().AddJsonOptions(x =>
                      x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        }
    }
}
