using Api.CommonUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiServcer
{
  public  class InitApiServer
    {
        //FastHttpApi 作者博客地址 https://www.ikende.com
        private static BeetleX.FastHttpApi.HttpApiServer mApiServer;
        public Task OpenServer()
        {
            mApiServer = new BeetleX.FastHttpApi.HttpApiServer(new BeetleX.FastHttpApi.HttpOptions()
            {
                Port = ConfigSettings.Instance.Port,
                LogLevel = BeetleX.EventArgs.LogType.Warring,
                Manager = ConfigSettings.Instance.Manager,
                ManagerPWD = ConfigSettings.Instance.ManagerPWD,
                SSL = ConfigSettings.Instance.UseSSL,
                CertificateFile = ConfigSettings.Instance.SSLPath,
                CertificatePassword = ConfigSettings.Instance.SSLPwd,
                WriteLog = true,
                LogToConsole = true,
                SSLPort=ConfigSettings.Instance.SSLPort,
                WebSocketMaxRPS = 100000000
            });
            mApiServer.Debug();
            mApiServer.Register(typeof(BeetleX.FastHttpApi.Admin._Admin).Assembly);
            mApiServer.Register(typeof(Program).Assembly);
            mApiServer.Open();
            Console.Write(mApiServer.BaseServer);
            Console.Read();
            return Task.CompletedTask;
        }


        public Task OnStopServer()
        {
            mApiServer.Dispose();
            return Task.CompletedTask;
        }
    }
}
