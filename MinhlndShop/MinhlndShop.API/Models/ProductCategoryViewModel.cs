using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; } 
        [Required]
        public string Name { get; set; } 
        [Required]
        public string Alias { get; set; }
        public string Description { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }

        public DateTime? CreatedDate { set; get; }  
        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; } 
        public string UpdatedBy { set; get; }  
        public string MetaKeyword { set; get; } 
        public string MetaDescription { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập trạng thái")]
        public bool Status { set; get; }
    }
}
