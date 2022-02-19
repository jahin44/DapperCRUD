using System.ComponentModel.DataAnnotations;

namespace DapperCRUD.Api
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
