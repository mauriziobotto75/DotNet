using Capgemini.Invent.DeliveryPulse.Intranet.Business.EMonitoring;
using Capgemini.Invent.DeliveryPulse.Intranet.Data;
using Capgemini.Invent.DeliveryPulse.Intranet.Data.Repository;
using Capgemini.Invent.DeliveryPulse.Intranet.Entity.DTO.EMonitoring;
using Capgemini.Invent.DeliveryPulse.Intranet.Entity.Persistence;
using Capgemini.Invent.DeliveryPulse.Intranet.Interface.Data;
using Capgemini.Invent.DeliveryPulse.Intranet.Interface.Data.Repository;
using Capgemini.Invent.DeliveryPulse.Intranet.Interface.EMonitoring;
using Microsoft.EntityFrameworkCore;
#pragma warning disable IDE0005 // Using directive is unnecessary.
using Microsoft.Extensions.Logging.Debug;
#pragma warning restore IDE0005 // Using directive is unnecessary.

namespace Capgemini.Invent.DeliveryPulse.Intranet.Job.MasterDataSync
{
    public static class Program
    {
#if DBG
        public static readonly LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
                new DebugLoggerProvider()
            });
#endif
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
#if DBG
            .AddJsonFile("appsettings.DBG.json")
#elif UAT
            .AddJsonFile("appsettings.UAT.json")
#elif PROD
            .AddJsonFile("appsettings.PROD.json")
#endif
                .Build();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                    {
                        services.AddHostedService<Worker>();
                        services.AddSingleton<IEMonitoringWebApi, EMonitoringWebApi>();
                        services.AddSingleton<IRepository<Engagement>, GenericRepository<Engagement>>();
                        services.AddSingleton<IRepository<Country>, GenericRepository<Country>>();
                        services.AddSingleton<IRepository<Industry>, GenericRepository<Industry>>();
                        services.AddSingleton<IUnitOfWork, UnitOfWork>();
                        services.AddDbContext<DeliveryPulseDbContext>(options =>
                        {
                            options.UseNpgsql(configuration.GetConnectionString("DeliveryPulse"));
#if DBG
                            options.UseLoggerFactory(_myLoggerFactory);
                            options.EnableSensitiveDataLogging(true);
#endif
                        }, ServiceLifetime.Singleton);
                        services.AddOptions<EMonitoringSettings>()
                            .BindConfiguration("EMonitoringSettings");
                    })
                .ConfigureHostConfiguration(builder =>
                    {
                        builder
#if DBG
        .AddJsonFile("appsettings.DBG.json")
#elif UAT
            .AddJsonFile("appsettings.UAT.json")
#elif PROD
            .AddJsonFile("appsettings.PROD.json")
#endif
        ;
                    })
                .Build();

            host.Run();
        }
    }
}