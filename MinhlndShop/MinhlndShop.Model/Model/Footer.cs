using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhlndShop.Model.Model
{
    [Table("Footers")]
    public class Footer
    {
        [Key] 
        [MaxLength(50)] 
        public string ID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
