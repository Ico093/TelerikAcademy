using System;
using System.IO;

class ReadFromFile
{
    static void Main()
    {
        while (true)
        {
            try
            {
                string path = Console.ReadLine();
                Console.WriteLine(File.ReadAllText(path));
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("There wasn't such file at the path you gave me!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The path you gave me was invalid!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have permision to access this path!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("I didn't know that you could be that stupid to do this but CLR knew!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

