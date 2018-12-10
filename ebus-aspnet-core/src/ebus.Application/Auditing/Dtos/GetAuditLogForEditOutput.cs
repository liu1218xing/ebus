

using System.Collections.Generic;
using Abp.Application.Services.Dto;
using ebus.Auditing;

namespace ebus.Auditing.Dtos
{
    public class GetAuditLogForEditOutput
    {

        public AuditLogEditDto AuditLog { get; set; }

    }
}