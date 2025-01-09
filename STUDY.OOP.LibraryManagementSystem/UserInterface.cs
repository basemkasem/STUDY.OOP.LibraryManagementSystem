using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem;

public static class UserInterface
{
    public static void MainMenu()
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
                    BooksController.ViewBooks();
                    break;
                case Enums.MenuOption.AddBook:
                    BooksController.AddBook();
                    break;
                case Enums.MenuOption.DeleteBook:
                    BooksController.DeleteBook();
                    break;
                case Enums.MenuOption.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}