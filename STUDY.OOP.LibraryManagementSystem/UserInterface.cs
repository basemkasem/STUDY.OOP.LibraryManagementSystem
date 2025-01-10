using Spectre.Console;
using STUDY.OOP.LibraryManagementSystem.Controllers;

namespace STUDY.OOP.LibraryManagementSystem;

public class UserInterface
{
    private readonly BooksController _booksController = new BooksController();
    private readonly MagazineController _magazineController = new MagazineController();
    private readonly NewspaperController _newspaperController = new NewspaperController();  

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MenuOption>()
                    .Title("What do you want to do next?")
                    .AddChoices(Enum.GetValues<Enums.MenuOption>()));
            if (actionChoice == Enums.MenuOption.Exit)
            {
                Environment.Exit(0);
            } 
            
            var itemTypeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ItemType>()
                    .Title("What type of item do you want to manage?")
                    .AddChoices(Enum.GetValues<Enums.ItemType>()));

            switch (actionChoice)
            {
                case Enums.MenuOption.ViewItems:
                    ViewItems(itemTypeChoice);
                    break;
                case Enums.MenuOption.AddItem:
                    AddItem(itemTypeChoice);
                    break;
                case Enums.MenuOption.DeleteItem:
                    DeleteItem(itemTypeChoice);
                    break;
            }
        }
    }
    
    private void ViewItems(Enums.ItemType itemType)
    {
        switch (itemType)
        {
            case Enums.ItemType.Book:
                _booksController.ViewItems();
                break;
            case Enums.ItemType.Magazine:
                _magazineController.ViewItems();
                break;
            case Enums.ItemType.Newspaper:
                _newspaperController.ViewItems();
                break;
        }
    }
    
    private void AddItem(Enums.ItemType itemType)
    {
        switch (itemType)
        {
            case Enums.ItemType.Book:
                _booksController.AddItem();
                break;
            case Enums.ItemType.Magazine:
                _magazineController.AddItem();
                break;
            case Enums.ItemType.Newspaper:
                _newspaperController.AddItem();
                break;
        }
    }
    
    private void DeleteItem(Enums.ItemType itemType)
    {
        switch (itemType)
        {
            case Enums.ItemType.Book:
                _booksController.DeleteItem();
                break;
            case Enums.ItemType.Magazine:
                _magazineController.DeleteItem();
                break;
            case Enums.ItemType.Newspaper:
                _newspaperController.DeleteItem();
                break;
        }
    }
}