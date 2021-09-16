using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.Models
{
    public class ProductTagViewModel
    {
        public int ProductID { get; set; } 
        public string TagID { get; set; } 
        public ProductViewModel Product { get; set; } 
        public TagViewModel Tag { get; set; }
    }
}
