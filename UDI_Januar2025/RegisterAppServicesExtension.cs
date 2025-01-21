namespace UDI_Januar2025;

public static class RegisterAppServicesExtension
{
    public static void RegisterAppServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IFilService, FilService>();
        builder.Services.AddScoped<IDataLesService, DataLesService>();
    }
}
