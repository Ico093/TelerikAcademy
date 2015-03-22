using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DocumentSystem
{
    private List<IDocument> documents;

    public DocumentSystem()
    {
        documents = new List<IDocument>();
    }

    public void AddDocument(IDocument document)
    {
        if (document != null)
        {
            Console.WriteLine("Document added: {0}", document.Name);

            documents.Add(document);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    public static IDocument CreateDocument(string command)
    {
        string[] splittedCommand = command.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

        if (splittedCommand.Length > 1)
        {
            string[] splittedParamethers = splittedCommand[1].Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            switch (splittedCommand[0])
            {
                case "AddTextDocument":
                    {
                        for (int i = 0; i < splittedParamethers.Length; i+=2)
                        {
                            if (splittedParamethers[i] == "name")
                            {
                                TextDocument myDoc = new TextDocument(splittedParamethers[i + 1]);

                                for (int j = 0; j < splittedParamethers.Length; j+=2)
                                {
                                    if (splittedParamethers[j] != "name")
                                    {
                                        myDoc.LoadProperty(splittedParamethers[j], splittedParamethers[j + 1]);
                                    }
                                }

                                return myDoc;
                            }
                        }
                        return null;
                    }
                case "AddPDFDocument":
                    {
                        for (int i = 0; i < splittedParamethers.Length; i += 2)
                        {
                            if (splittedParamethers[i] == "name")
                            {
                                PDF myDoc = new PDF(splittedParamethers[i + 1]);

                                for (int j = 0; j < splittedParamethers.Length; j += 2)
                                {
                                    if (splittedParamethers[j] != "name")
                                    {
                                        myDoc.LoadProperty(splittedParamethers[j], splittedParamethers[j + 1]);
                                    }
                                }

                                return myDoc;
                            }
                        }
                        return null;
                    }
                case "AddWordDocument":
                    {
                        for (int i = 0; i < splittedParamethers.Length; i += 2)
                        {
                            if (splittedParamethers[i] == "name")
                            {
                                Word myDoc = new Word(splittedParamethers[i + 1]);

                                for (int j = 0; j < splittedParamethers.Length; j += 2)
                                {
                                    if (splittedParamethers[j] != "name")
                                    {
                                        myDoc.LoadProperty(splittedParamethers[j], splittedParamethers[j + 1]);
                                    }
                                }

                                return myDoc;
                            }
                        }
                        return null;
                    }
                case "AddExcelDocument":
                    {
                        for (int i = 0; i < splittedParamethers.Length; i += 2)
                        {
                            if (splittedParamethers[i] == "name")
                            {
                                Excel myDoc = new Excel(splittedParamethers[i + 1]);

                                for (int j = 0; j < splittedParamethers.Length; j += 2)
                                {
                                    if (splittedParamethers[j] != "name")
                                    {
                                        myDoc.LoadProperty(splittedParamethers[j], splittedParamethers[j + 1]);
                                    }
                                }

                                return myDoc;
                            }
                        }
                        return null;
                    }
                case "AddAudioDocument":
                    {
                        for (int i = 0; i < splittedParamethers.Length; i += 2)
                        {
                            if (splittedParamethers[i] == "name")
                            {
                                Audio myDoc = new Audio(splittedParamethers[i + 1]);

                                for (int j = 0; j < splittedParamethers.Length; j += 2)
                                {
                                    if (splittedParamethers[j] != "name")
                                    {
                                        myDoc.LoadProperty(splittedParamethers[j], splittedParamethers[j + 1]);
                                    }
                                }

                                return myDoc;
                            }
                        }
                        return null;
                    }
                case "AddVideoDocument":
                    {
                        for (int i = 0; i < splittedParamethers.Length; i += 2)
                        {
                            if (splittedParamethers[i] == "name")
                            {
                                Video myDoc = new Video(splittedParamethers[i + 1]);

                                for (int j = 0; j < splittedParamethers.Length; j += 2)
                                {
                                    if (splittedParamethers[j] != "name")
                                    {
                                        myDoc.LoadProperty(splittedParamethers[j], splittedParamethers[j + 1]);
                                    }
                                }

                                return myDoc;
                            }
                        }
                        return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        else
        {
            return null;
        }
    }

    public static long? Converter<T1, T2>(string myLong)
    {
        if (myLong != string.Empty)
        {
            return Convert.ToInt64(myLong);
        }
        else
        {
            return null;
        }
    }

    public void EncryptAll()
    {
        bool atLeastOne = false;
        foreach (IDocument document in documents)
        {
            if (document is IEncryptable)
            {
                atLeastOne = true;
                (document as IEncryptable).Encrypt();
            }
        }
        if (atLeastOne)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    public void EncryptDocument(string name)
    {
        if (documents.Exists(x => x.Name == name))
        {
            foreach (IDocument document in documents.FindAll(x => x.Name == name))
            {
                if (document is IEncryptable)
                {
                    Console.WriteLine("Document encrypted: {0}", document.Name);
                    (document as IEncryptable).Encrypt();
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", document.Name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    public void DecryptDocument(string name)
    {
        if (documents.Exists(x => x.Name == name))
        {
            foreach (IDocument document in documents.FindAll(x => x.Name == name))
            {
                if (document is IEncryptable)
                {
                    Console.WriteLine("Document decrypted: {0}", document.Name);
                    (document as IEncryptable).Decrypt();
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", document.Name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    public void ChangeDocumentContent(string name, string content)
    {
        bool inside = false;
        foreach (IDocument document in documents.FindAll(x => x.Name == name))
        {
            if (document is IEditable)
            {
                inside = true;
                (document as IEditable).ChangeContent(content);
            }
        }
        if(!inside)
        {
            Console.WriteLine("Document is not editable: {0}",name);
        }
    }

    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();
        for (int i = 0; i < documents.Count; i++)
        {
            myReturn.Append(documents[i].ToString() + "\n");
        }
        return myReturn.ToString();
    }
}