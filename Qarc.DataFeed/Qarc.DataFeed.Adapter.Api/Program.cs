using System.Reflection;

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

        builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        // Add services to the container by invoking whatever method is passed through the action delegate whil passing it the builder.services so that it can add services.
        options.Invoke(builder.Services);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var _app = builder.Build();

        // Configure the HTTP request pipeline.
        if (_app.Environment.IsDevelopment())
        {
            _app.UseSwagger();
            _app.UseSwaggerUI();
        }

        _app.UseHttpsRedirection();

        _app.UseAuthorization();

        _app.MapControllers();
    }

    public Task StartAsync()
    {
        return _app.RunAsync();
    }
}

