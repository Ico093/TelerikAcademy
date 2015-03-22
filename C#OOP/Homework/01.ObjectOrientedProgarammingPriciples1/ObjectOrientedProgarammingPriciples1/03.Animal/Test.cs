using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        List<Kitten> kittens = new List<Kitten>
        {
            new Kitten("Pena",3),
            new Kitten("Gina",5),
            new Kitten("Mina",2),
            new Kitten("Tina",1)
        };

        foreach (Kitten kitten in kittens)
        {
            Console.WriteLine(kitten.ToString());
        }

        List<Tomcat> tomcats = new List<Tomcat>
        {
            new Tomcat("Pesho",5),
            new Tomcat("Decho",5),
            new Tomcat("Nencho",5),
            new Tomcat("Strahil",5),
            new Tomcat("Nastradin",5),
        };

        foreach (Tomcat tomcat in tomcats)
        {
            Console.WriteLine(tomcat.ToString());
        }

        List<Cat> cats = new List<Cat>
        {
            new Cat("Pena",5,Sexes.Female),
            new Cat("Kolio",3,Sexes.Male)
        };

        foreach (Cat cat in cats)
        {
            Console.WriteLine(cat.ToString());
        }

        List<Dog> dogs = new List<Dog>
        {
            new Dog("Pencho",7,Sexes.Male),
            new Dog("Ivan",3,Sexes.Male),
            new Dog("Gina",4,Sexes.Female),
            new Dog("Tenio",17,Sexes.Male)
        };

        foreach (Dog dog in dogs)
        {
            Console.WriteLine(dog.ToString());
        }

        List<Frog> frogs = new List<Frog>
        {
            new Frog("Jiji",4,Sexes.Female),
            new Frog("Karmit",23,Sexes.Male)
        };

        foreach (Frog frog in frogs)
        {
            Console.WriteLine(frog.ToString());
        }

        Console.WriteLine("Average age of kittens: {0}", kittens.Average(x => x.Age));
        Console.WriteLine("Average age of tomcats: {0}", tomcats.Average(x => x.Age));
        Console.WriteLine("Average age of cats: {0}", cats.Average(x => x.Age));
        Console.WriteLine("Average age of dogs: {0}", dogs.Average(x => x.Age));
        Console.WriteLine("Average age of frogs: {0}\n\n", frogs.Average(x => x.Age));
    }
}

