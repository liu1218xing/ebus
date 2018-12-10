

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ebus.Auditing;


namespace ebus.Auditing.DomainService
{
    public interface IAuditLogManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitAuditLog();



		 
      
         

    }
}
