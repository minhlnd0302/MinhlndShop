using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Data.Repository;
using MinhlndShop.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhlndShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);
        IEnumerable<ProductCategory> AddRange(IEnumerable<ProductCategory> productCategories);

        ProductCategory Update(ProductCategory productCategory);

        void Delete(int id); 

        Task<IEnumerable<ProductCategory>> GetAll();

        Task<IEnumerable<ProductCategory>> GetAll(string keyword);

        Task<IEnumerable<ProductCategory>> GetAllByParentId(int parentId);

        Task<ProductCategory> GetById(int id);

        //void Save();
        Task SaveChange();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryRepository.Add(productCategory);
        }

        public IEnumerable<ProductCategory> AddRange(IEnumerable<ProductCategory> productCategories)
        {
            return _productCategoryRepository.AddRange(productCategories);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }
         

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _productCategoryRepository.GetAll();
        }

        public async Task<IEnumerable<ProductCategory>> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return await _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            return await _productCategoryRepository.GetAll();

        }

        public async Task<IEnumerable<ProductCategory>> GetAllByParentId(int parentId)
        {
            return await _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public async Task<ProductCategory> GetById(int id)
        {
            return await _productCategoryRepository.GetById(id);
        }

        public async Task SaveChange()
        {
            await _unitOfWork.CommitAsync();
        }

        public ProductCategory Update(ProductCategory productCategory)
        {
            return _productCategoryRepository.Update(productCategory);
        }

    }

}
