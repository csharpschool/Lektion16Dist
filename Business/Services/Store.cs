using Common.Classes;
using Common.Exceptions;
using Common.Interfaces;

namespace Business.Services;

public class Store // Affärslagret
{
    IData _data;
    public string Error { get; private set; } = string.Empty;

    public Store(IData data) => _data = data;
    
    public void RemoveProduct(Product p)
    {
        _data.Remove(_data.Products, p);
    }

    public void AddProduct(string name)
    {
        _data.Add(_data.Products, new Product(name));
    }

    public List<Product> GetProducts(Func<Product, bool>? expression = null)
    {
        try
        {
            return _data.Get(_data.Products, expression);
        }
        catch (DataNullException ex)
        {
            Error = ex.Message.ToString();
            return new List<Product>();
        }

        /*return new List<Product>()
        {
            new Product(1, "Product 1"),
            new Product(2, "Product 2")
        };*/
    }
}
