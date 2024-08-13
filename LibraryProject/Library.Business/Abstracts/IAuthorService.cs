using Library.Core.Entity;

namespace Library.Business.Abstracts;

public interface IAuthorService
{
    void Create(string name, string? surname);
    void Delete(int id);
    Author GetById(int id);
    List<Author> GetAll();
    List<Book> GetBooksByAuthors(string name);
    Author GetByName(string name);
    void UpdateAuthor(int id, string? name, string? surname, int choice);
}
