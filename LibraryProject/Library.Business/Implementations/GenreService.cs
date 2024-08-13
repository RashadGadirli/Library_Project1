using Library.Business.Abstracts;
using Library.Business.Exceptions;
using Library.Core.Entity;
using Library.Data1;

namespace Library.Business.Implementations;

public class GenreService : IGenreService
{
    public GenreService()
    {
        Data.Genres = new List<Genre>();
    }
    public void Create(string name)
    {
        Data Genres;
        var IsExistname = Data.Genres.Find(a => a.Name == name);
        
        if (IsExistname != null)
        {
            throw new AlreadyExistException("A genre with this name already exists");
        }
        Genre genre = new(name);
        Data.Genres.Add(genre);
    }

    public void Delete(int id)
    {
        var IsExistname = Data.Genres.Find(g => g.ID == id);
        if (IsExistname == null)
        {
            throw new NotFoundException("A genre with the id you" +
                "inserted to delete does not exist");
        }
        Data.Genres.Remove(IsExistname);
    }

    public List<Genre> GetAll()
    {
        if (Data.Genres.Count==0)
        {
            throw new ArgumentNullException("There are no created genres"); 
        }

        return Data.Genres;
    }

    public List<Book> GetByGenres(string name)
    {
        var IsExistname = Data.Genres.Find(a => a.Name == name);
        if (IsExistname != null)
        {
            throw new NotFoundException("A Genre with this name already exists");
        }

        var IsExistGenre = Data.Books.FindAll(b => b.GenreId.Contains(IsExistname.ID));
        return IsExistGenre;
    }

    public Genre GetById(int id)
    {
        if (Data.Genres.Count == 0)
        {
            throw new ListNullException("There are no created genres");
        }
        var IsExist = Data.Genres.Find(a => a.ID == id);
        if (IsExist == null)
        {
            throw new NotFoundException("A genre with this ID does not exist");
        }
        return IsExist;
    }

    public void UpdateGenre(int id, string name)
    {
        if (Data.Genres.Count == 0)
        {
            throw new ListNullException("There are no created genres");
        }
        var IsExist = Data.Genres.Find(a => a.ID == id);
        if (IsExist == null)
        {
            throw new NotFoundException("A genre with this ID does not exist");
        }
        IsExist.Name = name;
    }
    Genre GetByName(string name)
    {
        if (Data.Genres.Count == 0)
        {
            throw new ListNullException("There are no created genres");
        }
        var isExist = Data.Genres.Find(g => g.Name == name);
        if (isExist == null)
        {
            throw new NotFoundException("A Genre with this name does not exist");
        }
        return isExist;
           
    }

}
