using Spectre.Console;
using STUDY.OOP.LibraryManagementSystem.Models;

namespace STUDY.OOP.LibraryManagementSystem;

public class BooksController
{
    public void ViewBooks()
    {
        Table table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        List<Book> books = MockDatabase.LibraryItems.OfType<Book>().ToList();

        foreach (Book book in books)
        {
            table.AddRow(
                book.Id.ToString(),
                $"[cyan]{book.Title}[/]",
                $"[cyan]{book.Author}[/]",
                $"[green]{book.Category}[/]",
                $"[blue]{book.Location}[/]",
                book.Pages.ToString());
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to Continue.");
        Console.ReadKey();
    }

    public void AddBook()
    {
        string title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        string author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
        string category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
        string location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
        int pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

        if (MockDatabase.LibraryItems.OfType<Book>()
            .Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]Book already exists![/]");
        }
        else
        {
            Book book = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
            MockDatabase.LibraryItems.Add(book);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press any key to Continue.");
        Console.ReadKey();
    }

    public void DeleteBook()
    {
        List<Book> books = MockDatabase.LibraryItems.OfType<Book>().ToList();
        if (books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books to delete![/]");
            AnsiConsole.MarkupLine("\nPress any key to Continue.");
            Console.ReadKey();
            return;
        }

        Book bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
                .Title("Select a [red]book[/] to delete:")
                .UseConverter(b => $"{b.Title} - {b.Pages} pages")
                .AddChoices(books));
        MockDatabase.LibraryItems.Remove(bookToDelete);
        AnsiConsole.MarkupLine("[Yellow]Book deleted successfully![/]");
        AnsiConsole.MarkupLine("\nPress any key to Continue.");
        Console.ReadKey();
    }
}