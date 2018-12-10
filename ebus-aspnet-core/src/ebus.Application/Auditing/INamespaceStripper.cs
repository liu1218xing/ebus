using System;
using System.Collections.Generic;
using System.Text;

namespace ebus.Auditing
{
    public interface INamespaceStripper
    {
        string StripNameSpace(string serviceName);
    }
}
