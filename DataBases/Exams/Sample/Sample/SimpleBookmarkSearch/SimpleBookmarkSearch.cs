using Bookmarks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SimpleBookmarkSearch
{
    public static class SimpleBookmarkSearch
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string xPathQuery = "/query";

            XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookmark in bookmarksList)
            {
                string username = bookmark.InnerTextOrNull("username");
                string tag = bookmark.InnerTextOrNull("tag");

                var bookmarks=BookmarksDAL.SimpleBookmarkSearch(username, tag);

                foreach (var bookmarkItem in bookmarks)
                {
                    Console.WriteLine(bookmarkItem.URL);
                }
            }
        }

        public static string InnerTextOrNull(this XmlNode node, string name)
        {
            XmlNode searchedNode = node.SelectSingleNode(name);
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
