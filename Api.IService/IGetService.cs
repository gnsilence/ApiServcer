using Api.Models.TestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.IService
{
  public  interface IGetService
    {
        string Get(string name);
        Task<List<Person>> InsertData(string Name,int Age);
    }
}
