using Inventory.Application;
using Inventory.Application.Common.Interfaces;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Tests
{
    public class TestHostBuilder : IDisposable
    {
        public IHost _host;
        public IConfiguration Configuration = InitConfiguration();

        public TestHostBuilder()
        {

            Environment.SetEnvironmentVariable("TEST_ENV", "on");
            var hostBuilder = new HostBuilder()
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 IHostEnvironment env = hostingContext.HostingEnvironment;
                 Console.WriteLine($"App is runnign in {env.EnvironmentName} environment.");

                 var reloadOnChange =
                     hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", defaultValue: true);

                 config.AddJsonFile($"appSettings.Test.json", optional: true, reloadOnChange: reloadOnChange);
                 hostingContext.Configuration.Bind(env.EnvironmentName, config);
                 config.AddEnvironmentVariables();
             })
            .ConfigureServices((ctx, services) =>
            {
                services.AddApplication();
                services.AddInfrastructure(Configuration);
                services.AddDbContext<InventoryDbContext>(options =>
                 options.UseInMemoryDatabase("InventoryDb"));

            })
            .UseEnvironment("Test");
            _host = hostBuilder.Start();

            var q = _host.Services;
        }
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appSettings.Test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }
        public IMediator GetMediator()
        {
            try
            {
                return _host.Services.GetService<IMediator>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IApplicationContext GetApplicationContext()
        {
            try
            {
                return _host.Services.GetService<IApplicationContext>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Dispose()
        {
            _host?.Dispose();
        }






    }
}
