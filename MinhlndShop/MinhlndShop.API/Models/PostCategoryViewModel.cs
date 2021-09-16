using MinhlndShop.Model.Abstract;
using System.Collections.Generic;

namespace MinhlndShop.API.Models
{
    public class PostCategoryViewModel : Auditable
    {
        public int ID { get; set; }
         
        public string Name { get; set; } 
        public string Alias { get; set; } 
        public string Description { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; } 
        public string Image { get; set; }
        public bool HomeFlag { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
