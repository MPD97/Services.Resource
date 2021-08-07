using Services.Resource.Application;

namespace Services.Resource.Infrastructure
{
    public interface IAppContextFactory
    {
        IAppContext Create();
    }
}