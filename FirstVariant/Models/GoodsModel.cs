using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstVariant.Models
{
    public class GoodsModel
    {
        [Key]
        public int GoodItemId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string GoodItemName { get; set; }
        public decimal Price { get; set; }

    }
}
