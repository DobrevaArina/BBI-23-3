public class Book
{
    public string Title { get; }
    public int ISBN { get;}
    public string Author { get;}
    public int PublicationYear { get;}
    private static int isbn = 0;

    public Book(string title, string author, int publicationYear)
    {
        Title = title;
        isbn++;
        ISBN = isbn;
        Author = author;
        PublicationYear = publicationYear;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Publication Year: {PublicationYear}");
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
}

class Program
{
    static void Main()
    {

        Book[] books = new Book[10]
        {
            new Book("Вино из одуванчиков", "Брэдбери", 1979),
            new Book("1984", "Оруэл", 1954),
            new Book("Приют грёз", "Ремарк", 1949),
            new Book("Капиатнская дочка", "Пушкин", 1860),
            new Book("Маленький прицн", "Экзюпери", 1625),
            new Book("Герой нашего времени", "Лермонтов", 1500),
            new Book("Белые ночи", "Достоевский", 1825),
            new Book("Война и мир", "Толстой", 1825),
            new Book("Яма", "Куприн", 1650),
            new Book("Скотный двор", "Оруэл", 1970),
        };
         
        string author = "Оруэл";
        int century = 20;

        Console.WriteLine("Информация о всех книгах:");
        foreach (Book book in books)
        {
            book.PrintInfo();
        }

        Book.PrintBooksByAuthor(books, author);

        Book.PrintBooksByCentury(books, century);
    }
}
