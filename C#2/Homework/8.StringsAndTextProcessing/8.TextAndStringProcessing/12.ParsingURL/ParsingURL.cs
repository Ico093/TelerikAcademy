using System;
using System.Text.RegularExpressions;

class ParsingURL
{
    static void Main()
    {
        string protocol;
        string server;
        string resource;
        while (true)
        {
            try
            {
                Console.Write("Enter URL:");
                string URL = Console.ReadLine();

                protocol = URL.Substring(0, URL.IndexOf("://"));
                server = URL.Substring(URL.IndexOf("://") + 3, URL.IndexOf("/", URL.IndexOf("://") + 3) - (URL.IndexOf("://") + 3));
                resource = URL.Substring(URL.IndexOf("/", URL.IndexOf("://") + 3));
                break;
            }
            catch(Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }
        Console.WriteLine("\n[protocol]:{0}", protocol);
        Console.WriteLine("[server]:{0}", server);
        Console.WriteLine("[resource]:{0}\n", resource);
    }
}