using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class Table : ITable
    {
        private int rows;
        private int cols;
        private IElement[,] table;
       
        public int Rows { get { return rows; } }
        public int Cols { get { return cols; } }
        public IElement this[int row, int col]
        {
            get { return table[row, col]; }
            set { table[row, col] = value; }
        }

        public string Name { get { return "table"; } }
        public IEnumerable<IElement> ChildElements { get { return new List<IElement>(); } }
        public string TextContent { get; set; }

        public Table(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.table = new IElement[rows, cols];
        }

        public void AddElement(IElement element)
        {
        }

        public void Render(StringBuilder output)
        {
            output.Append("<table>");
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>"+this[row,col].ToString()+"</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            Render(output);
            return output.ToString();
        }
    }
}
