namespace ClothesShop.API.Extensions;

public static class ApplicationExtensions
{
    public static void UseInfrastructure(this IApplicationBuilder app, WebApplicationBuilder builder)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
            $"{builder.Environment.ApplicationName} v1"));

        app.UseResponseCompression();
        app.UseCors("AllowAll");
        app.UseRouting();
        app.UseResponseCaching();
        app.UseRequestTimeouts();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}   