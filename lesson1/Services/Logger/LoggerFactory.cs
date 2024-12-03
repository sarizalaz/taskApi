namespace TasksApi.Services.Logger
{
    public class LoggerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LoggerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILoggerService GetLogger(bool useFileLogger)
        {
            if (useFileLogger)
            {
                return _serviceProvider.GetRequiredService<FileLoggerService>();
            }

            return _serviceProvider.GetRequiredService<ILoggerService>();
        }
    }
}
