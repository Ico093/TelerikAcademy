using System;
using System.Text.RegularExpressions;

class AllEmails
{
    static void Main()
    {
        string text = Console.ReadLine();//"zuzi@kaval.bg;; ciki@duduk.net,bob@mail.bg\n\nfn12345@fmi.uni-sofia.bg\n sadasdasd sdadw sad   mente@eu.int | , , ;;; gero@dir.bg";
        
        Regex emails=new Regex(@"(?<identifirer>\w+)@(?<host>[\w|\.|-]+)(?<domain>\.\w+)");

        Console.WriteLine("Emails:");
        foreach (Match email in emails.Matches(text))
        {
            Console.WriteLine(email.Value+"\n");
        }
    }
}
