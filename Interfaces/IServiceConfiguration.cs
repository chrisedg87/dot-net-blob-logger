using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logger
{
    public interface IServiceConfiguration
    {
        void InitializeContainer(IServiceCollection services, IConfiguration configuration);
    }
}