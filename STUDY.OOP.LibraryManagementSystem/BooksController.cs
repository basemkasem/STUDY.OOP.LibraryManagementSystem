using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem;

public class BooksController
{
    public void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
        foreach (Book book in MockDatabase.Books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book.Name}[/] - [yellow]{book.Pages}[/] pages");
        }

        AnsiConsole.MarkupLine("Press any key to Continue.");
        Console.ReadKey();
    }

    public void AddBook()
    {
        string title = AnsiConsole.Ask<string>("Enter the [cyan]title[/] of the book to add:");
        int pages  = AnsiConsole.Ask<int>("Enter the [yellow]number of pages[/] of the book:");
        if (MockDatabase.Books.Exists(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]Book already exists![/]");
        }
        else
        {
            Book book = new Book(title, pages);
            MockDatabase.Books.Add(book);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press any key to Continue.");
        Console.ReadKey();
    }

    public void DeleteBook()
    {
        if (MockDatabase.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books to delete![/]");
            Console.ReadKey();
            return;
        }

        Book bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
                .Title("Select a [red]book[/] to delete:")
                .UseConverter(b => $"{b.Name} - {b.Pages} pages")
                .AddChoices(MockDatabase.Books));
        if (MockDatabase.Books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[green]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found![/]");
        }
    }
}