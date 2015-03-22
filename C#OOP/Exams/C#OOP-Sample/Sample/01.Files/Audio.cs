using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Audio : MultimediaDocument
{
    private long? sampleRate;

    public long? SampleRate
    {
        get { return sampleRate; }
    }

    public Audio(string name, string content = null, long? size = null, long? length=null, long? sampleRate=null)
        : base(name, content, size, length)
    {
        this.sampleRate = sampleRate;
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "samplerate")
        {
            this.sampleRate = DocumentSystem.Converter<string,long?>(value);
        }
    }

     public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        if (sampleRate != null)
        {
            output.Add(new KeyValuePair<string,object>("samplerate",this.sampleRate));
        }
    }

     public override string ToString()
     {
         List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
         this.SaveAllProperties(parameters);
         parameters.Sort((x, y) => x.Key.CompareTo(y.Key));
         StringBuilder myReturn = new StringBuilder();
         myReturn.Append("AudioDocument[");
         foreach(KeyValuePair<string, object> pair in parameters)
         {
             myReturn.Append(String.Format("{0}={1};",pair.Key,pair.Value));
         }
         myReturn.Append(']');
         return myReturn.ToString(); 
     }
}
