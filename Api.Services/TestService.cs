using Api.Models.TestModels;
using System;
using System.Collections.Generic;
using System.Text;
using Api.SQLS.Core;
using System.Threading.Tasks;
using System.Threading;

namespace Api.Services
{
    public class TestService
    {
        public TestService()
        {
            Codefirt();
        }

        public List<Person> GetPeople()
        {
            var data = SqlHelpers.SqlServer.Select<Person>();
            return data.ToList();
        }

        public void Codefirt()
        {
            //SqlHelpers.MySql.CodeFirst.SyncStructure<Person>();
            //SqlHelpers.SqlServer.CodeFirst.IsAutoSyncStructure = true;
            //var str = SqlHelpers.MySql.CodeFirst.GetComparisonDDLStatements<Person>();
        }
       
       

        public void InsertResluts()
        {
            var insert = SqlHelpers.SqlServer.Insert<StudyRecordResult>();
            var srudyrelsut = new List<StudyRecordResult>();
            for (int i = 0; i < 70; i++)
            {
                
                var info = new StudyRecordResult();
                info.StudentId = 111;
                info.TeacherId = 111;
                info.ActualTime = 199;
                info.UploadStatus = 0;
                info.UploadTime = DateTime.Now;
                info.RealTime = 199;
                info.Recnum = "";
                info.BeginTime = DateTime.Now.AddSeconds(-(new Random().Next(1,500)));
                info.EndTime = DateTime.Now.AddSeconds(new Random().Next(1,1000));
                srudyrelsut.Add(info);
            }
          var t=  insert.AppendData(srudyrelsut).ExecuteIdentity();
            //SqlHelpers.SqlServer.Ado.ExecuteNonQuery(t);
        }
    }
}
