using lab_9.Serializers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
abstract class SkiJump
{

    protected string disciplineName ;
    protected string lastName;
    protected int[] styleScores;
    protected int jumpDistance;

    public string DisciplineName { get { return disciplineName; } set { disciplineName = value; } }
    public string LastName { get { return lastName; } set { lastName = value; } }

    public int[] StyleScores { get { return styleScores; } set { styleScores = value; } }

    public int JumpDistance { get { return jumpDistance; } set { jumpDistance = value; } }
   
    public SkiJump() { }

    public SkiJump(string lastName, int[] styleScores, int jumpDistance)
    {
        this.lastName = lastName;
        this.styleScores = styleScores;
        this.jumpDistance = jumpDistance;
        disciplineName = "";
    }

    public abstract int CalcTotalResult();

    public abstract string Print();
}

class Jump120m : SkiJump
{

    public Jump120m() { }
    public Jump120m(string lastName, int[] styleScores, int jumpDistance): base(lastName, styleScores, jumpDistance)
    {
        disciplineName= "120 Meters";
    }

    public override int CalcTotalResult()
    {
        Array.Sort(styleScores);
        int totalStyleScore = 0;
        for (int i = 1; i < styleScores.Length - 1; i++)
        {
            totalStyleScore += styleScores[i];
        }
        int distancePoints = 60 + (jumpDistance - 120) * 2;
        return totalStyleScore + distancePoints;
    }

    public override string Print()
    {
        return $"{lastName}: {CalcTotalResult()} очков";
    }
}

class Jump180m : SkiJump
{

    
  
    public Jump180m() { }
    public Jump180m(string lastName, int[] styleScores, int jumpDistance): base(lastName, styleScores, jumpDistance)
    {
        disciplineName = "180 Meters";
    }

    public override int CalcTotalResult()
    {
        Array.Sort(styleScores);
        int totalStyleScore = 0;
        for (int i = 1; i < styleScores.Length - 1; i++)
        {
            totalStyleScore += styleScores[i];
        }
        int distancePoints = 60 + (jumpDistance - 180) * 2;
        return totalStyleScore + distancePoints;
    }

    public override string Print()
    {
        return $"{lastName}: {CalcTotalResult()} очков";
    }
}

class Program
{
    static void Main()
    {
        Jump120m[] j120 =
        {
             new Jump120m("Смирнов", new int[] { 15, 16, 17, 18, 19 }, 125),
             new Jump120m("Поляков", new int[] { 14, 16, 18, 19, 20 }, 122)
        };
        Jump180m[] j180 =
        {
            new Jump180m("Орлов", new int[] { 16, 17, 18, 19, 20 }, 188),
            new Jump180m("Зайцев", new int[] { 15, 16, 17, 18, 19 }, 178),
            new Jump180m("Дорожкин", new int[] { 14, 15, 16, 17, 18 }, 194)
        };
        SkiJump[] jumpers = new SkiJump[5];
        for (int i = 0; i < 2; i++)
        {
            jumpers[i] = j120[i];
            jumpers[i + 2] = j180[i];
        }
        jumpers[4] = j180[2];
      

        Array.Sort(jumpers, (x, y) => y.CalcTotalResult().CompareTo(x.CalcTotalResult()));
        Array.Sort(j120, (x, y) => y.CalcTotalResult().CompareTo(x.CalcTotalResult()));
        Array.Sort(j180, (x, y) => y.CalcTotalResult().CompareTo(x.CalcTotalResult()));
        string directory = "lab92";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, directory);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        MySer Ser = new MyJsonSer();
        string[] filesNames = { "Jumpers120.json", "Jumpers180.json" };
        if (!File.Exists(Path.Combine(path, filesNames[0])))
        {
            Ser.Write(j120, Path.Combine(path, filesNames[0]));
        }
        if (!File.Exists(Path.Combine(path, filesNames[1])))
        {
            Ser.Write(j180, Path.Combine(path, filesNames[1]));
        }

        var jumpers1 = Ser.Read<Jump120m[]>(Path.Combine(path, filesNames[0]));
        var jumpers2 = Ser.Read<Jump180m[]>(Path.Combine(path, filesNames[1]));
        Console.WriteLine("Итоговая таблица:");
        foreach (var jumper in jumpers1)
        {
            Console.WriteLine($"{jumper.DisciplineName}: {jumper.Print()}");
        }
        Console.WriteLine();
        foreach (var jumper in jumpers2)
        {
            Console.WriteLine($"{jumper.DisciplineName}: {jumper.Print()}");
        }
    }
}