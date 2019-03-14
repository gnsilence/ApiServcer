using Api.CommonUtils;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models.TestModels
{
    [CodeFirst(Use:true,SqlTypeEnum =SqlTypeEnum.SqlType.Mysql)]
    [Table(Name = "tb_Animal")]
    public class Animal
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        [Column(IsNullable =true)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
