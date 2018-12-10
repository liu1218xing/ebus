using Abp.Auditing;
using ebus.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ebus.Auditing
{
    public class AuditLogAndUser
    {
        public AuditLog AuditLog { get; set; }

        public User User { get; set; }
    }
}
