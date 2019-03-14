using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.CommonUtils
{
    /// <summary>
    /// 获取configjson中的配置信息
    /// </summary>
    public class ConfigSettings
    {
        private static readonly Lazy<ConfigSettings> _instance = new Lazy<ConfigSettings>(() => new ConfigSettings());

        public static ConfigSettings Instance => _instance.Value;

        public IConfiguration Configuration { get; }

        private ConfigSettings()
        {
            //获取项目下config.json的配置信息
            var path = AppDomain.CurrentDomain.BaseDirectory;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("Config.json", false, true)
                .Add(new JsonConfigurationSource { Path = "Config.json", Optional = false, ReloadOnChange = true })
                .Build();
        }
        /// <summary>
        /// mysql数据库
        /// </summary>
        public string MySqlConnectionString => Configuration["ConnectionStrings:Api.Mysql"];

        /// <summary>
        /// sqlserver数据库
        /// </summary>
        public string SqlServerConnectionString => Configuration["ConnectionStrings:Api.SqlServer"];

        /// <summary>
        /// 端口
        /// </summary>
        public int Port => Convert.ToInt32(Configuration["ServerSettings:Port"]);

        /// <summary>
        /// 管理端登录账号
        /// </summary>
        public string Manager => Configuration["ServerSettings:Manager"];
        /// <summary>
        /// 管理端登录密码
        /// </summary>
        public string ManagerPWD => Configuration["ServerSettings:ManagerPWD"];
        /// <summary>
        /// 自动同步实体到数据库
        /// </summary>
        public bool UseAutoSyncStructure => Convert.ToBoolean(Configuration["ConnectionStrings:Api.UseCodefirst"]);

        /// <summary>
        /// 使用https
        /// </summary>
        public bool UseSSL => Convert.ToBoolean(Configuration["ServerSettings:UseSSL"]);
        /// <summary>
        /// 证书路径
        /// </summary>
        public string SSLPath => AppDomain.CurrentDomain.BaseDirectory + Configuration["ServerSettings:CertificateFile"];
        /// <summary>
        /// 证书密码
        /// </summary>
        public string SSLPwd => Configuration["ServerSettings:CertificatePassword"];
        /// <summary>
        /// SSL端口
        /// </summary>
        public int SSLPort=> Convert.ToInt32(Configuration["ServerSettings:SSLPort"]);
    }
}
