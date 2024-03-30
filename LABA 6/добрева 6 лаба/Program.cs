using System;
struct Team
{
    private string name;
    private int goals_scored;
    private int goals_conceded;
    private int points;

    public Team(string name, int goalsScored, int goalsConceded)
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

    public void Win()
    {
        points += 3;
    }

    public void Draw()
    {
        points += 1;
    }

    public void PrintTeam()
    {
        Console.WriteLine($"Team: {name}, Points: {points}");
    }
}

class Program
{
    static void Main()
    {
        Team[] teams = new Team[7]
        {
            new Team("Team1", 4, 2),
            new Team("Team2", 3, 3),
            new Team("Team3", 1, 4),
            new Team("Team4", 1, 1),
            new Team("Team5", 5, 2),
            new Team("Team6", 2, 5),
            new Team("Team7", 3, 1)
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