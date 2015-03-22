using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace ComplexBooksImport
{
    public static class ComplexBooksImport
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            using (TransactionScope tran = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.RepeatableRead
            }))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../complex-books.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode bookNode in booksList)
                {
                    List<string> authors = new List<string>();

                    XmlNode authorsNode = bookNode.SelectSingleNode("authors");
                    if (authorsNode != null)
                    {
                        XmlNodeList authorsList = authorsNode.SelectNodes("author");
                        foreach (XmlNode author in authorsList)
                        {
                            authors.Add(author.InnerText);
                        }
                    }

                    string title = bookNode.InnerTextOrNull("title");
                    string isbn = bookNode.InnerTextOrNull("isbn");
                    string price = bookNode.InnerTextOrNull("price");
                    string website = bookNode.InnerTextOrNull("web-site");

                    List<ReviewImport> reviews = new List<ReviewImport>();
                    XmlNode reviewsNode = bookNode.SelectSingleNode("reviews");
                    if (reviewsNode != null)
                    {
                        XmlNodeList reviewsList = reviewsNode.SelectNodes("review");
                        foreach (XmlNode review in reviewsList)
                        {
                            string reviewStr = review.InnerText;

                            string date = null;
                            if (review.Attributes["date"] != null)
                            {
                                date = review.Attributes["date"].Value;
                            }

                            string author = null;
                            if (review.Attributes["author"] != null)
                            {
                                author = review.Attributes["author"].Value;
                            }

                            reviews.Add(new ReviewImport(reviewStr, author, date));
                        }
                    }

                    BookStoreDAL.ComplexBooksImport(authors, title, isbn, price, website, reviews);
                }
                tran.Complete();
            }
        }

        public static string InnerTextOrNull(this XmlNode node, string value)
        {
            XmlNode searchedNode = node.SelectSingleNode(value);
            if (searchedNode != null)
            {
                return searchedNode.InnerText;
            }
            else
            {
                return null;
            }
        }
    }
}
