using Common.Classes;

namespace Common.Interfaces;

public interface IData
{
    List<Product> Products { get; }
    List<T> Get<T>(List<T> list, Func<T, bool>? expression) where T : class;
    void Add<T>(List<T> list, T item) where T : class, IItem;
    void Remove<T>(List<T> list, T item) where T : class;
}
