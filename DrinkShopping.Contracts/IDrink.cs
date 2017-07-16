namespace DrinkShopping.Contracts
{
    public interface IDrink
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}