namespace EventsApi;

using EventsApi.Data;
using EventsApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

public class Startup
{
    private readonly IConfiguration configuration;
    
    public Startup(IConfiguration configuration) =>
        this.configuration = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventsApi", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            application.UseDeveloperExceptionPage();
            application.UseSwagger();
            application.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventsApi v1"));
        }

        application.UseHttpsRedirection();
        application.UseRouting();
        application.UseAuthorization();
        application.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}