using Api.CommonUtils;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models.TestModels
{
    [CodeFirst(Use: true,SqlTypeEnum =SqlTypeEnum.SqlType.SqlServer)]
    [Table(Name = "tb_StudyRecord_Result")]
    public class StudyRecordResult
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        /// <summary>
        /// <summary>
        /// 学员Id
        /// </summary>
        public System.Nullable<int> StudentId { get; set; }
        /// <summary>
        /// 教练编号
        /// </summary>
        public System.Nullable<int> TeacherId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public System.Nullable<DateTime> BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public System.Nullable<DateTime> EndTime { get; set; }
        /// <summary>
        /// 实际学时
        /// </summary>
        public System.Nullable<double> RealTime { get; set; }
        /// <summary>
        /// 有效学时
        /// </summary>
        public System.Nullable<double> ActualTime { get; set; }
        /// <summary>
        /// 学时里程
        /// </summary>
        public System.Nullable<double> StudyMile { get; set; }
        /// <summary>
        /// 科目编号
        /// </summary>
        public System.Nullable<int> SubjectID { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public System.Nullable<DateTime> UploadTime { get; set; }
        /// <summary>
        /// 驾校编号
        /// </summary>
        public System.Nullable<int> DriveSchoolId { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public System.Nullable<int> GpsId { get; set; }
        /// <summary>
        /// 运算有效学时
        /// </summary>
        public System.Nullable<double> ValidActualTime { get; set; }
        /// <summary>
        /// 系数
        /// </summary>

        /// 

        public int UploadStatus { get; set; }


        public string Recnum { get; set; }

    }
}
