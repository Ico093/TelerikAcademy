using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleSearchForBooks
{
    public static class SimpleSearchForBooks
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string xPathQuery = "/query";

            XmlNode query = xmlDoc.SelectSingleNode(xPathQuery);

            string title = query.InnerTextOrNull("title");
            string author = query.InnerTextOrNull("author");
            string isbn = query.InnerTextOrNull("isbn");

            List<Book> foundBooks = BookStoreDAL.SimpleSearchForBooks(title, author, isbn);

            if (foundBooks.Count != 0)
            {
                Console.WriteLine("{0} books found:", foundBooks.Count);
                foreach (var book in foundBooks)
                {
                    Console.WriteLine("{0} --> {1} reviews", book.Title, book.Reviews.Count == 0 ? "no" : book.Reviews.Count.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
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
