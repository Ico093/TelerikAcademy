using System;
using io.iron.ironmq;
using io.iron.ironmq.Data;
using System.Threading;
using System.Web;
using System.Net;

namespace _01.Chat
{
    class ChateSender
    {
        static void Main(string[] args)
        {
            
            Client client = new Client(
               "53875d44daedc50005000028",
               "7zqtIDT7SCrlQ6KtXoc6wzV0Suo");
            Queue queue = client.queue("Chat");
            Console.WriteLine("Enter message:");
            while (true)
            {
                string msg = Console.ReadLine();
                queue.push(GetIpAddress().ToString()+" :  " + msg);
                Console.WriteLine("Message sent.");
            }
        }

        public static string GetIpAddress()
        {
            string Str = "";
            Str = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(Str);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }
    }
}
