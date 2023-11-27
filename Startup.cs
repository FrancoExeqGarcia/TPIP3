namespace TODOLIST
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    public class Startup
    {
        // ConfigureServices method
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TODOLIST API", Version = "v1" });
            });
        }

        // Configure method
        public void Configure(IApplicationBuilder app)
        {
            // Configuración de Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TODOLIST API V1");
            });

            // Resto de la configuración...
        }
    }
}
