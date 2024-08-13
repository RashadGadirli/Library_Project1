using Library.Core.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library.Core.Entity;

public class Genre : IEntity<int>
{
    private static int _id;
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public Genre(string name)
    {
        Name = name;
        ID = _id++;
    }
    public override string ToString()
    {
        return $"ID:{ID} Name:{Name} ";
    }
}
