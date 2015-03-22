using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Excel : OfficeDocument, IEncryptable
{
    private bool isEncrypted;
    private long? numberOfCol;
    private long? numberOfRow;

    public bool IsEncrypted
    {
        get { return isEncrypted; }
    }

    public long? NumberOfCol
    {
        get { return numberOfCol; }
    }

    public long? NumberOfRow
    {
        get { return numberOfRow; }
    }


    public Excel(string name, string content = null, long? size = null, long? numberOfCol = null, long? numberOfRow = null)
        : base(name, content, size)
    {
        this.isEncrypted = false;
        this.numberOfCol = numberOfCol;
        this.numberOfRow = numberOfRow;
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "cols")
        {
            this.numberOfCol = DocumentSystem.Converter<string, long?>(value);
        }
        if (key == "rows")
        {
            this.numberOfRow = DocumentSystem.Converter<string, long?>(value);
        }
    }

     public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        if (numberOfCol != null)
        {
            output.Add(new KeyValuePair<string,object>("cols",this.numberOfCol));
        }
          if (numberOfRow != null)
        {
            output.Add(new KeyValuePair<string,object>("rows",this.numberOfRow));
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
            myReturn.Append("ExcelDocument[");
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
