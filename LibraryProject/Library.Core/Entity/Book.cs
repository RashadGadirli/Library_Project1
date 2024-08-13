using Library.Core.Interfaces;

namespace Library.Core.Entity;

public class Book:IEntity<Guid>
{
    public Guid ID { get; set; }
    public string Name { get; set; } = null!;
    public List<int> AuthorId { get; set; }
    public List<int> GenreId { get; set; }
    public DateTime Date { get; set; }
    public int Count { get; set; }

    public Book(string name,int count,List<int> authorId,List<int> genreID)
    {
        AuthorId = authorId;
        GenreId = genreID;
        Count = count;
        ID =Guid.NewGuid();
        Name = name;
    }
    public override string ToString()
    {
        return $"ID:{ID} Name:{Name} DateOfOrigin:{Date} count:{Count}";
    }
}
