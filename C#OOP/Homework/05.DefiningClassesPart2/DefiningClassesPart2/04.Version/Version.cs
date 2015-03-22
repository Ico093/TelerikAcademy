using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

[AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class|AttributeTargets.Interface|AttributeTargets.Enum|AttributeTargets.Method)]
class VersionAttribute:System.Attribute
{
    public double version { get; set; }

    public VersionAttribute(long major, long minor)
    {
        this.version=(double)(major)+((double)(minor)/Math.Pow(10,minor.ToString().Length));
    }
}
