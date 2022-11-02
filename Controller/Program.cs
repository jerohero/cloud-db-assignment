using BMH.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string? sqlServer = Environment.GetEnvironmentVariable("SqlConnectionString");

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContext<BMHContext>(
            options =>
            {
                options.UseSqlServer(sqlServer);
                options.EnableSensitiveDataLogging();
            });
        services.AddAutoMapper(cfg =>
        {
        });
    })
    .Build();

host.Run();
host.Run();
