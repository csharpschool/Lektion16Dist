using Common.Classes;
using Common.Exceptions;
using Common.Interfaces;
using System.Linq.Expressions;

namespace Data.Services;

public class Data : IData
{
    public List<Product> Products { get; private set; }

    public Data()
    {
        Products = new List<Product>()
        {
            new Product(1, "TV"),
            new Product(2, "XBox")
        };
    }

    public List<T> Get<T>(List<T> list, Func<T, bool>? expression = null) where T : class
    {
        // expression: p => p.Id > 10

        if(expression is null) throw new DataNullException("Could not find a match.");

        var result = list.Where(expression).ToList();
        if(result.Count == 0) return list;

        return result;


        /*try
        {
            return list.Where(expression).ToList();
        }
        catch
        {
            throw new DataNullException("Could not find a match.");
        }*/

    }

    public void Add<T>(List<T> list, T item) where T : class, IItem
    {
        try
        {
            var newId = list.Count == 0 ? 1 : list.Max(l => l.Id) + 1;
            item.AssignId(newId);
            list.Add(item);
        }
        catch
        {
            throw new DataNullException("Could not add the item.");
        }
    }

    public void Remove<T>(List<T> list, T item) where T : class
    {
        try
        {
            list.Remove(item);
        }
        catch
        {
            throw new DataNullException("Could not add the item.");
        }
    }
}
