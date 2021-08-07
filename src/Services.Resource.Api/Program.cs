using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Queries;
using Convey.Logging;
using Convey.Secrets.Vault;
using Convey.Types;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Services.Resource.Application;
using Services.Resource.Application.Commands;
using Services.Resource.Application.DTO;
using Services.Resource.Application.Queries;
using Services.Resource.Infrastructure;

namespace Services.Resource.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build())
                .Configure(app => app
                    .UseInfrastructure()
                    .UseDispatcherEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync(ctx.RequestServices.GetService<AppOptions>().Name))
                        .Get<SearchResources, PagedResult<TextResourceDto>>("resources")
                        .Post<CreateTextResource>("resources",
                            afterDispatch: (cmd, ctx) => ctx.Response.Created())))
                .UseLogging()
                .UseVault();
    }
}