using System;

abstract class Lesson
{
    protected Student[] students;

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

    public string Name => name;
    public int Score => score;
    public int MissedClasses => missedClasses;

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

        compSciLesson.PrintStudents();
        Console.WriteLine();
        mathLesson.PrintStudents();
    }
}
