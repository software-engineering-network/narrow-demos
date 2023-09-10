using FluentAssertions;

namespace Mocking.Spec;

public class WhenDeactivatingProduct
{
    #region Requirements

    [Fact]
    public void ThenStoredProductIsDeactivated()
    {
        var sku = "ABC123";
        var mockRepository = new MockProductRepository();
        var catalogService = new CatalogService(mockRepository);
        var product = new Product(sku, "Shoes");
        mockRepository.Create(product);

        catalogService.Deactivate(sku);

        product = mockRepository.Find(sku);
        product.IsDeactivated.Should().BeTrue();
    }

    #endregion
}

public record Product(string Sku, string Name, bool IsDeactivated = false)
{
    public Product Deactivate() => this with { IsDeactivated = true };
}

public class CatalogService
{
    private readonly IProductRepository _repository;

    public CatalogService(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Deactivate(string sku)
    {
        var product = _repository.Find(sku);

        _repository.Update(product.Deactivate());
    }
}

public interface IProductRepository
{
    void Create(Product product);
    Product Find(string sku);
    Product Update(Product product);
}

public class MockProductRepository : IProductRepository
{
    private readonly Dictionary<string, Product> _products = new();

    public void Create(Product product) => _products.Add(product.Sku, product);

    public Product Find(string sku) => _products[sku];

    public Product Update(Product product) => _products[product.Sku] = product;
}
