using MinhlndShop.Common;
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
    public interface IProductService
    {
        Product Add(Product Product);
        IEnumerable<Product> AddRange(IEnumerable<Product> productCategories);

        void Update(Product Product);

        void Delete(int id);

        Task<IEnumerable<Product>> GetAll();

        Task<IEnumerable<Product>> GetAll(string keyword);

        //Task<IEnumerable<Product>> GetAllByParentId(int parentId);

        Task<Product> GetById(int id);

        //void Save();
        Task SaveChange();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository ProductRepository, IUnitOfWork unitOfWork, ITagRepository tagRepository, IProductTagRepository productTagRepository)
        {
            this._productRepository = ProductRepository;
            this._unitOfWork = unitOfWork;
            this._tagRepository = tagRepository;
            this._productTagRepository = productTagRepository;
        }

        public Product Add(Product Product)
        {
            var product = _productRepository.Add(Product);
            _unitOfWork.CommitAsync();

            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(',');

                for(int i = 0; i<tags.Length; i++)
                {
                    string tagId = StringHelper.ToUnsignString(tags[i]);

                    if( _tagRepository.Count(x=>x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag(); 
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.PostTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag); 
                }
                _unitOfWork.CommitAsync();
            }
            return product;
        }

        public IEnumerable<Product> AddRange(IEnumerable<Product> productCategories)
        {
            return _productRepository.AddRange(productCategories);
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }


        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return await _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            return await _productRepository.GetAll();

        }

        //public async Task<IEnumerable<Product>> GetAllByParentId(int parentId)
        //{
        //    return await _productRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        //}

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task SaveChange()
        {
            await _unitOfWork.CommitAsync();
        }

        public async void Update(Product Product)
        { 
            _productRepository.Update(Product); 

            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(',');

                for (int i = 0; i < tags.Length; i++)
                {
                    string tagId = StringHelper.ToUnsignString(tags[i]);

                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.PostTag;
                    }

                    IEnumerable<ProductTag> productTags = await _productTagRepository.GetMulti(x => x.ProductID == Product.ID);

                    if (productTags.Count() > 0)
                    {
                        productTags.ToList().ForEach((pTag) =>
                        {
                            _productTagRepository.Remove(pTag);
                        });
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
                //_unitOfWork.CommitAsync();
            }
        }

    }
}
