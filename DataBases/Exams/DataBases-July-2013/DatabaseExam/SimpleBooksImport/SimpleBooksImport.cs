using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Transactions;

namespace SimpleBooksImport
{
    public static class SimpleBooksImport
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
                xmlDoc.Load("../../simple-books.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode bookNode in booksList)
                {
                    string author = bookNode.InnerTextOrNull("author");
                    string title = bookNode.InnerTextOrNull("title");
                    string isbn = bookNode.InnerTextOrNull("isbn");
                    string price = bookNode.InnerTextOrNull("price");
                    string website = bookNode.InnerTextOrNull("web-site");

                    BookStoreDAL.SimpleBooksImport(author, title, isbn, price, website);

                }
                tran.Complete();
            }
        }

        public static string InnerTextOrNull(this XmlNode node, string value)
        {
            XmlNode searchedNode=node.SelectSingleNode(value);
            if(searchedNode!=null)
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
