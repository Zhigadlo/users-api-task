using AutoMapper;
using Contracts.Logger;
using Contracts.Repository;
using Contracts.Service;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using users_api.BLL.Managers;
using users_api.BLL.Mapper;
using users_api.DAL.EF;
using users_api.DAL.Managers;
using users_api.Middleware;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
string path = string.Concat(Directory.GetCurrentDirectory(), "/nlog.config");
LogManager.Setup().LoadConfigurationFromFile(path);

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddDbContext<UsersContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"),
                                                b => b.MigrationsAssembly("users-api")));
    builder.Services.AddControllers();

    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
    var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>
    {
        new RoleProfile(),
        new UserProfile(),
        new UserRoleProfile()
    }));
    builder.Services.AddScoped<IMapper>(x => new Mapper(config));
    builder.Services.AddTransient<ILoggerManager, LoggerManager>();
    builder.Services.AddScoped<IServiceManager, ServiceManager>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    app.MigrateDatabase<UsersContext>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ExceptionMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}