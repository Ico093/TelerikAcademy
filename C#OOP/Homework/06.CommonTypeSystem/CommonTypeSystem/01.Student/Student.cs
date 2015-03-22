using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum University
{
    SU, UNSS, UASG, TU
}

public enum Facultity
{
    FMI, PF, HF
}

public enum Speciality
{
    KN, SI, IT, I
}

class Student:ICloneable,IComparable<Student>
{
    private string firstName, middleName, lastName;
    private string ssn;
    private string permanentAddress;
    private string mobilePhone;
    private string email;
    private University university;
    private Facultity facultity;
    private Speciality speciality;

    public string FirstName
    {
        get { return firstName; }
    }

    public string MiddleName
    {
        get { return middleName; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public string SSN
    {
        get { return ssn; }
    }

    public string PermanentAddress
    {
        get { return permanentAddress; }
    }

    public string MobilePhone
    {
        get { return mobilePhone; }
    }

    public string Email
    {
        get { return email; }
    }

    public University University
    {
        get { return university; }
    }

    public Facultity Facultity
    {
        get { return facultity; }
    }

    public Speciality Speciality
    {
        get { return speciality; }
    }

    public Student(string firstName, string middleName, string lastName, string SSN, string permanentAddress, string mobilePhone, string email,
        University university, Facultity facultity, Speciality speciality)
    {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.ssn = SSN;
        this.permanentAddress = permanentAddress;
        this.mobilePhone = mobilePhone;
        this.email = email;
        this.university = university;
        this.facultity = facultity;
        this.speciality = speciality;
    }

    public override bool Equals(object obj)
    {

        Student student=obj as Student;
        
        if((object)obj==null)
        {
            return false;
        }

        if (this.SSN.CompareTo(student.SSN) != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override int GetHashCode()
    {
        return FirstName.GetHashCode()^MiddleName.GetHashCode()^LastName.GetHashCode()^SSN.GetHashCode();
    }

    public override string ToString()
    {
        return String.Format("Name:{0} {1} {2}\nSSN:{3}\nPermanent address:{4}\nMobile phone:{5}\nEmail:{6}\nUniversity:{7}\nFacultity:{8}\nSpeciality:{9}\n\n",FirstName,MiddleName,LastName,SSN,PermanentAddress,MobilePhone,Email,University,Facultity,Speciality);
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }

    public Student Clone()
    {
        return new Student(FirstName,MiddleName,LastName,SSN,PermanentAddress,MobilePhone,Email,University,Facultity,Speciality);
    }

    public int CompareTo(Student student)
    {
        if (this.FirstName.CompareTo(student.FirstName) == 0)
        {
            if (int.Parse(this.SSN) < int.Parse(student.SSN))
            {
                return -1;
            }
            else if (int.Parse(this.SSN) > int.Parse(student.SSN))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else if (this.FirstName.CompareTo(student.FirstName) > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public static bool operator ==(Student student1,Student student2)
    {
        return Student.Equals(student1, student2);
    }

    public static bool operator !=(Student student1, Student student2)
    {
        return !Student.Equals(student1, student2);
    }
}