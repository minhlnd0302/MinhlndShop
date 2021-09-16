using MinhlndShop.Model.Abstract;

namespace MinhlndShop.API.Models
{
    public class PostViewModel : Auditable
    {
        public int ID { get; set; } 
        public string Name { get; set; } 
        public string Alias { get; set; } 
        public int CategoryID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; } 
        public PostCategoryViewModel PostCategory { get; set; }
    }
}
