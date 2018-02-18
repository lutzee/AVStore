namespace AVStore.Domain.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int DetailId { get; set; }

        public Detail Detail { get; set; }
    }
}