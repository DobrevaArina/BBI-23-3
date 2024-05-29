using lab_9.Serializers;
using System;
using System.Linq;

class FootballTeam
{
    protected string name;
    protected int goals_scored;
    protected int goals_conceded;
    protected int points;

    public FootballTeam(string name, int goalsScored, int goalsConceded)
    {
        this.name = name;
        this.goals_scored = goalsScored;
        this.goals_conceded = goalsConceded;
        this.points = 0;
    }

    public string Name { get { return name; } set { name = value; } }
    public int GoalsScored { get { return goals_scored; } set { goals_scored = value; } }
    public int GoalsConceded { get { return goals_conceded; } set { goals_conceded = value; } }
    public int Points { get { return points; } set { points = value; }  }

    public virtual void Win()
    {
        points += 3;
    }

    public virtual void Draw()
    {
        points += 1;
    }

    public void PrintTeam()
    {
        Console.WriteLine($"Team: {name}, Points: {points}");
    }
}

class WomenFootballTeam : FootballTeam
{
    public WomenFootballTeam(string name, int goalsScored, int goalsConceded) : base(name, goalsScored, goalsConceded)
    {
    }
}

class MenFootballTeam : FootballTeam
{
    public MenFootballTeam(string name, int goalsScored, int goalsConceded) : base(name, goalsScored, goalsConceded)
    {
    }
}

class Program
{
    static void Main()
    {
        FootballTeam[] teams = new FootballTeam[7]
        {
            new WomenFootballTeam("Team1", 4, 2),
            new MenFootballTeam("Team2", 3, 3),
            new MenFootballTeam("Team3", 1, 4),
            new MenFootballTeam("Team4", 1, 1),
            new WomenFootballTeam("Team5", 5, 2),
            new MenFootballTeam("Team6", 2, 5),
            new WomenFootballTeam("Team7", 3, 1)
        };

        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = i + 1; j < teams.Length; j++)
            {
                if (teams[i].GoalsScored > teams[j].GoalsScored)
                    teams[i].Win();
                else if (teams[i].GoalsScored == teams[j].GoalsScored)
                {
                    teams[i].Draw();
                    teams[j].Draw();
                }
                else
                    teams[j].Win();
            }
        }

        for (int i = 0; i < teams.Length; i++)
        {
            for (int j = i; j < teams.Length; j++)
            {
                if (teams[i].Points < teams[j].Points)
                    (teams[i], teams[j]) = (teams[j], teams[i]);
                else if (teams[i].Points == teams[j].Points && teams[i].GoalsScored - teams[i].GoalsConceded < teams[j].GoalsScored - teams[j].GoalsConceded)
                    (teams[i], teams[j]) = (teams[j], teams[i]);
            }
        }
        string directory = "lab93";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, directory);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        MySer Ser = new MyJsonSer();
        string[] filesNames = { "Teams.json" };
        if (!File.Exists(Path.Combine(path, filesNames[0])))
        {
            Ser.Write(teams, Path.Combine(path, filesNames[0]));
        }
        var Tem = Ser.Read<FootballTeam[]>(Path.Combine(path, filesNames[0]));
        foreach(var t in Tem)
        {
            t.PrintTeam();
        }

        //for (int i = 0; i < teams.Length; i++)
        //{
        //    teams[i].PrintTeam();
        //}
    }
}