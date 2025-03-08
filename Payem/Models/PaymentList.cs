namespace Payem.Models
{
    public class PaymentList
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Името на списъка
        public decimal TotalAmount { get; set; }  // Общата сума, която трябва да бъде изплатена
        public virtual ICollection<Product> Products { get; set; }  // Свързаните продукти
    }
}
