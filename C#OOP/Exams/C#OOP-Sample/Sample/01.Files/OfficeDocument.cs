using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class OfficeDocument:BinaryDocument
{
    private string version;

    public string Version
    {
        get { return version; }
    }

    public OfficeDocument(string name, string content=null, long? size = null,string version=null)
        : base(name, content, size)
    {
        this.version = version;
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "version")
        {
            this.version = value;
        }
    }

     public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        if (version != null)
        {
            output.Add(new KeyValuePair<string,object>("version",this.version));
        }
    }
}