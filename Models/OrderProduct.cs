namespace backend.Models
{
    public class OrderProduct
    {       
        public int Id { get; set; }
        public string Order_id { get; set; } = String.Empty;
        public string Product_id { get; set; } = String.Empty;
        public int QTY { get; set; } = 0;
        public string Status { get; set; } = String.Empty;
        public Product Product { get; set; }
    }
}