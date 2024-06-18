using OrbitalOptics.Application;
using OrbitalOptics.DataAccess;
using OrbitalOptics.Domain;

namespace OrbitalOptics.API.Core
{
    public class EfExceptionLogger : IExceptionLogger
    {
        private readonly OrbitalOpticsContext _aspContext;

        public EfExceptionLogger(OrbitalOpticsContext aspContext)
        {
            _aspContext = aspContext;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };

            _aspContext.ErrorLogs.Add(log);

            _aspContext.SaveChanges();

            return id;
        }
    }
}
