using System.ComponentModel.DataAnnotations;
namespace backend.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public string Product_id { get; set; } = String.Empty;
        public int Inventory { get; set; } = 0;
    }
}