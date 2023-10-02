using Common.Interfaces;

namespace Common.Classes;

public class Product : IItem
{
    public int? Id { get; private set; }
    public string Name { get; init; }

    public Product(int? id, string name) => (Id, Name) = (id, name);
    public Product(string name) : this(null, name) { }

    public void AssignId(int? id)
    {
        if (Id is null) Id = id;
    }
}

//public record Product1(int Id, string Name);