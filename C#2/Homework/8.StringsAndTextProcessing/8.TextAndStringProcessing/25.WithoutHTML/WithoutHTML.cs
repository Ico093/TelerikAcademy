using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WithoutHTML
{
    static Regex tagNotBody = new Regex(@"</head>|</title>");
    static Regex tagBody = new Regex(@"</body>");

    static void Main()
    {
        string text = "<html>" +
 " <head><title>News</title></head>" +
  "<body><p><a href=\"http://academy.telerik.com\">Telerik" +
   " Academy</a>aims to provide free real-world practical" +
    "training for young people who want to turn into " +
    "skillful .NET< > sad <>software engineers.</p></body>" +
"</html>";//Console.ReadLine().Trim();



        List<string> plainText = new List<string>();

        Regex m = new Regex(@">\s*\w(\w|\s|\.|-)*?<");

        Match removedTags = m.Match(text);

        bool inBody = false;

        while (removedTags.Value != "")
        {
            if (tagBody.IsMatch(text, removedTags.Index) && tagNotBody.IsMatch(text, removedTags.Index))
            {
                int tagBodyIndex = tagBody.Match(text, removedTags.Index).Index;
                int tagNotBodyIndex = tagNotBody.Match(text, removedTags.Index).Index;

                if (tagBodyIndex < tagNotBodyIndex)
                {
                    plainText[plainText.Count - 1] = string.Concat(plainText[plainText.Count - 1], removedTags.Value.ToString().Substring(1, removedTags.Value.ToString().Length - 2));
                }
                else
                {
                    plainText.Add(removedTags.Value.ToString().Substring(1, removedTags.Value.ToString().Length - 2));
                }
            }
            else if (tagBody.IsMatch(text, removedTags.Index))
            {
                if (!inBody)
                {
                    inBody = true;
                    plainText.Add(removedTags.Value.ToString().Substring(1, removedTags.Value.ToString().Length - 2));
                }
                else
                {
                    plainText[plainText.Count - 1] = string.Concat(plainText[plainText.Count - 1], removedTags.Value.ToString().Substring(1, removedTags.Value.ToString().Length - 2));
                }
                if (removedTags.NextMatch().Index > tagBody.Match(text, removedTags.Index).Index)
                {
                    inBody = false;
                }
            }
            else if (tagNotBody.IsMatch(text, removedTags.Index))
            {
                plainText.Add(removedTags.Value.ToString().Substring(1, removedTags.Value.ToString().Length - 2));
            }
            removedTags = removedTags.NextMatch();
        }

        foreach (string ptext in plainText)
        {
            Console.WriteLine(ptext);
        }
    }
}