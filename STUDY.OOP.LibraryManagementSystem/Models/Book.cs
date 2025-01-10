using Spectre.Console;
using STUDY.OOP.LibraryManagementSystem.Models;

namespace STUDY.OOP.LibraryManagementSystem;

public class Book : LibraryItem
{
    public string Author { get; set; }
    public string Category { get; set; }
    public int Pages { get; set; } = 0;

    public Book(int id, string name, string author, string category, string location, int pages) : base(id, name,
        location)
    {
        Author = author;
        Category = category;
        Pages = pages;
    }

    public override void DisplayInfo()
    {
        Panel panel = new(
            new Markup($"[Bold]Book[/]: [cyan]{Title}[/] by [cyan]{Author}[/]" +
                       $"[Bold]Pages[/]: [yellow]{Pages}[/]" +
                       $"[Bold]Category[/]: [green]{Category}[/]" +
                       $"[Bold]Location[/]: [blue]{Location}[/]"))
        {
            Border = BoxBorder.Rounded
            //BorderStyle = new Style(foreground: Color.Cyan)
        };
        
        AnsiConsole.Write(panel);
    }
}