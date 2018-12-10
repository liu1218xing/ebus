

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ebus.Auditing;

namespace ebus.Auditing.Dtos
{
    public class CreateOrUpdateAuditLogInput
    {
        [Required]
        public AuditLogEditDto AuditLog { get; set; }

    }
}