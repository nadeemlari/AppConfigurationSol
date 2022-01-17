namespace AppConfigurationDemo.Services
{
    internal interface IExampleService
    {
        Task<string> DoWork(CancellationToken cancellationToken);
    }
}
