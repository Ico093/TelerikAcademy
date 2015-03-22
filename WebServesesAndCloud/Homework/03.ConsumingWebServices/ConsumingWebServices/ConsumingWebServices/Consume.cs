using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UsingHttpWebRequest;

namespace ConsumingWebServices
{
    class Consume
    {
        static void Main()
        {
            Console.WriteLine("Enter search string:");
            string searched = Console.ReadLine();

            Console.WriteLine("Enter number of articles to show (less than 100):");
            int count = int.Parse(Console.ReadLine());


            string longurl = "http://api.feedzilla.com/v1/articles/search.json";
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["q"] = searched;
            query["count"] = count.ToString();
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();

            var requestedObjects = HttpRequester.Get<RequestedObject>(longurl);

            foreach (var article in requestedObjects.articles)
            {
                Console.WriteLine("Title: {0}\nURL: {1}\n\n", article.title, article.url);
            }
        }
    }
}
