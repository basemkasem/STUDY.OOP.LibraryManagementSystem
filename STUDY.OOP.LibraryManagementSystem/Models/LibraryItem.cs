namespace STUDY.OOP.LibraryManagementSystem.Models;

public abstract class LibraryItem
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Location { get; set; }

    protected LibraryItem(int id, string title, string location)
    {
        Id = id;
        Title = title;
        Location = location;
    }
    
    public abstract void DisplayInfo();
}