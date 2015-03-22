using Bookmarks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Xml;

public static class ImportBookmarks
{
    public static void Main()
    {
        using (TransactionScope tran = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.RepeatableRead
            }))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../bookmarks.xml");
            string xPathQuery = "/bookmarks/bookmark";

            XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookmark in bookmarksList)
            {
                string username = bookmark.InnerTextOrNull("username");
                string title = bookmark.InnerTextOrNull("title");
                string URL = bookmark.InnerTextOrNull("url");
                List<string> tags = new List<string>();
                string notes = bookmark.InnerTextOrNull("notes");

                if (bookmark.InnerTextOrNull("tags") != null)
                {
                    tags = bookmark.InnerTextOrNull("tags").Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                }

                BookmarksDAL.ImportBookmarks(username, title, URL, tags, notes);
            }
            tran.Complete();
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
