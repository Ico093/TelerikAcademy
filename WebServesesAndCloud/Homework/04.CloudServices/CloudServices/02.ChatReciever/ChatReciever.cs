using System;
using io.iron.ironmq;
using io.iron.ironmq.Data;
using System.Threading;

namespace _02.ChatReciever
{
    class ChatReciever
    {
        static void Main(string[] args)
        {
            Client client = new Client(
            "53875d44daedc50005000028",
            "7zqtIDT7SCrlQ6KtXoc6wzV0Suo");
            Queue queue = client.queue("Chat");
            while (true)
            {
                Message msg = queue.get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.deleteMessage(msg);
                }
                Thread.Sleep(100);  
            }
        }
    }
}
