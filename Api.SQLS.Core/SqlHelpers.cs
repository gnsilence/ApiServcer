using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.Json;
using Api.CommonUtils;
using System;

namespace Api.SQLS.Core
{
    public class SqlHelpers
    {
        //private static IConfigurationRoot configuration;
        //public SqlHelpers()
        //{
        //    var builder = new ConfigurationBuilder();
        //    builder.AddJsonFile("Config.json");
        //    configuration = builder.Build();
        //}
        public static IFreeSql MySql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.MySql, ConfigSettings.Instance.MySqlConnectionString)
        .UseLogger(new LoggerFactory().CreateLogger("FreeSql.MySql"))
        .UseAutoSyncStructure(ConfigSettings.Instance.UseAutoSyncStructure)//自动同步实体到数据库
        .UseLazyLoading(true)
        //.UseMonitorCommand(
        //cmd => Console.WriteLine(cmd.CommandText), //监听SQL命令对象，在执行前
        //(cmd, traceLog) => Console.WriteLine(traceLog)) //监听SQL命令对象，在执行后
        .Build();


        public static IFreeSql SqlServer = new FreeSql.FreeSqlBuilder()
       .UseConnectionString(FreeSql.DataType.SqlServer, ConfigSettings.Instance.SqlServerConnectionString)
       .UseLogger(new LoggerFactory().CreateLogger("FreeSql.SqlServer"))
       //.UseMonitorCommand(
       // cmd => Console.WriteLine(cmd.CommandText), //监听SQL命令对象，在执行前
       // (cmd, traceLog) => Console.WriteLine(traceLog)) //监听SQL命令对象，在执行后
       .UseAutoSyncStructure(ConfigSettings.Instance.UseAutoSyncStructure)//自动同步实体到数据库
       .Build();

        // public static IFreeSql Oracle = new FreeSql.FreeSqlBuilder()
        //.UseConnectionString(FreeSql.DataType.Oracle, "Data Source=127.0.0.1;Port=3306;User ID=root;Password=root;Initial Catalog=cccddd;Charset=utf8;SslMode=none;Max pool size=100")
        //.UseLogger(new LoggerFactory().CreateLogger("FreeSql.Oracle"))
        //.UseAutoSyncStructure(false)
        //.Build();

        //  public static IFreeSql PostgreSQL = new FreeSql.FreeSqlBuilder()
        //.UseConnectionString(FreeSql.DataType.PostgreSQL, "Data Source=127.0.0.1;Port=3306;User ID=root;Password=root;Initial Catalog=cccddd;Charset=utf8;SslMode=none;Max pool size=100")
        //.UseLogger(new LoggerFactory().CreateLogger("FreeSql.MySql"))
        //.UseAutoSyncStructure(false)
        //.Build();
    }
}
