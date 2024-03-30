using System;

abstract class SkiJump
{
    protected string disciplineName;

    public abstract string DisciplineName { get; }

    public abstract int CalcTotalResult();

    public abstract string Print();
}

class Jump120m : SkiJump
{
    public override string DisciplineName => "Прыжки на 120м";

    private string lastName;
    private int[] styleScores;
    private int jumpDistance;

    public Jump120m(string lastName, int[] styleScores, int jumpDistance)
    {
        this.lastName = lastName;
        this.styleScores = styleScores;
        this.jumpDistance = jumpDistance;
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
    public override string DisciplineName => "Прыжки на 180м";

    private string lastName;
    private int[] styleScores;
    private int jumpDistance;

    public Jump180m(string lastName, int[] styleScores, int jumpDistance)
    {
        this.lastName = lastName;
        this.styleScores = styleScores;
        this.jumpDistance = jumpDistance;
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
        SkiJump[] jumpers = new SkiJump[5];
        jumpers[0] = new Jump120m("Смирнов", new int[] { 15, 16, 17, 18, 19 }, 125);
        jumpers[1] = new Jump120m("Поляков", new int[] { 14, 16, 18, 19, 20 }, 122);
        jumpers[2] = new Jump180m("Орлов", new int[] { 16, 17, 18, 19, 20 }, 188);
        jumpers[3] = new Jump180m("Зайцев", new int[] { 15, 16, 17, 18, 19 }, 178);
        jumpers[4] = new Jump180m("Дорожкин", new int[] { 14, 15, 16, 17, 18 }, 194);

        Array.Sort(jumpers, (x, y) => y.CalcTotalResult().CompareTo(x.CalcTotalResult()));

        Console.WriteLine("Итоговая таблица:");

        foreach (var jumper in jumpers)
        {
            Console.WriteLine($"{jumper.DisciplineName}: {jumper.Print()}");
        }
    }
}
