﻿using System;
class Program
{
    struct SkiJumper
    {
        private string lastName;
        private int[] styleScores;
        private int jumpDistance;

        public string LastName => lastName;
        public int[] StyleScores => styleScores;
        public int JumpDistance => jumpDistance;

        public SkiJumper(string lastName, int[] styleScores, int jumpDistance)
        {
            this.lastName = lastName;
            this.styleScores = styleScores;
            this.jumpDistance = jumpDistance;
        }
        public int CalcTotalResult()
        {
            Array.Sort(styleScores);
            int totalStyleScore = 0;
            for (int i = 1; i < styleScores.Length - 1; i++)
            {
                totalStyleScore += styleScores[i];
            }
            int distacePoints = 60 + (JumpDistance - 120) * 2;
            return totalStyleScore + distacePoints;
        }
        public string Print()
        {
            return $"{LastName}: {CalcTotalResult()} очков";
        }
    }

    static void Main()
    {
        SkiJumper[] jumpers = new SkiJumper[5];
        jumpers[0] = new SkiJumper("Смирнов", new int[] { 15, 16, 17, 18, 19 }, 125);
        jumpers[1] = new SkiJumper("Поляков", new int[] { 14, 16, 18, 19, 20 }, 122);
        jumpers[2] = new SkiJumper("Орлов", new int[] { 16, 17, 18, 19, 20 }, 118);
        jumpers[3] = new SkiJumper("Зайцев", new int[] { 15, 16, 17, 18, 19 }, 128);
        jumpers[4] = new SkiJumper("Дорожкин", new int[] { 14, 15, 16, 17, 18 }, 120);

        Array.Sort(jumpers, (x, y) => y.CalcTotalResult().CompareTo(x.CalcTotalResult()));

        Console.WriteLine("Итоговая таблица:");

        for (int i = 0; i < jumpers.Length; i++)
        {
            Console.WriteLine($"{i + 1}.{jumpers[i].Print()}");
        }

    }
}