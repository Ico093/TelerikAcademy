using Bookmarks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ComplexBookmarkSearch
{
    public static class ComplexBookmarkSearch
    {
        static void Main()
        {
            List<IList<Bookmark>> resluts = new List<IList<Bookmark>>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../complex-query.xml");
            string xPathQuery = "/queries/query";

            XmlNodeList queryList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode query in queryList)
            {
                string username = query.InnerTextOrNull("username");
                List<string> tags = new List<string>();

                foreach (XmlNode tag in query.SelectNodes("tag"))
                {
                    tags.Add(tag.InnerText);
                }

                int maxResults = 10;

                var maxResultsAttribute = query.Attributes["max-results"];
                if(maxResultsAttribute!=null)
                {
                    maxResults = int.Parse(maxResultsAttribute.Value);
                }

                resluts.Add(BookmarksDAL.ComplexBookmarkSearch(username, tags, maxResults));
            }

            string fileName = "../../search-results.xml";
            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                
                foreach (IList<Bookmark> result in resluts)
                {
                    writer.WriteStartElement("result-set");

                    foreach (Bookmark bookmark in result)
                    {
                        writer.WriteStartElement("bookmark");

                        writer.WriteElementString("username", bookmark.User.Username);
                        writer.WriteElementString("title", bookmark.Title);
                        writer.WriteElementString("url", bookmark.URL);
                        writer.WriteElementString("tags",string.Join(", ", bookmark.Tags.Select(x=>x.Name)));
                        if (bookmark.Notes != null)
                        {
                            writer.WriteElementString("notes", bookmark.Notes);
                        }

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndDocument();
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
