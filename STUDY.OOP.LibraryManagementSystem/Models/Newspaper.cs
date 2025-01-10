using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem.Models;

public class Newspaper : LibraryItem
{
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }

    public Newspaper(int id, string title, string location, DateTime publishDate, string publisher) : base(id, title,
        location)
    {
        Publisher = publisher;
        PublishDate = publishDate;
    }

    public override void DisplayInfo()
    {
        Panel panel = new Panel(new Markup($"[bold]Newspaper:[/] [cyan]{Title}[/] published by [cyan]{Publisher}[/]") +
                              $"\n[bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}