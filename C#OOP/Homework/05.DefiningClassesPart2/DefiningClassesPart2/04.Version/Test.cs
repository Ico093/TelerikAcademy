using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;


[VersionAttribute(12, 245)]
class Test
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Type type = typeof(Test);
        object[] allAttributes = type.GetCustomAttributes(false);
        foreach (VersionAttribute attr in allAttributes)
        {
            Console.WriteLine("Class version:{0}", attr.version);
        }
    }
}
