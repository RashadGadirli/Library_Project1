using Library.Core.Interfaces;

namespace Library.Core.Entity;

public class Author : IEntity<int>
{
    public int ID { get; set; }
    private static int _id;
    public string Name { get; set; } = null!;
    public string? Surname { get; set; }
    public Author(string name, string? surname)
    {
        Name = name;
        Surname = surname;
        ID = _id++;
    }
    public override string ToString()
    {
        return $"ID:{ID} Name:{Name} Surname:{Surname}";
    }
}
