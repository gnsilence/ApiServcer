using Api.IService;
using Api.Models.TestModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Api.Services
{
    public class GetService : IGetService
    {
        public string Get(string name)
        {

            Console.WriteLine(name);
            return name;
        }

        public async Task<List<Person>> InsertData(string Name, int Age)
        {
           await Task.Delay(500);
            var insert = SQLS.Core.SqlHelpers.SqlServer.Insert<Person>();
            var model = new Person()
            {
                Name = Name,
                Age = Age
            };
            return  insert.AppendData(model).ExecuteInserted();
        }
    }
}
