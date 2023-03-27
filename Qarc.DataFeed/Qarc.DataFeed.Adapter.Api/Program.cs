using Qarc.DataFeed.Core.Domain.Model;
using System.Reflection;
using Qarc.DataFeed.Adapter.Mongo.Bootstrapper;  // this is BAD - this adaptor should not know of other adaptors - create compositon root project
using Qarc.DataFeed.Adapter.Api.Hubs;
using Qarc.DataFeed.Core.Application.AddAggregatedData.Queries;

var api = new ApiAdapter(args, services =>
{
    //services.AddSingleton<ISettingsManager, SettingsManager>();

    //TODO: this forces me to add a dependency on mongo adaptor. Create composition root project and move this section in it.
    services.AddMongoServices()
    .AddMongoRepository<Bar>("BarCollection");
});

/// <summary>
/// This class will build and run the Web API app.
/// </summary>
public class ApiAdapter
{
    private WebApplication _app;

    /// <summary>
    /// We use the ctor to build the web API app.
    /// </summary>
    /// <param name="args"></param>
    /// <param name="options">Action Delegate that receives an IServiceCollection parameter for declaring DI elswhere</param>
    public ApiAdapter(string[] args, Action<IServiceCollection> options)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAutoMapper(typeof(ApiAdapter));
        builder.Services.AddSignalR();

        builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetBarsHandler).Assembly));
  
        // Add services to the container by invoking whatever method is passed through the action delegate whil passing it the builder.services so that it can add services.
        options.Invoke(builder.Services);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var _app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    _app.UseSwagger();
        //    _app.UseSwaggerUI();
        //}
        _app.UseSwagger();
        _app.UseSwaggerUI();

        _app.UseHttpsRedirection();

        _app.UseAuthorization();

        _app.MapControllers();

        _app.MapHub<AtasHub>("/atasHub");

        _app.Run();
    }
}

