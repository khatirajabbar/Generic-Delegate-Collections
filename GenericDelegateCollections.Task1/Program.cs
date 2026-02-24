using GenericDelegateCollections.Task1.Models;
using Utils.Enums;

namespace GenericDelegateCollections.Task1;

class Program
{
    static void Main(string[] args)
    {
        Library ChapterHouse = new Library(10);
        Book book1 = new Book("The Name of the Wind", "Patrick Rothfuss", 662);
        Book book2 = new Book("The Wise Man's Fear", "Patrick Rothfuss", 994);
        Book book3 = new Book("The Doors of Stone", "Patrick Rothfuss", 1200);
        ChapterHouse.AddBook(book1);
        ChapterHouse.AddBook(book2);
        ChapterHouse.AddBook(book3);
        Console.WriteLine("welcome to the library, please enter your username:");
        string username = Console.ReadLine();
        Console.WriteLine("please enter your email:");
        string email = Console.ReadLine();
        Role role;
        while (true)
        {
            Console.WriteLine("please enter your role (Admin, User):");
             string roleInput = Console.ReadLine();
             if (Enum.TryParse(roleInput, true, out role) && Enum.IsDefined(typeof(Role), role))
             {
                 break;
             }
             Console.WriteLine("Invalid role. Please enter 'Admin' or 'User':");
        }
        User user = new User(username, email, role);
        Console.WriteLine($"Welcome, {user.Username}! You have {user.Role} access.");
        
    }
}