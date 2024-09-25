namespace CQRS_MinimalAPI.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}