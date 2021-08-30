using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhlndShop.Model.Model
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int OrderID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("OrderID")]
        public Order Order { set; get; }

        [ForeignKey("ProductID")]
        public Product Product { set; get; }
    }
}
