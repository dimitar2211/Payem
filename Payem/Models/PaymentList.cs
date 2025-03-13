namespace Payem.Models
{
    public class PaymentList
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public decimal TotalAmount { get; set; }  
        public virtual ICollection<Product> Products { get; set; }  
    }
}
