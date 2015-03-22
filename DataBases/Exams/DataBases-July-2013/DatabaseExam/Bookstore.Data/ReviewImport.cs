using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReviewImport
{
    public ReviewImport(string review, string author, string date)
    {
        this.Review = review;
        this.Author = author;
        this.Date = date;
    }

    public string Review { get; set; }
    public string Author { get; set; }
    public string Date { get; set; }
}
