using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Files
{
    static void Main()
    {
        DocumentSystem documents = new DocumentSystem();

        string command = Console.ReadLine();

        while (command != string.Empty)
        {
            Execute(command, ref documents);

            command = Console.ReadLine();
        }

        Console.WriteLine(documents.ToString());
    }

    public static void Execute(string command, ref DocumentSystem documents)
    {
        string sub = command.Substring(0, 3);

        switch (sub)
        {
            case "Add":
                {
                    documents.AddDocument(DocumentSystem.CreateDocument(command));
                }
                break;
            case "Enc":
                {
                    if (command[7] == 'A')
                    {
                        documents.EncryptAll();
                    }
                    else
                    {
                        documents.EncryptDocument(command.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    }
                }
                break;
            case "Dec":
                {
                    documents.DecryptDocument(command.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                break;
            case "Lis":
                {
                    documents.ToString();
                }
                break;
            case "Cha":
                {
                    string[] parameters = command.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    documents.ChangeDocumentContent(parameters[0], parameters[1]);
                }
                break;
        }
    }
}