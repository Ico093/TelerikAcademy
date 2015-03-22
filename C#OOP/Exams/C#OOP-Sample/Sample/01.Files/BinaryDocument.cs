using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class BinaryDocument : IDocument
{
    private string name;
    private string content;
    private long? size;

    public string Name
    {
        get { return name; }
    }

    public string Content
    {
        get { return content; }
    }

    public long? Size
    {
        get { return size; }
    }

    public BinaryDocument(string name, string content=null, long? size=null)
    {
        this.name = name;
        this.content = content;
        this.size = size;
    }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
           this.name=value;
        }
        else if (key == "content")
        {
            this.content = value;
        }
        else if (key == "size")
        {
            this.size = DocumentSystem.Converter<string,long?>(value);
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Clear();
        output.Add(new KeyValuePair<string,object>("name",this.name));
        if (content != null)
        {
            output.Add(new KeyValuePair<string, object>("content", this.content));
        }
        if (size != null)
        {
            output.Add(new KeyValuePair<string, object>("size", this.size));
        }
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
