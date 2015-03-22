using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Extension
{
    public static StringBuilder Substring(this StringBuilder build, int index, int length)
    {
        return new StringBuilder(build.ToString().Substring(index, length));
    }
}

