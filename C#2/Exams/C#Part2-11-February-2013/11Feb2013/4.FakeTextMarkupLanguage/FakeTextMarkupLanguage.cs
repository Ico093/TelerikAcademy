using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class FakeTextMarkupLanguage
{
    static Regex tags = new Regex(@"<\w+>");
    static Regex closeTags = new Regex(@"<\w+>");
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        StringBuilder build = new StringBuilder();
        for (int i = 0; i < lines; i++)
        {
            build.Append(string.Concat(Console.ReadLine(), "\n"));
        }

        Console.WriteLine(MarkMeUp(build.ToString()));
    }

   

    static string MarkMeUp(string build)
    {
        int i = 0;
        StringBuilder teqBuilder = new StringBuilder();

        while (i != build.Length)
        {
            int index = -1;
            if (tags.IsMatch(build.ToString(),i))
            {
                index = tags.Match(build.ToString(),i).Index;

                for (int j = i; j < index; j++)
                {
                    teqBuilder.Append(build[j]);
                }

                string tag = tags.Match(build.ToString(),i).Value.Substring(1, tags.Match(build.ToString(),i).Value.Length - 2);

                int endIndex = build.IndexOf(string.Concat("</", tag, ">"),i);
                int teqIndex = index;
                while(build.Substring(teqIndex + 5, endIndex-index- 5).IndexOf(string.Concat("<", tag, ">"))!=-1)
                {
                    teqIndex = build.Substring(teqIndex + 5, endIndex - index - 5).IndexOf(string.Concat("<", tag, ">"))+5+index;
                    endIndex = build.IndexOf(string.Concat("</", tag, ">"),endIndex+1);
                }

                switch (tag)
                {
                    case "upper":
                        {
                            teqBuilder.Append(Upper(MarkMeUp(build.Substring(index + 7, endIndex-index-7))));
                        }
                        break;
                    case "lower":
                        {
                            teqBuilder.Append(Lower(MarkMeUp(build.Substring(index + 7, endIndex-index-7))));
                        }
                        break;
                    case "toggle":
                        {
                            teqBuilder.Append(Toggle(MarkMeUp(build.Substring(index + 8, endIndex-index-8))));
                        }
                        break;
                    case "rev":
                        {
                            teqBuilder.Append(Reverse(MarkMeUp(build.Substring(index + 5, endIndex-index- 5))));
                        }
                        break;
                }
                i = endIndex + 3 + tag.Length;
            }
            else
            {
                for (int j = i; j < build.Length; j++)
                {
                    teqBuilder.Append(build[j]);
                }
                return teqBuilder.ToString();
            }
        }
        return teqBuilder.ToString();
    }


    //-----------------------------------------------------------------------------------------------------------------


    static string Upper(string text)
    {
        return text.ToUpper();
    }

    static string Lower(string text)
    {
        return text.ToLower();
    }

    static string Toggle(string text)
    {
        StringBuilder build = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] >= 'a' && text[i] <= 'z')
            {
                build.Append((char)((int)(text[i]) - 32));
            }
            else if (text[i] >= 'A' && text[i] <= 'Z')
            {
                build.Append((char)((int)(text[i]) + 32));
            }
            else
            {
                build.Append(text[i]);
            }
        }
        return build.ToString();
    }

    static string Reverse(string text)
    {
        StringBuilder build = new StringBuilder();

        for (int i = text.Length - 1; i >= 0; i--)
        {
            build.Append(text[i]);
        }
        return build.ToString();
    }
}