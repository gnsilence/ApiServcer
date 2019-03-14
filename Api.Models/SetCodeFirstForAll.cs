using Api.CommonUtils;
using System;
using System.Collections.Generic;
using System.Reflection;
using Api.SQLS.Core;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    [CodeFirst(Use: false)]
    public static class SetCodeFirstForAll
    {
        public static async Task<bool> SetCodeFirstAsync(string AssemblyName)
        {
            await Task.Delay(300);
            try
            {
                var modeltypes = Assembly.Load(AssemblyName).GetTypes();
                Console.WriteLine("开始同步数据库结构");
                foreach (var type in modeltypes)
                {
                    //获取特性检测是否启用codefirst
                    var attrs = type.GetCustomAttributes(typeof(CodeFirstAttribute), false);
                    if (attrs.Length == 0) continue;
                    CodeFirstAttribute codeFirst = (CodeFirstAttribute)attrs[0];
                    if (codeFirst.Allow)
                    {
                        switch (codeFirst.SqlTypeEnum)
                        {
                            case SqlTypeEnum.SqlType.Mysql:
                                SqlHelpers.MySql.CodeFirst.SyncStructure(new Type[] { type });
                                break;
                            case SqlTypeEnum.SqlType.SqlServer:
                                SqlHelpers.SqlServer.CodeFirst.SyncStructure(new Type[] { type });
                                break;
                        }
                    }
                }
                Console.WriteLine("同步数据库结构完成");
            }
            catch (Exception ee)
            {
                return false;
            }
            return true;
        }
    }
}
