using System.ComponentModel.DataAnnotations;
namespace backend.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Order_id { get; set; } = String.Empty;
        public string Product_id { get; set; } = String.Empty;
        public int QTY { get; set; } = 0;
        public string Status { get; set; } = String.Empty;

    }
}