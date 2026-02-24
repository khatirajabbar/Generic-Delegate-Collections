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
            Console.WriteLine("please enter your role (Admin, Member):");
            string roleInput = Console.ReadLine();
            if (Enum.TryParse(roleInput, true, out role) && Enum.IsDefined(typeof(Role), role))
            {
                break;
            }

            Console.WriteLine("Invalid role. Please enter 'Admin' or 'User':");
        }

        User user = new User(username, email, role);
        Console.WriteLine($"Welcome, {user.Username}! You have {user.Role} access.");
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Add new book to library");
        Console.WriteLine("2. View book details by ID");
        Console.WriteLine("3. View all books in library");
        Console.WriteLine("4. Delete a book by ID");
        Console.WriteLine("5. Edit a book name by ID");
        Console.WriteLine("6. Filter books by page count");
        Console.WriteLine("0. Exit");
        while (true)
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (user.Role == Role.Admin)
                    {
                        Console.WriteLine("Enter book name:");
                        string bookName = Console.ReadLine();
                        Console.WriteLine("Enter book author:");
                        string bookAuthor = Console.ReadLine();
                        Console.WriteLine("Enter book page count:");
                        int pageCount;
                        while (!int.TryParse(Console.ReadLine(), out pageCount) || pageCount <= 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a positive integer for page count:");
                        }

                        Book newBook = new Book(bookName, bookAuthor, pageCount);
                        try
                        {
                            ChapterHouse.AddBook(newBook);
                            Console.WriteLine("Book added successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have permission to add books.");
                    }

                    break;
                case "2":
                    Console.WriteLine("Enter book ID:");
                    int bookId = int.Parse(Console.ReadLine());
                    Book newBook1 = ChapterHouse.GetBookById(bookId);
                    newBook1.ShowInfo();
                    break;
                case "3":
                    List<Book> allBooks = ChapterHouse.GetAllBooks();
                    foreach (var item in allBooks)
                    {
                        item.ShowInfo();
                    }

                    break;
                case "4":
                    if (user.Role == Role.Admin)
                    {
                        Console.WriteLine("Enter book ID to delete:");
                        int deleteBookId = int.Parse(Console.ReadLine());
                        try
                        {
                            ChapterHouse.DeleteBookById(deleteBookId);
                            Console.WriteLine("Book deleted successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have permission to delete books.");
                    }
                    break;
                case "5":
                    if (user.Role == Role.Admin)
                    {
                        Console.WriteLine("Enter book ID to edit:");
                        int editBookId = int.Parse(Console.ReadLine());
                        try
                        {
                            ChapterHouse.EditBookName(editBookId);
                            Console.WriteLine("Book name edited successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have permission to edit books.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Enter minimum page count:");
                    int minPageCount;
                    while (!int.TryParse(Console.ReadLine(), out minPageCount) || minPageCount < 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a non-negative integer for minimum page count:");
                    }

                    Console.WriteLine("Enter maximum page count:");
                    int maxPageCount;
                    while (!int.TryParse(Console.ReadLine(), out maxPageCount) || maxPageCount < minPageCount)
                    {
                        Console.WriteLine(
                            $"Invalid input. Please enter an integer greater than or equal to {minPageCount} for maximum page count:");
                    }

                    List<Book> filteredBooks = ChapterHouse.FilterByPageCount(minPageCount, maxPageCount);
                    if (filteredBooks.Count > 0)
                    {
                        Console.WriteLine("Books matching the page count criteria:");
                        foreach (var item in filteredBooks)
                        {
                            item.ShowInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No books found matching the page count criteria.");
                    }

                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}