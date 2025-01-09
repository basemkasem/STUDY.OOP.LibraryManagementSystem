using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem;

public static class BooksController
{
    
    private static List<string> _books = 
    [
        "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit",
        "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World",
        "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451",
        "Catch-22", "The Hitchhiker's Guide to the Galaxy"
    ];
    public static void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
        foreach (string book in _books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to Continue.");
        Console.ReadKey();
    }

    public static void AddBook()
    {
        string title = AnsiConsole.Ask<string>("Enter the [cyan]title[/] of the book to add:");
        if (_books.Contains(title))
        {
            AnsiConsole.MarkupLine("[red]Book already exists![/]");
        }
        else
        {
            _books.Add(title);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press any key to Continue.");
        Console.ReadKey();
    }

    public static void DeleteBook()
    {
        if (_books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books to delete![/]");
            Console.ReadKey();
            return;
        }

        string bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a [red]book[/] to delete:")
                .AddChoices(_books));
        if (_books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[green]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found![/]");
        }
    }
}