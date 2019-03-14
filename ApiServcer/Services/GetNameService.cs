using Api.IService;
using Api.Models.TestModels;
using ApiServcer.IocContainer;
using ApiServcer.JWT;
using BeetleX.FastHttpApi;
using BeetleX.FastHttpApi.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace ApiServcer.Services
{
    [Controller]
    public class GetNameService
    {
        private readonly IGetService _getService = AutofacContainer.Resolve<IGetService>();
        //Nlog
        private static Logger logger = new LogFactory().GetCurrentClassLogger();
        private static JWTHelper JWTHelper = new JWTHelper();
        [Get(Route = "{name}-{age}")]
        //[JWTFilter]
        [DefaultJsonResultFilter]
        public object GetName(string name, int age)
        {
            var getname = _getService.Get(name);
            return new { OutPut = getname, Age = age };
        }

        /// <summary>
        /// 无任何数据格式化，可以直接访问
        /// </summary>
        /// <returns></returns>
        //public object GetName()
        //{
        //    return new { Name = "张三" };
        //}
        [Get(Route ="{name}")]
        [DefaultJsonResultFilter]
        public object Hello (string name)
        {
            logger.Info($"调用测试接口,获取到的值：{name}");
            return new { Name = name, DateTime = DateTime.Now.ToLongTimeString() };
        }
        //获取token
        [Get]
        public object GetToken(string name, string role)
        {
            return new TextResult(JWTHelper.CreateToken(name, role));
        }
        [Post]
        [JsonDataConvert]
        public async Task<object> InsertPerson(Person body)
        {
            var result= await _getService.InsertData(body.Name,body.Age);
            return result.FirstOrDefault().Name;
            //return new {InsertName=reslut.Result.FirstOrDefault().Name,InsertAge=reslut.Result.FirstOrDefault().Age};
        }
    }
}
