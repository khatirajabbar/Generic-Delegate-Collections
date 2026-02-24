namespace GenericDelegateCollections.Task1.Models;

public class Book : IEntity
{
    public string Name { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public bool IsDeleted { get; set; }
    public int Id { get; }
    private static int ID;

    public Book(string name, string author, int pageCount)
    {
        Id = ++ID;
        Name = name;
        Author = author;
        PageCount = pageCount;
        IsDeleted = false;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}, Author: {Author}, PageCount: {PageCount}");
    }
}