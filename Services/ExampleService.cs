using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AppConfigurationDemo.Services
{
    internal class ExampleService : IExampleService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExampleService> _logger;

        public ExampleService(IConfiguration configuration, ILogger<ExampleService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<string> DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ExampleService is doing work");
            
            await Task.Delay(1000, cancellationToken);
            
            return _configuration["AppSettings:ExampleSetting"];
        }
    }
}
