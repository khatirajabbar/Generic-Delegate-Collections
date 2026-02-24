using Utils.Exceptions;

namespace GenericDelegateCollections.Task1.Models;

public class Library : IEntity
{
    public long BookLimit { get; set; }
    public int Id { get; }
    private static int ID;
    private List<Book> books = new List<Book>();


    public Library(long bookLimit)
    {
        Id = ++ID;
        BookLimit = bookLimit;
    }

    public void AddBook(Book book)
    {
        foreach (var item in books)
        {
            if (item.IsDeleted == false && item.Name == book.Name)
            {
                throw new AlreadyExistsException("This book already exists in the library.");
            }
        }

        if (books.Count + 1 > BookLimit)
        {
            throw new CapacityLimitException("Book limit exceeded.");
        }

        books.Add(book);
    }

    public Book GetBookById(int? id)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id cannot be null.");
        }

        foreach (var item in books)
        {
            if (item.Id == id && item.IsDeleted == false)
            {
                return item;
            }
        }

        throw new NotFoundException($"There's no book with this Id in the library.");
    }

    public List<Book> GetAllBooks()
    {
        List<Book> NewBooks = new List<Book>();
        foreach (var item in books)
        {
            if (item.IsDeleted == false)
            {
                NewBooks.Add(item);
            }
        }

        return NewBooks;
    }

    public void DeleteBookById(int? id)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id cannot be null.");
        }

        foreach (var item in books)
        {
            if (item.Id == id && item.IsDeleted == false)
            {
                item.IsDeleted = true;
                return;
            }
        }

        throw new NotFoundException("Book not found.");
    }

    public void EditBookName(int? id)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id cannot be null.");
        }

        foreach (var item in books)
        {
            if (item.Id == id && item.IsDeleted == false)
            {
                Console.WriteLine("Enter new name: ");
                string newName = Console.ReadLine();
                item.Name = newName;
                return;
            }
        }

        throw new NotFoundException("Book not found.");
    }

    public List<Book> FilterByPageCount(int minPageCount, int maxPageCount)
    {
        List<Book> filteredBooks = new List<Book>();
        foreach (var item in books)
        {
            if (item.PageCount >= minPageCount && item.PageCount <= maxPageCount && item.IsDeleted == false)
            {
                filteredBooks.Add(item);
            }
        }

        return filteredBooks;
    }
}