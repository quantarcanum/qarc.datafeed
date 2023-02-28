// calling ctor with args and anonymous method receiving IServiceCollection param for hooking up the DI classes.
var api = new ApiAdapter(args, serviceCollection =>
{
    //serviceCollection.AddScoped<>(IInterface, Class);
});
await api.StartAsync();