using Library.Business.Abstracts;
using Library.Business.Exceptions;
using Library.Core.Entity;
using Library.Data1;
using System.Xml.Linq;


namespace Library.Business.Implementations;

public class BookService : IBookService
{
    Data data = new();
    
    private AuthorService _authorservice;
    private GenreService _genreservice;
    public BookService(AuthorService authorservice,GenreService genreservice)
    {
        
        _authorservice = authorservice;
        _genreservice = genreservice;
    }
    
    public void Create(string name, int count, List<int> AuthorID, List<int> GenreID)
    {

        if (Data.Books == null)
        {
            Data.Books = new List<Book>();
        }
        var IsExistname = Data.Books.Find(a => a.Name == name);


        if (IsExistname != null)
        {
            throw new AlreadyExistException("A book with this name already exists");
        }
        if (count <= 0)
        {
            throw new InvalidValue("Invalid value");
        }
        Book book = new(name, count, AuthorID, GenreID);
        book.AuthorId.AddRange(AuthorID);
        book.GenreId.AddRange(GenreID);
        Data.Books.Add(book);
    }
    

    public void Delete(Guid id)
    {
        var IsExistid = Data.Books.Find(b => b.ID == id);
        if (IsExistid == null)
        {
            throw new NotFoundException("A book with the id you" +
                "inserted to delete does not exist");
        }
        Data.Books.Remove(IsExistid);
        
            
    }

    public List<Book> GetAll()
    {
        if (Data.Books == null || Data.Books.Count == 0)
        {
            throw new ArgumentNullException("The list is empty. Try to create some books first");
        }
        
        return Data.Books;
        
    }

    public List<Author> GetAuthors(Guid id)
    {
        var IsExist = Data.Books.Find(b => b.ID == id);
        if (IsExist == null)
        {
            throw new NotFoundException("Book with this ID is Not Found");
        }
        List<Author> Target = new List<Author>();
        foreach (var item in IsExist.AuthorId)
        {
            var FindAuthors = Data.Authors.Find(a => a.ID == item);
            if (FindAuthors is Author)
            {
                Target.Add(FindAuthors);  
            }
            

        }
        return Target;
    }

    public Book GetById(Guid id)
    {
        if (Data.Books == null || Data.Books.Count == 0)
        {
            throw new ArgumentNullException("The list is empty. Try to create some books first");
        }
        var IsExistid = Data.Books.Find(b => b.ID == id);
        if (IsExistid == null)
        {
            throw new AlreadyExistException("A book with the id you" +
                "inserted to get does not exist");
        }
        return IsExistid;

    }

    public Book GetByName(string name)
    {
        if (Data.Books == null || Data.Books.Count == 0)
        {
            throw new ArgumentNullException("The list is empty. Try to create some books first");
        }
        var IsExistid = Data.Books.Find(b => b.Name == name);
        if (IsExistid == null)
        {
            throw new NotFoundException("A book with the name you" +
                "inserted to delete does not exist");
        }
        return IsExistid;
    }

    public int GetCount(Guid id)
    {
        if (Data.Books == null || Data.Books.Count == 0)
        {
            throw new ArgumentNullException("The list is empty. Try to create some books first");
        }
        var IsExistid = Data.Books.Find(b => b.ID == id);
        if (IsExistid == null)
        {
            throw new AlreadyExistException("A book with the id you" +
                "inserted to delete does not exist");
        }
        return IsExistid.Count;
    }

    public void UpdateName(Guid id, string name)
    {
        if (Data.Books == null || Data.Books.Count == 0)
        {
            throw new ArgumentNullException("The list is empty. Try to create some books first");
        }
        var IsExistid = Data.Books.Find(b => b.ID == id);
        if (IsExistid == null)
        {
            throw new AlreadyExistException("A book with the id you" +
                "inserted to update does not exist");
        }
        var IsExistName = Data.Books.Find(b => b.Name == name);
        if (IsExistName == null)
        {
            throw new AlreadyExistException("A book with the id you" +
                "inserted to update already exists");
        }
    }
    public Book GetBookbyName(string name)
    {
        if (Data.Books == null || Data.Books.Count == 0)
        {
            throw new ArgumentNullException("The list is empty. Try to create some books first");
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("The name cant be null");
        }
        var isExist = Data.Books.Find(b => b.Name == name);
        if (isExist == null)
        {
            throw new NotFoundException("The book you searched does not exist");
        }
        return isExist;
    }


}
