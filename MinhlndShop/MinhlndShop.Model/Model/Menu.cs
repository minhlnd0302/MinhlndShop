using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhlndShop.Model.Model
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string URL { get; set; }
        public int? DisplayOrder { get; set; }

        [Required] 
        public int GroupID { get; set; }

        [ForeignKey("GroupID")]
        public MenuGroup MenuGroup { get; set; }

        [MaxLength(10)]
        public string Target { get; set; } 
  
        public bool Status { get; set; }
    }
}
