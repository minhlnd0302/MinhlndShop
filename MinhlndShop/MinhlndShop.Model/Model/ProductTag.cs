using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhlndShop.Model.Model
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key] 
        public int ProductID { get; set; }
        [Key]
        [Column(TypeName = "varchar")]
        public string TagID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }
    }
}
