using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Data.Repository;
using MinhlndShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int id);

        Task<IEnumerable<PostCategory>> GetAll();

        Task<IEnumerable<PostCategory>> GetAllByParentId(int parentId);

        Task<PostCategory> GetById(int id);

        //void Save();
        Task SaveChange();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(PostCategory postCategory)
        {
            _postCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Remove(id);
        }

        public async Task<IEnumerable<PostCategory>> GetAll()
        {
            return await _postCategoryRepository.GetAll();
        }

        public async Task<IEnumerable<PostCategory>> GetAllByParentId(int parentId)
        {
            return await _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public async Task<PostCategory> GetById(int id)
        {
            return await _postCategoryRepository.GetById(id);
        }

        public async Task SaveChange()
        {
            await _unitOfWork.CommitAsync();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}
