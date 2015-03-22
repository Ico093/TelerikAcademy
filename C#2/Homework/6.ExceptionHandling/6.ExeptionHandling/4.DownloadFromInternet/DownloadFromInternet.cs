using System;
using System.Net;
using System.Diagnostics;
using System.Threading;

class DownloadFromInternet
{
    static void Main()
    {
        WebClient client = new WebClient();

        while (true)
        {
            try
            {
                Console.Write("Enter your url: ");
                string url = Console.ReadLine();

                Console.Write("Enter the file name: ");
                string fileName = Console.ReadLine();

                fileName += url.Substring(url.LastIndexOf('.'));

                Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                client.DownloadFileTaskAsync(new Uri(url), fileName);
                while (client.IsBusy)
                {
                    client.DownloadProgressChanged += client_DownloadProgressChanged;
                }
                Console.WriteLine("File was downloaded!");
                break;
            }

            catch (Exception e)
            {
                Console.WriteLine("\nSomething went wrong :/\n" + e.Message);
                Console.WriteLine("\n");
            }

            finally
            {
                client.Dispose();
            }
        }

    }

    static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        Console.WriteLine("{0}/{1}  This is {2}%!", e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage);
        Thread.Sleep(300);
    }
}
