using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem.Models;

public class Magazine : LibraryItem
{
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public int IssueNumber { get; set; }

    public Magazine(int id, string title, string location, string publisher, DateTime publishDate, int issueNumber) :
        base(id, title, location)
    {
        Publisher = publisher;
        PublishDate = publishDate;
        IssueNumber = issueNumber;
    }

    public override void DisplayInfo()
    {
        Panel panel = new(
            new Markup($"[Bold]Magazine[/]: [cyan]{Title}[/] by [cyan]{Publisher}[/]" +
                       $"[Bold]Publish Date[/]: [yellow]{PublishDate}[/]" +
                       $"[Bold]Issue Number[/]: [green]{IssueNumber}[/]" +
                       $"[Bold]Location[/]: [blue]{Location}[/]"))
        {
            Border = BoxBorder.Rounded
            //BorderStyle = new Style(foreground: Color.Cyan)
        };
        
        AnsiConsole.Write(panel);
    }
}