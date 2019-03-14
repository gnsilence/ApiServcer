using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Microsoft.Extensions.Logging;
using ApiServcer.IocContainer;
using Api.Services;
using Api.IService;

namespace ApiServcer
{
    class Program
    {

        #region 创建服务相关.使用Generic host
        static void Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IHostLifetime, OwnLifetime>();
                    services.AddHostedService<HttpServerHosted>();
                    AutofacContainer.Register("Api.Services", "Api.IService");
                    AutofacContainer.SetCodeFirstAsync("Api.Models");//使用codefirst
                    AutofacContainer.Build(services);//使用ioc注入
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddEventLog();//启用系统事件日志，
                })
                ;

            //builder.Build().Run();
            HostFactory.Run(x =>
            {
                //服务名称
                x.SetServiceName("ApiService");
                //服务展示名称
                x.SetDisplayName("ApiService");
                //服务描述
                x.SetDescription("Api服务");
                //服务启动类型：自动
                x.StartAutomatically();
                //x.RunAsLocalSystem();
                x.Service<IHost>(s =>
                {
                    s.ConstructUsing(() => builder.Build());

                    s.WhenStarted(service =>
                    {
                        service.Start();
                    });

                    s.WhenStopped(service =>
                    {
                        service.StopAsync();
                    });
                });
            });
        }
        #endregion

        #region Api启动和停止
        public class HttpServerHosted : IHostedService
        {
            InitApiServer InitApiServer = new InitApiServer();
            public virtual Task StartAsync(CancellationToken cancellationToken)
            {
                InitApiServer.OpenServer();
                return Task.CompletedTask;
            }


            public virtual Task StopAsync(CancellationToken cancellationToken)
            {
                InitApiServer.OnStopServer();
                return Task.CompletedTask;
            }

        }
        #endregion
    }
}
