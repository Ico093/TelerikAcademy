using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TextDocument:IDocument,IEditable
{
    private string name;
    private string content;
    private string charset;

    public string Name
    {
        get { return name; }
    }

    public string Content
    {
        get { return content; }
    }

    public string Charset
    {
        get { return charset; }
    }

    public TextDocument(string name, string charset=null, string content=null)
    {
        this.name = name;
        this.content = content;
        this.charset = charset;
    }


    public void ChangeContent(string newContent) 
    {
        this.content = newContent;
        Console.WriteLine("Document content changed: {0}", this.Name);
    }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.name = value;
        }
        else if (key == "content")
        {
            this.content = value;
        }
        else if (key == "charset")
        {
            this.charset = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Clear();
        output.Add(new KeyValuePair<string, object>("name", this.name));
        if (content != null)
        {
            output.Add(new KeyValuePair<string, object>("content", this.content));
        }
        if (charset != null)
        {
            output.Add(new KeyValuePair<string, object>("charset", this.charset));
        }
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(parameters);
        parameters.Sort((x, y) => x.Key.CompareTo(y.Key));
        StringBuilder myReturn = new StringBuilder();
        myReturn.Append("TextDocument[");
        foreach (KeyValuePair<string, object> pair in parameters)
        {
            myReturn.Append(String.Format("{0}={1};", pair.Key, pair.Value));
        }
        myReturn.Append(']');
        return myReturn.ToString();
    }
}
