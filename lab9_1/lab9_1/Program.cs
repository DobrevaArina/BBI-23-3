using lab_9.Serializers;
using System;

abstract class Lesson
{
    protected Student[] students;
    public Student[] Students {  get { return students; }}

    public abstract void PrintStudents();
}

class ComputerScienceLesson : Lesson
{
    public ComputerScienceLesson(Student[] students)
    {
        this.students = students;
    }

    public override void PrintStudents()
    {
        Console.WriteLine("Студенты на занятии по информатике:");
        foreach (var student in students)
        {
            student.Print();
        }
    }
}

class MathLesson : Lesson
{
    public MathLesson(Student[] students)
    {
        this.students = students;
    }

    public override void PrintStudents()
    {
        Console.WriteLine("Студенты на занятии по математике:");
        foreach (var student in students)
        {
            student.Print();
        }
    }
}

class Student
{
    private string name;
    private int score;
    private int missedClasses;

    public string Name { get { return name; } set { name = value; } }
    public int Score { get { return score; } set { score = value; } }
    public int MissedClasses { get { return missedClasses; } set { missedClasses = value; } }

    public Student(string name, int score, int missedClasses)
    {
        this.name = name;
        this.score = score;
        this.missedClasses = missedClasses;
    }

    public void Print()
    {
        Console.WriteLine($"{Name} - {MissedClasses} пропущенных занятий");
    }
}

class Program
{
    static void Main()
    {
        Student[] computerScienceStudents = new Student[]
        {
            new Student("Илья", 2, 5),
            new Student("Маша", 4, 3),
            new Student("Саша", 2, 2)
        };

        Student[] mathStudents = new Student[]
        {
            new Student("Витя", 3, 1),
            new Student("Соня", 5, 0),
            new Student("Катя", 2, 4)
        };

        ComputerScienceLesson compSciLesson = new ComputerScienceLesson(computerScienceStudents);
        MathLesson mathLesson = new MathLesson(mathStudents);

        string directory = "lab91";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path,directory);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        MySer Ser= new MyJsonSer();
        string[] filesNames = {"CPLes.json", "MLes.json" };
        if (!File.Exists(Path.Combine(path, filesNames[0])))
        {
            Ser.Write(compSciLesson, Path.Combine(path, filesNames[0]));
        }
        if (File.Exists(Path.Combine(path, filesNames[1])))
        {
            Ser.Write(mathLesson, Path.Combine(path, filesNames[1]));
        }
        var CPL = Ser.Read<ComputerScienceLesson>(Path.Combine(path, filesNames[0]));
        CPL.PrintStudents();
        Console.WriteLine();
        var ML = Ser.Read<MathLesson>(Path.Combine(path, filesNames[1]));
        ML.PrintStudents();
    }
}