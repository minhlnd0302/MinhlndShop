using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; } 
        public string Name { get; set; } 
        public string Alias { get; set; } 
        public int CategoryID { get; set; }
        public string Image { get; set; }
        public string MoreImage { get; set; } 
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; } 
        public int? Warranty { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; } 
        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}
