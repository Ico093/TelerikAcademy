using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PDF : BinaryDocument,IEncryptable
{
    private bool isEncrypted;
    private long? numberOfPages;

    public bool IsEncrypted
    {
        get { return isEncrypted; }
    }

    public long? NumberOfPages
    {
        get { return numberOfPages; }
    }

    public PDF(string name, string content=null, long? size = null,long? numberOfPages=null)
        : base(name, content, size)
    {
        this.isEncrypted = false;
        this.numberOfPages = numberOfPages;
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "pages")
        {
            this.numberOfPages = DocumentSystem.Converter<string, long?>(value);
        }
    }

     public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        if (numberOfPages != null)
        {
            output.Add(new KeyValuePair<string,object>("pages",this.numberOfPages));
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
            myReturn.Append("PDFDocument[");
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                myReturn.Append(String.Format("{0}={1};", pair.Key, pair.Value));
            }
            myReturn.Append(']');
            return myReturn.ToString();
        }
        else
        {
            return "PDFDocument[encrypted]";
        }
    }
}