using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicesDemo.Models
{
    public class CategoryDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
