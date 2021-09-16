using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; } 
        public string Name { get; set; } 
        public string Alias { get; set; }
        public string Description { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
