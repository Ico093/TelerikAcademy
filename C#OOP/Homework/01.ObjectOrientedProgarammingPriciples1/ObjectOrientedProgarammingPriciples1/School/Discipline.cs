using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Discipline : OptionalComment
{
    private string name;
    private int numberOfLectures;
    private int numberOfExercises;
    private string optionalComment;

    public string Name
    {
        get { return name; }
    }

    public int NumberOfLectures
    {
        get { return numberOfLectures; }
    }

    public int NumberOfExercises
    {
        get { return numberOfExercises; }
    }

    public string OptionalComment
    { 
        get  { return optionalComment; } 
    }

    public Discipline(string name, int numberOfLectures, int numberOfExercises)
    {
        this.name = name;
        this.numberOfLectures = numberOfLectures;
        this.numberOfExercises = numberOfExercises;
        this.optionalComment = "";
    }

    public Discipline(string name, int numberOfLectures, int numberOfExercises,string optionalComment)
    {
        this.name = name;
        this.numberOfLectures = numberOfLectures;
        this.numberOfExercises = numberOfExercises;
        this.optionalComment = optionalComment;
    }

    public override string ToString()
    {
        return string.Format("Discipline:{0}\nNumber of lectures:{1}\nNumber of exercises:{2}\n",Name,NumberOfLectures,NumberOfExercises);
    }
}