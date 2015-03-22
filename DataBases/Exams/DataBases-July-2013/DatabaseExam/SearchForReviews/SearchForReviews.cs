using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.Data;

namespace SearchForReviews
{
    class SearchForReviews
    {
        static void Main()
        {
            string fileName = "../../reviews-search-results.xml";
            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../reviews-queries.xml");
                string xPathQuery = "/review-queries/query";

                XmlNodeList queryList = xmlDoc.SelectNodes(xPathQuery);

                foreach (XmlNode query in queryList)
                {
                    List<Review> reviews = new List<Review>();
                    string type = query.Attributes["type"].Value;
                    if (type == "by-author")
                    {
                        string authorName = query.SelectSingleNode("author-name").InnerText;
                        reviews = BookStoreDAL.SearchForReviewsByAuthor(authorName);
                    }
                    else
                    {
                        string startDate = query.SelectSingleNode("start-date").InnerText;
                        string endDate = query.SelectSingleNode("end-date").InnerText;
                        reviews = BookStoreDAL.SearchForReviewsByPeriod(startDate, endDate);
                    }

                    writer.WriteStartElement("result-set");

                    foreach (var review in reviews)
                    {
                        writer.WriteStartElement("review");
                        writer.WriteElementString("date", review.DateCreated.ToString());
                        writer.WriteElementString("content", review.Text.ToString());
                        
                        writer.WriteStartElement("book");
                        writer.WriteElementString("title", review.Book.Title);
                        if (review.Book.Authors.Count != 0)
                        {
                            writer.WriteElementString("authors", string.Join(", ", review.Book.Authors.Select(x => x.Name).ToList()));
                        }
                        if (review.Book.ISBNnumber != null)
                        {
                            writer.WriteElementString("isbn", review.Book.ISBNnumber);
                        }
                        if (review.Book.Website != null)
                        {
                            writer.WriteElementString("url", review.Book.Website);
                        }
                        writer.WriteEndElement();
                       
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
