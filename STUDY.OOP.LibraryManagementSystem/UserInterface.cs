using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem;

public class UserInterface
{
    private BooksController _booksController;

    public UserInterface()
    {
        _booksController = new BooksController();
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MenuOption>()
                    .Title("What do you want to do next?")
                    .AddChoices(Enum.GetValues<Enums.MenuOption>()));

            switch (choice)
            {
                case Enums.MenuOption.ViewBooks:
                    _booksController.ViewBooks();
                    break;
                case Enums.MenuOption.AddBook:
                    _booksController.AddBook();
                    break;
                case Enums.MenuOption.DeleteBook:
                    _booksController.DeleteBook();
                    break;
                case Enums.MenuOption.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}