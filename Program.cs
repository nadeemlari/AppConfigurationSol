// See https://aka.ms/new-console-template for more information

using AppConfigurationDemo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AppConfigurationDemo.HostedServices;
using AppConfigurationDemo.Services;

CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddLogging();
            services.AddTransient<IExampleService, ExampleService>();
            services.AddHostedService<HostedService>();
        })
        .ConfigureAppConfiguration(options =>
        {
            var settings = options.SetBasePath(AppContext.BaseDirectory)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json",
                    optional: true).Build();
            options.AddAzureAppConfiguration(o =>
            {
                o.Connect(new Uri(settings["AppConfiguration"]), AzureCredentialBuilder.Credential());
            });
        });