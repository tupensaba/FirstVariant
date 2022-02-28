using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstVariant.Models
{
    public class OrderMaster
    {
        [Key]
        public long OrderMasterId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string OrderNumberId { get; set; }
        public int CustomerId { get; set; }
        public CustomersModel Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
