

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ebus.Auditing;
using Abp.Domain.Entities;

namespace ebus.Auditing.Dtos
{
    public class AuditLogListDto : EntityDto<long>
    {
        public long? UserId { get; set; }

        public string UserName { get; set; }
        /// <summary>
		/// ImpersonatorTenantId
		/// </summary>
		public int? ImpersonatorTenantId { get; set; }
        /// <summary>
        /// ImpersonatorUserId
        /// </summary>
        public long? ImpersonatorUserId { get; set; }
        /// <summary>
		/// ServiceName
		/// </summary>
		public string ServiceName { get; set; }
        /// <summary>
		/// MethodName
		/// </summary>
		public string MethodName { get; set; }
        /// <summary>
		/// Parameters
		/// </summary>
		public string Parameters { get; set; }
        /// <summary>
		/// ExecutionTime
		/// </summary>
		public DateTime ExecutionTime { get; set; }


        /// <summary>
        /// Exception
        /// </summary>
        public string Exception { get; set; }



		/// <summary>
		/// BrowserInfo
		/// </summary>
		public string BrowserInfo { get; set; }



		/// <summary>
		/// ClientName
		/// </summary>
		public string ClientName { get; set; }



		/// <summary>
		/// ClientIpAddress
		/// </summary>
		public string ClientIpAddress { get; set; }



		/// <summary>
		/// ExecutionDuration
		/// </summary>
		public int ExecutionDuration { get; set; }



		



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		



		




		



		



		/// <summary>
		/// CustomData
		/// </summary>
		public string CustomData { get; set; }




    }
}