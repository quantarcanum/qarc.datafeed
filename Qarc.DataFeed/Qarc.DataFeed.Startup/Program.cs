namespace Qarc.DataFeed.Startup
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // calling ctor with args and anonymous method receiving IServiceCollection param for hooking up the DI classes.
            var api = new ApiAdapter(args, services =>
            {
                //services.AddSingleton<ISettingsManager, SettingsManager>();

                ////var mongoConfig = services.GetService<ISettingsManager>();
                ////serviceCollection.AddScoped<>(IInterface, Class);
                ////var services = Microsoft.Extensions.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

                //services.AddMongoServices().AddMongoRepository<Bar>("BarCollection");
            });
            //await api.StartAsync();
        }
    }
}