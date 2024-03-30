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

    public string Name => name;
    public int GoalsScored => goals_scored;
    public int GoalsConceded => goals_conceded;
    public int Points => points;

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

        for (int i = 0; i < teams.Length; i++)
        {
            teams[i].PrintTeam();
        }
    }
}
