using System.ComponentModel.DataAnnotations;

namespace FirstVariant.Models
{
    public class OrderDetails
    {   
        [Key]
        public int OrderDetailId { get; set; }

        public long OrderMasterId { get; set; }

        public int GoodItemId { get; set; }
        public GoodsModel GoodItem { get; set; }

        public int Quantity { get; set; }
    }
}
