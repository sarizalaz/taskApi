using lesson3.DAL;
using TasksApi.Services.Logger;
using lesson1.models;
using lesson1.DAL;

namespace lesson1.Services.Logger
{
    public class DbLoggerService : ILoggerService
    {
        private readonly ILoggerDal _LoggerDal;
        public DbLoggerService(ILoggerDal LoggerDal)
        {
            _LoggerDal = LoggerDal;
        }
        public void Log(string message)
        {
            _LoggerDal.Add(message);
        }
    }
}
