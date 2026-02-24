using Utils.Enums;

namespace GenericDelegateCollections.Task1.Models;

public class User : IEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public int Id { get; }
    private static int ID;

    public User(string username, string email, Role role)
    {
        Id = ++ID;
        Username = username;
        Email = email;
        Role = role;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Username: {Username}, Email: {Email}, Role: {this.Role}");
    }
}