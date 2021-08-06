using System.Threading.Tasks;

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
                        .Get<GetRoute, RouteDto>("routes/{routeId}")
                        .Get<SearchRoutes, PagedResult<RouteDto>>("routes")
                        .Post<CreateRoute>("routes",
                            afterDispatch: (cmd, ctx) => ctx.Response.Created($"routes/{cmd.RouteId}"))
                        .Put<ChangeRouteStatus>("routes/{routeId}/status/{status}",
                            afterDispatch: (cmd, ctx) => ctx.Response.NoContent())))
                .UseLogging()
                .UseVault();
    }
}