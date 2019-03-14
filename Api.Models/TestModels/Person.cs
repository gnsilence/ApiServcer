using Api.CommonUtils;
using Api.SQLS.Core;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models.TestModels
{
    [CodeFirst(Use: true,SqlTypeEnum =SqlTypeEnum.SqlType.SqlServer)]
    [Table(Name = "tb_Person")]
    public class Person
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
