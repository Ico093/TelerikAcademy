using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Word : OfficeDocument, IEncryptable, IEditable
{
    private bool isEncrypted;
    private long? numberOfChar;

    public bool IsEncrypted
    {
        get { return isEncrypted; }
    }

    public long? NumberOfChar
    {
        get { return numberOfChar; }
    }

    public Word(string name, string content = null, long? size = null, long? numberOfChar = null)
        : base(name, content, size)
    {
        this.isEncrypted = false;
        this.numberOfChar = numberOfChar;
    }


    public void ChangeContent(string newContent)
    {
        this.LoadProperty("content", newContent);
        Console.WriteLine("Document content changed: {0}",this.Name);
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "chars")
        {
            this.numberOfChar = DocumentSystem.Converter<string, long?>(value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        if (numberOfChar != null)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.numberOfChar));
        }
    }

    public void Encrypt()
    {
        isEncrypted = true;
    }

    public void Decrypt()
    {
        isEncrypted = false;
    }

    public override string ToString()
    {
        if (!isEncrypted)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(parameters);
            parameters.Sort((x, y) => x.Key.CompareTo(y.Key));
            StringBuilder myReturn = new StringBuilder();
            myReturn.Append("WordDocument[");
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                myReturn.Append(String.Format("{0}={1};", pair.Key, pair.Value));
            }
            myReturn.Append(']');
            return myReturn.ToString();
        }
        else
        {
            return "ExcelDocument[encrypted]";
        }
    }
}
