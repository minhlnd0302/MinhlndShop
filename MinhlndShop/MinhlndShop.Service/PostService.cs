using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Data.Repository;
using MinhlndShop.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhlndShop.Service
{
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        Task<IEnumerable<Post>> GetAll();
        //Task<IEnumerable<Post>> getAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Post> getAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        Task<Post> GetById(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        Task SaveChange();

    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {

            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Remove(id);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> getAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status == true && x.CategoryID == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        //public Task<IEnumerable<Post>> getAllPaging(int page, int pageSize, out int totalRow)
        //{
        //    return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        //}

        public async Task<Post> GetById(int id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task SaveChange()
        {
            await _unitOfWork.CommitAsync();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        //public void Add(Post post)
        //{
        //    _postRepository.Add(post);
        //}

        //public void Delete(int id)
        //{
        //    _postRepository.Remove(id);
        //}

        //public IEnumerable<Post> GetAll()
        //{
        //    return _postRepository.GetAll(new string[] { "PostCategory" });
        //}

        //public IEnumerable<Post> getAllByCategoryPaging(int categoryId ,int page, int pageSize, out int totalRow)
        //{
        //    return _postRepository.GetMultiPaging(x => x.Status == true && x.CategoryID == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
        //}

        //public IEnumerable<Post> GetAllByTagPaging(string tag ,int page, int pageSize, out int totalRow)
        //{
        //    // TODO : Select all post by tag
        //    return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        //}

        //public IEnumerable<Post> getAllPaging(int page, int pageSize, out int totalRow)
        //{
        //    return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        //}

        //public Post GetById(int id)
        //{
        //    return _postRepository.GetById(id);
        //}

        //public void SaveChange()
        //{
        //    _unitOfWork.Commit();
        //}

        //public void Update(Post post)
        //{
        //    _postRepository.Update(post);
        //}
    }
}
