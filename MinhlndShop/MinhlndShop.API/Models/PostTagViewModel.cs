namespace MinhlndShop.API.Models
{
    public class PostTagViewModel
    {
        public int PostID { set; get; } 
        public string TagID { set; get; } 
        public PostViewModel Post { set; get; } 
        public TagViewModel Tag { set; get; }
    }
}
