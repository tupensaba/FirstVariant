using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstVariant.Models
{
    public class CustomersModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string CustomerName { get; set; }
    }
}
