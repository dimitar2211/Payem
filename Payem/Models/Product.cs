namespace Payem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  // Полето за цена
        public string Description { get; set; }
    }
}
