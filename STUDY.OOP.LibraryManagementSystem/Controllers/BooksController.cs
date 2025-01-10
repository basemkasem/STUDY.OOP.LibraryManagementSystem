using Spectre.Console;
using STUDY.OOP.LibraryManagementSystem.Models;

namespace STUDY.OOP.LibraryManagementSystem.Controllers;

public class BooksController : BaseController,IBaseController
{
    public void ViewItems()
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

    public void AddItem()
    {
        string title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        string author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
        string category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
        string location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
        int pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

        if (MockDatabase.LibraryItems.OfType<Book>().Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            DisplayMessage("Book added successfully!", "green");
        }
        else
        {
            var newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
            MockDatabase.LibraryItems.Add(newBook);
            DisplayMessage("Book added successfully!", "green");
        }

        DisplayMessage("Press Any Key to Continue.");
        Console.ReadKey();

    }

    public void DeleteItem()
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
        if (ConfirmDeletion(bookToDelete.Title))
        {
            if (MockDatabase.LibraryItems.Remove(bookToDelete))
            {
                DisplayMessage("Book deleted successfully!", "red");
            }
            else
            {
                DisplayMessage("Book not found.", "red");
            }
        } else
        {
            DisplayMessage("Deletion canceled.", "yellow");
        }

        DisplayMessage("Press Any Key to Continue.", "green");
        Console.ReadKey();
    }
}