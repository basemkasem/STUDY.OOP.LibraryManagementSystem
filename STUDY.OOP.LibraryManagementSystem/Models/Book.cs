using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem.Models;

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
                       $"\n[Bold]Pages[/]: [yellow]{Pages}[/]" +
                       $"\n[Bold]Category[/]: [green]{Category}[/]" +
                       $"\n[Bold]Location[/]: [blue]{Location}[/]"))
        {
            Border = BoxBorder.Rounded
            //BorderStyle = new Style(foreground: Color.Cyan)
        };
        
        AnsiConsole.Write(panel);
    }
}