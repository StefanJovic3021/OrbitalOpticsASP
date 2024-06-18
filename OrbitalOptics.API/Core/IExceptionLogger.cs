using OrbitalOptics.Application;

namespace OrbitalOptics.API.Core
{
    public interface IExceptionLogger
    {
        Guid Log(Exception ex, IApplicationActor actor);
    }
}
