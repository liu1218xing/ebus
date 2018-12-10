
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ebus.Auditing;

namespace  ebus.Auditing.Dtos
{
    public class AuditLogEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// ImpersonatorUserId
		/// </summary>
		public long? ImpersonatorUserId { get; set; }



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
		/// ExecutionTime
		/// </summary>
		public DateTime ExecutionTime { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// MethodName
		/// </summary>
		public string MethodName { get; set; }



		/// <summary>
		/// ServiceName
		/// </summary>
		public string ServiceName { get; set; }



		/// <summary>
		/// UserId
		/// </summary>
		public long? UserId { get; set; }



		/// <summary>
		/// ImpersonatorTenantId
		/// </summary>
		public int? ImpersonatorTenantId { get; set; }



		/// <summary>
		/// Parameters
		/// </summary>
		public string Parameters { get; set; }



		/// <summary>
		/// CustomData
		/// </summary>
		public string CustomData { get; set; }




    }
}