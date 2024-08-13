namespace Library.Business.Abstracts;

using Library.Business.Implementations;
using Library.Core.Entity;

public interface IBookService
{
    void Create(string name, int count, List<int> AuthorID, List<int> GenreID);
    void UpdateName(Guid id, string name);
    void Delete(Guid id);
    List<Book> GetAll();
    Book GetById(Guid id);
    Book GetByName(string name);
    int GetCount(Guid id);
    List<Author> GetAuthors(Guid id);
    Book GetBookbyName(string name);



}
