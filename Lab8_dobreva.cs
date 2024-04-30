using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

abstract class Task
{
    public abstract string Process(string input);
}

class ReverseTextTask : Task
{
    public override string Process(string input)
    {
        string[] words = input.Split(' ');
        bool isEncrypted = IsEncrypted(words);

        if (isEncrypted)
        {

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = ReverseWord(words[i]);
            }
        }
        else
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = ReverseWord(words[i]);
            }
        }

        return string.Join(" ", words);
    }

    private bool IsEncrypted(string[] words)
    {
        foreach (string word in words)
        {
            if (!IsReversed(word))
            {
                return false;
            }
        }
        return true;
    }

    private bool IsReversed(string word)
    {
        char[] chars = word.ToCharArray();
        Array.Reverse(chars);
        string reversedWord = new string(chars);
        return word.Equals(reversedWord);
    }

    private string ReverseWord(string word)
    {
        char[] chars = word.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}


class SentenceComplexityTask : Task
{
    public override string Process(string input)
    {
        int wordCount = CountWords(input);
        int punctuationCount = CountPunctuation(input);
        int complexity = wordCount + punctuationCount;
        return $"Сложность предложения: {complexity}";
    }

    private int CountWords(string sentence)
    {
        MatchCollection matches = Regex.Matches(sentence, @"\b\w+\b");
        return matches.Count;
    }

    private int CountPunctuation(string sentence)
    {
        MatchCollection matches = Regex.Matches(sentence, @"[.,\/#!$%\^&\*;:{}=\-_`~()""']");
        return matches.Count;
    }
}

class StartingLettersFrequencyTask : Task
{
    public override string Process(string input)
    {
        Dictionary<char, int> frequencyMap = new Dictionary<char, int>();

        string[] words = input.Split(' ');
        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                char firstLetter = char.ToLower(word[0]);
                if (char.IsLetter(firstLetter))
                {
                    if (frequencyMap.ContainsKey(firstLetter))
                    {
                        frequencyMap[firstLetter]++;
                    }
                    else
                    {
                        frequencyMap.Add(firstLetter, 1);
                    }
                }
            }
        }

        var sortedMap = frequencyMap.OrderByDescending(pair => pair.Value);

        StringBuilder result = new StringBuilder();
        foreach (var pair in sortedMap)
        {
            result.AppendLine($"Буква '{pair.Key}': {pair.Value}");
        }

        return result.ToString();
    }
}

class WordSequenceTask : Task
{
    public override string Process(string input)
    {
        Console.WriteLine("Введите последовательность букв:");
        string sequence = Console.ReadLine().ToLower();

        string[] words = input.Split(' ');
        List<string> matchedWords = new List<string>();

        foreach (string word in words)
        {
            if (word.ToLower().Contains(sequence))
            {
                matchedWords.Add(word);
            }
        }

        return string.Join(", ", matchedWords);
    }
}

class SurnameSortingTask : Task
{
    public override string Process(string input)
    {
        string[] surnames = input.Split(',').Select(s => s.Trim()).OrderBy(s => s).ToArray();
        return string.Join(", ", surnames);
    }
}

class NumberSumTask : Task
{
    public override string Process(string input)
    {
        int sum = 0;

        string[] words = input.Split(' ');
        foreach (string word in words)
        {
            if (int.TryParse(word, out int number))
            {
                if (number >= 1 && number <= 10)
                {
                    sum += number;
                }
            }
        }

        return $"Сумма чисел от 1 до 10 в тексте: {sum}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите задание: ");
        Console.WriteLine("1) Зашифровать и расшифровать сообщение.");
        Console.WriteLine("2) Определить сложность предложения.");
        Console.WriteLine("3) Вывести буквы, на которые начинаются слова в тексте, в порядке убывания их употребления.");
        Console.WriteLine("4) Вывести слова, содержащие заданную последовательность букв.");
        Console.WriteLine("5) Упорядочить список фамилий по алфавиту.");
        Console.WriteLine("6) Найти сумму чисел от 1 до 10 в тексте.");
        Console.Write("Ваш выбор: ");

        int choice = int.Parse(Console.ReadLine());

        Task task;
        switch (choice)
        {
            case 1:
                task = new ReverseTextTask();
                break;
            case 2:
                task = new SentenceComplexityTask();
                break;
            case 3:
                task = new StartingLettersFrequencyTask();
                break;
            case 4:
                task = new WordSequenceTask();
                break;
            case 5:
                task = new SurnameSortingTask();
                break;
            case 6:
                task = new NumberSumTask();
                break;
            default:
                Console.WriteLine("Недопустимый выбор.");
                return;
        }

        Console.Write("Введите текст: ");
        string input = Console.ReadLine();

        string result = task.Process(input);
        Console.WriteLine($"Результат:\n{result}");
    }
}
