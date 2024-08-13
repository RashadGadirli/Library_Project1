using Library.Core.Entity;

namespace Library.Business.Abstracts;

public interface IGenreService
{
    void Create(string name);
    void Delete(int id);
    Genre GetById(int id);
    
    List<Genre> GetAll();
    List<Book> GetByGenres(string name);
    void UpdateGenre(int id, string name);
}
