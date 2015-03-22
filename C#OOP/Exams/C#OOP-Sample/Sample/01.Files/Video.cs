using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Video : MultimediaDocument
{
    private long? frameRate;

    public long? FrameRate
    {
        get { return frameRate; }
    }

    public Video(string name, string content = null, long? size = null, long? length = null, long? frameRate = null)
        : base(name, content, size, length)
    {
        this.frameRate = frameRate;
    }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "framerate")
        {
            this.frameRate = DocumentSystem.Converter<string, long?>(value);
        }
    }

     public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        if (frameRate != null)
        {
            output.Add(new KeyValuePair<string,object>("framerate",this.frameRate));
        }
    }

     public override string ToString()
     {
         List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
         this.SaveAllProperties(parameters);
         parameters.Sort((x, y) => x.Key.CompareTo(y.Key));
         StringBuilder myReturn = new StringBuilder();
         myReturn.Append("VideoDocument[");
         foreach (KeyValuePair<string, object> pair in parameters)
         {
             myReturn.Append(String.Format("{0}={1};", pair.Key, pair.Value));
         }
         myReturn.Append(']');
         return myReturn.ToString();
     }
}
