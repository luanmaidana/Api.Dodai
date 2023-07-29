using System.Text.Json;
using System.Text.Json.Serialization;

namespace SgppAPI.Configuration;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection services)
    {

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
        {
            
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            MaxDepth = 10,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        services.AddSingleton(s => serializerOptions);
        services.AddControllers()
            .AddJsonOptions(options =>  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        // Ele é um método de extensão que adiciona endpoints mínimos sejam adicionados ao API explorer
        services.AddEndpointsApiExplorer();
    

        //  CORS (Cross Origin Resource Sharing) Compartilhamento de Recursos de Origem Cruzada 
        //  Permitir qualquer Header, Method, Credentials e Origins
        //https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0
        services.AddCors(opt => opt.AddPolicy("CorsPolicy",
            builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            }));
    }
}