using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicesDemo.Models
{
    public class ProductDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
    }
}
