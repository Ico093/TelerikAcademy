using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Sexes { Male, Female };

public abstract class Animal:ISound
{
    private string name;
    private int age;
    private Sexes sex;

    public string Name
    {
        get { return name; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0 && value < 80)
            {
                age = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Age can't be less than 0 and more than 80.");
            }
        }
    }

    public Sexes Sex
    {
        get { return sex; }
    }

    public Animal(string name, int age, Sexes sex)
    {
        this.name = name;
        this.Age = age;
        this.sex = sex;
    }

    public string Speack(Animal animal)
    {
        return string.Format("{0}\nName: {1}\nAge: {2}\nSex: {3}\nProduced sound: {4}\n\n\n",animal.GetType(),animal.Name,animal.Age,animal.Sex,animal.ProduceSound());
    }

    public abstract string ProduceSound();

    public abstract override string ToString();
}

