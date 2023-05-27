using System.ComponentModel.DataAnnotations;
namespace backend.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Product_id { get; set; } = String.Empty;
        public string Product_Name { get; set; } = String.Empty;
        public int Price { get; set; } = 0;
        /*public Stock Stock { get; set; }*/
    
    }
}