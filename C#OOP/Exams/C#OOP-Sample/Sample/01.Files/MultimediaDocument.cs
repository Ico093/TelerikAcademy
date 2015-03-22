using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class MultimediaDocument : BinaryDocument
{
    private long? length;

    public long? Length
    {
        get { return length; }
    }

    public MultimediaDocument(string name, string content = null, long? size = null, long? length = null)
        : base(name, content, size)
    {
        this.length = length;
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "length")
        {
            this.length = DocumentSystem.Converter<string, long?>(value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        if (length != null)
        {
            output.Add(new KeyValuePair<string,object>("length",this.length));
        }
    }
}
