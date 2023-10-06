using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using users_api.BLL.Interfaces;
using users_api.BLL.Managers;
using users_api.BLL.Mapper;
using users_api.BLL.Services;
using users_api.DAL.EF;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    string path = string.Concat(Directory.GetCurrentDirectory(), "/nlog.config");
    LogManager.LoadConfiguration(path);
    builder.Services.AddDbContext<UsersContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"),
                                                b => b.MigrationsAssembly("users-api")));
    builder.Services.AddControllers();

    builder.Services.AddScoped<UserService>();
    var config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
    builder.Services.AddScoped<IMapper>(x => new Mapper(config));
    builder.Services.AddScoped<ILoggerManager, LoggerManager>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}