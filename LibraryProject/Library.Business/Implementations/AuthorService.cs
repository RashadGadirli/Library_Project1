using Library.Business.Abstracts;
using Library.Business.Exceptions;
using Library.Core.Entity;
using Library.Data1;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library.Business.Implementations;

public class AuthorService : IAuthorService
{
    public AuthorService()
    {
        Data.Authors = new List<Author>();
    }

    public void Create(string name,string surname)
    {
        Data Authors;
        var IsExistname = Data.Authors.Find(a => a.Name == name);
        var IsExistsurname = Data.Authors.Find(a => a.Surname == surname);
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid name");
        }
        if (IsExistname != null && IsExistsurname!=null)
        {
            throw new AlreadyExistException("An Author with this name already exists");
        }
        Author author = new(name,surname);
        Data.Authors.Add(author);
    }

    public void Delete(int id)
    {
        if (Data.Authors.Count == 0)
        {
            throw new ListNullException("There are no authors created. Try to create one first");
        }
        var IsExistname = Data.Authors.Find(a => a.ID == id);
        if (IsExistname == null)
        {
            throw new NotFoundException("An author with the name you"+
                "inserted to delete does not exist");
        }
        Data.Authors.Remove(IsExistname);
    }

    public List<Author> GetAll()
    {
        if (Data.Authors.Count == 0)
        {
            throw new ListNullException("There are no authors created.Try to create one first.");
        }
        return Data.Authors;
        
    }
    public Author GetByName(string name)
    {
        if (Data.Authors.Count == 0)
        {
            throw new ListNullException("There are no authors created.Try to create one first");
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name cant be null");
        }
        var isExist = Data.Authors.Find(a => a.Name == name);
        if (isExist == null)
        {
            throw new NotFoundException("An author with this name does not exist");
        }
        return isExist;
    }
    public List<Book> GetBooksByAuthors(string name)
    {
        if (Data.Authors.Count == 0)
        {
            throw new ListNullException("There are no authors created.Try to create one first");
        }
        var IsExistname = Data.Authors.Find(a => a.Name == name);
        if (IsExistname != null)
        {
            throw new NotFoundException("An Author with this name already exists");
        }
        
        var IsExistAuthor = Data.Books.FindAll(b => b.AuthorId.Contains(IsExistname.ID));
        return IsExistAuthor;
    }
    

    public Author GetById(int id)
    {
        if (Data.Authors.Count == 0)
        {
            throw new ListNullException("There are no authors created.Try to create one first");
        }
        var IsExist = Data.Authors.Find(a => a.ID == id);
        if (IsExist == null)
        {
            throw new NotFoundException("An author with this ID does not exist");
        }
        return IsExist;
    }

    public void UpdateAuthor(int id, string? name, string? surname,int choice)
    {
        if (Data.Authors.Count == 0)
        {
            throw new ListNullException("There are no authors created.Try to create one first");
        }
        var IsExist = Data.Authors.Find(a => a.ID == id);
        switch (choice) 
        {
            case 1:
                {
                    
                    if (string.IsNullOrEmpty(name))
                    {
                        throw new ArgumentNullException("The argument given is null");
                    }
                    if (IsExist == null)
                    {
                        throw new NotFoundException("An author with this ID does not exist");
                    }
                    IsExist.Name = name;
                    break;
                }
            case 2:
                {

                    if (string.IsNullOrEmpty(surname))
                    {
                        throw new ArgumentNullException("The argument given is null");
                    }
                    if (IsExist == null)
                    {
                        throw new NotFoundException("An author with this ID does not exist");
                    }
                    IsExist.Surname = surname;
                    break;
                }
            case 3:
                {
                    if (string.IsNullOrEmpty(surname))
                    {
                        throw new ArgumentNullException("The argument given is null");
                    }
                    if (IsExist == null)
                    {
                        throw new NotFoundException("An author with this ID does not exist");
                    }
                    IsExist.Surname = surname;
                    if (string.IsNullOrEmpty(name))
                    {
                        throw new ArgumentNullException("The argument given is null");
                    }
                    if (IsExist == null)
                    {
                        throw new NotFoundException("An author with this ID does not exist");
                    }
                    IsExist.Name = name;
                    break;
                }


        }

       
        
    }
}
