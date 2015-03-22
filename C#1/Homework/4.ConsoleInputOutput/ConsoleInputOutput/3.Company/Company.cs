using System;


class Company
{
    static void Main()
    {
        Console.Write("Enter company name:");
        string companyName = Console.ReadLine();
        Console.Write("Enter company adress:");
        string adress = Console.ReadLine();
        Console.Write("Enter company phone number:");
        string phoneNumber = Console.ReadLine();
        for (int i = 0; i < phoneNumber.Length; i++)
            if (phoneNumber[i] < '0' || phoneNumber[i] > '9')
            {
                Console.WriteLine("Not a number!");
                return;
            }
        Console.Write("Enter company fax number:");
        string faxNumber = Console.ReadLine();
        for (int i = 0; i < faxNumber.Length; i++)
            if (faxNumber[i] < '0' || faxNumber[i] > '9')
            {
                Console.WriteLine("Not a number!");
                return;
            }
        Console.Write("Enter company website:");
        string webSite = Console.ReadLine();
        Console.Write("Enter company managers first name:");
        string firstName = Console.ReadLine();
        Console.Write("Enter company managers secoud name:");
        string lastName = Console.ReadLine();
        Console.Write("Enter managers age:");
        byte age = byte.Parse(Console.ReadLine());
        Console.Write("Enter managers phone number:");
        string managerPhoneNumber = Console.ReadLine();
        for (int i = 0; i < managerPhoneNumber.Length; i++)
            if (managerPhoneNumber[i] < '0' || managerPhoneNumber[i] > '9')
            {
                Console.WriteLine("Not a number!");
                return;
            }

        Console.WriteLine("\nCompany name: {0}\nCompany adress: {1}\nCompany phone number: {2}",companyName,adress,phoneNumber);
        Console.WriteLine("Company fax number: {0}\nCompany website: {1}\n\nCompany manager: {2} {3}", faxNumber, webSite, firstName, lastName);
        Console.WriteLine("Age: {0}\nManager phone number: {1}",age,managerPhoneNumber);
    }
}

