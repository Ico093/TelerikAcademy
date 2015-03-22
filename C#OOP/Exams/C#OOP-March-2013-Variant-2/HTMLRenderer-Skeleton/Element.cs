using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class Element : IElement
    {
        private string name;
        private string textContent;
        List<IElement> childElements;

        public string Name { get { return name; } }

        public string TextContent
        {
            get { return textContent; }
            set { textContent = value; }
        }

        public IEnumerable<IElement> ChildElements { get { return childElements; } }

        public Element(string name)
        {
            this.name = name;
            this.TextContent = null;
            this.childElements = new List<IElement>();
        }

        public Element(string name, string textContent)
            : this(name)
        {
            this.TextContent = textContent;
        }

        public void AddElement(IElement element)
        {
            childElements.Add(element);
        }

        public void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append("<" + this.Name + ">");
            }

            if (TextContent != null)
            {
                this.textContent = this.TextContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                output.Append(this.TextContent);
            }

            for (int i = 0; i < this.childElements.Count(); i++)
            {
                output.Append(this.childElements[i].ToString());
            }

            if (this.Name != null)
            {
                output.Append("</" + this.Name + ">");
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            Render(output);
            return output.ToString();
        }
    }
}
