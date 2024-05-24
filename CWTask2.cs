
	

﻿using System.Collections;

public abstract class Book
{
    protected string Title { get; }
    protected int ISBN { get;}
    protected string Author { get;}
    protected int PublicationYear { get;}
    public int Price { get; protected set; }
    private static int isbn = 0;

    public Book(string title, string author, int publicationYear, int price)
    {
        Title = title;
        isbn++;
        ISBN = isbn;
        Author = author;
        PublicationYear = publicationYear;
        Price = price;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Publication Year: {PublicationYear}");
        Console.WriteLine($"Price {Price}");
        Console.WriteLine();
    }

    public static void PrintBooksByAuthor(Book[] books, string author)
    {
        Console.WriteLine($"Книги автора {author}:");
        foreach (Book book in books)
        {
            if (book.Author == author)
            {
                book.PrintInfo();
            }
        }
    }

    public static void PrintBooksByCentury(Book[] books, int century)
    {
        Console.WriteLine($"Книги {century}-го века:");
        foreach (Book book in books)
        {
            if ((book.PublicationYear / 100)+1 == century)
            {
                book.PrintInfo();
            }
        }
    }
    public abstract void CalculatePrice();
}
public class PaperBook : Book
{
    public bool HardCover { get; }

    public PaperBook(string title, string author, int year, int price, bool hardCover)
        : base(title, author, year, price)
    {
        HardCover = hardCover;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        if (HardCover)
        {
            Price = Price * 100;
        }
    }
}
public class ElectronicBook : Book
{
    public string Format { get; }

    public ElectronicBook(string title, string author, int year, int price, string format)
        : base(title, author, year, price)
    {
        Format = format;
        CalculatePrice();
    }


    public override void CalculatePrice()
    {
        if (Format=="pdf")
        {
            Price = Price * 12;
        }
        if (Format == "txt")
        {
            Price = Price * 13;
        }
        if (Format == "docx")
        {
            Price = Price * 14;
        }
    }
}
public class AudioBook : Book
{
    public bool StudioRecording { get; }

    public AudioBook(string title, string author, int year, int price, bool studioRecording)
        : base(title, author, year, price)
    {
        StudioRecording = studioRecording;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        if (StudioRecording)
        {
            Price= Price * 16; 
        }
    }
}


class Program
{
    static void Main()
    {

        //Book[] books = new Book[10]
        //{
        //    new Book("Вино из одуванчиков", "Брэдбери", 1979),
        //    new Book("1984", "Оруэл", 1954),
        //    new Book("Приют грёз", "Ремарк", 1949),
        //    new Book("Капиатнская дочка", "Пушкин", 1860),
        //    new Book("Маленький прицн", "Экзюпери", 1625),
        //    new Book("Герой нашего времени", "Лермонтов", 1500),
        //    new Book("Белые ночи", "Достоевский", 1825),
        //    new Book("Война и мир", "Толстой", 1825),
        //    new Book("Яма", "Куприн", 1650),
        //    new Book("Скотный двор", "Оруэл", 1970),
        //};


        Book[] paperBooks = 
        {
            new PaperBook("Вино из одуванчиков", "Author A", 1985, 20, true),
            new PaperBook("1984", "Оруэл", 1954, 15, false),
            new PaperBook("Приют грёз", "Ремарк", 1995, 25, true),
            new PaperBook("Маленький прицн", "Экзюпери", 2005, 18, false),
            new PaperBook("Белые ночи", "Достоевский", 2010, 22, true)
        };

        Book[] electronicBooks = 
        {
            new ElectronicBook("Яма", "Куприн", 1985, 10, "pdf"),
            new ElectronicBook("Война и мир", "Толстой", 2001, 12, "fb2"),
            new ElectronicBook("Белые ночи", "Достоевский", 1995, 8, "epub"),
            new ElectronicBook("Капиатнская дочка", "Пушкин", 2005, 9, "pdf"),
            new ElectronicBook("Герой нашего времени", "Лермонтов", 2010, 11, "epub")
        };

        Book[] audioBooks =
        {
            new AudioBook("Пиковая дама", "Пушкин", 1985, 15, true),
            new AudioBook("Вий", "Гоголь", 2001, 20, false),
            new AudioBook("Мертвые души",  "Гоголь", 1995, 18, true),
            new AudioBook("Алхимик",  "Коэльо", 2005, 22, false),
            new AudioBook("Грозовой перевал", "Бронте", 2010, 19, true)
        };

        Console.WriteLine("Paper Books (sorted by price):");
        Sort(paperBooks);
        for (int i =0; i<5; i++)
        {
            paperBooks[i].PrintInfo();
        }

        Console.WriteLine("\nElectronic Books (sorted by price):");
        Sort(electronicBooks);
        for (int i = 0; i < 5; i++)
        {
            electronicBooks[i].PrintInfo();
        }

        Console.WriteLine("\nAudio Books (sorted by price):");
        Sort(audioBooks);
        for (int i = 0; i < 5; i++)
        {
            audioBooks[i].PrintInfo();
        }
        Book[] allBooks = new Book[15];
        for (int i=0; i < 5; i++)
        {
            allBooks[i] = paperBooks[i];
            allBooks[i+5] = audioBooks[i];
            allBooks[i+10]= electronicBooks[i];
        }
        Console.WriteLine("Lf");
        Sort(allBooks);
        for (int i = 0; i < 15; i++)
        {
            allBooks[i].PrintInfo();
        }
    }

    private static void Sort(Book[] books)
    {
       for (int i=0; i<books.Length;i++)
        {
            for (int j=0; j<books.Length-1; j++)
            {
                if (books[j].Price < books[j + 1].Price)
                {
                    var t = books[j];
                    books[j] = books[j+1];
                    books[j+1] = t;
                }
            }
        }
    }
}
