using System;
using System.Collections.Generic;
using System.Text;
using static Api.CommonUtils.SqlTypeEnum;

namespace Api.CommonUtils
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CodeFirstAttribute : Attribute
    {
        /// <summary>
        /// 是否启用codefirst
        /// </summary>
        /// <param name="Use"></param>
        public CodeFirstAttribute(bool Use)
        {
            this.Allow = Use;
        }
        public bool Allow { get; set; }

        public SqlType SqlTypeEnum { get; set; }
        /// <summary>
        /// 启用的数据库类型
        /// </summary>
        /// <param name="sqlTypeEnum"></param>
        public CodeFirstAttribute(SqlType sqlTypeEnum)
        {
            SqlTypeEnum = sqlTypeEnum;
        }
    }
}
