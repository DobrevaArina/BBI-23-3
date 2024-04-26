using System;
using System.IO;
using System.Text.Json;

namespace kr
{
    internal class Programm
    {
        abstract class Task
        {
            protected string text = "";
            public string Text
            {
                get => text;
                protected set => text = value;
            }
            public Task(string text)
            {
                this.text = text;
            }
        }

        class Task1 : Task
        {
            private int wordCount;
            public int WordCount
            {
                get => wordCount;
                private set => wordCount = value;
            }

            public Task1(string text) : base(text)
            {
                string[] words = text.Split(new char[] { ' ', '.', '!', '"', '(', ')', '\'', ',', ';', ':', '–' });
                int count = 0;
                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        count++;
                    }
                }
                wordCount = count;
            }

            public override string ToString()
            {
                return wordCount.ToString();
            }
        }

        class Task2 : Task
        {
            private string[] centralWords;

            public string[] CentralWords
            {
                get => centralWords;
                private set => centralWords = value;
            }

            public Task2(string text) : base(text)
            {
                string[] sentences = text.Split(new char[] { '.', '!', '?' });
                centralWords = new string[sentences.Length];

                for (int i = 0; i < sentences.Length; i++)
                {
                    string[] words = sentences[i].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                    {
                        int centralIndex = words.Length / 2;
                        centralWords[i] = words[centralIndex];
                    }
                    else
                    {
                        centralWords[i] = "";
                    }
                }
            }

            public override string ToString()
            {
                return string.Join(", ", centralWords);
            }
        }

        class JsonIO
        {
            public static void Write<T>(T obj, string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    JsonSerializer.Serialize(fs, obj);
                }
            }

            public static T Read<T>(string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    return JsonSerializer.Deserialize<T>(fs);
                }
            }
        }

        public static void Main(string[] args)
        {
            string s1 = "На вершине горы стоит маленький домик. В нем живет старик с котом.";
            string s2 = "Золотая рыбка исполнила три желания девочке.";
            Task[] tasks = {
                new Task1(s1),
                new Task2(s2)
            };

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Answer");
            string task1FilePath = Path.Combine(folderPath, "task_1.json");
            string task2FilePath = Path.Combine(folderPath, "task_2.json");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(task1FilePath) || !File.Exists(task2FilePath))
            {
                JsonIO.Write<Task1>((Task1)tasks[0], task1FilePath);
                JsonIO.Write<Task2>((Task2)tasks[1], task2FilePath);
            }
            else
            {
                var t1 = JsonIO.Read<Task1>(task1FilePath);
                var t2 = JsonIO.Read<Task2>(task2FilePath);
                Console.WriteLine("Task 1 Word Count: " + t1);
                Console.WriteLine("Task 2 Central Words: " + t2);
            }
        }
    }
}
