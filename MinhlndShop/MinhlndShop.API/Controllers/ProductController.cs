using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhlndShop.API.Infrastructure.Core;
using MinhlndShop.API.Infrastructure.Extensions;
using MinhlndShop.API.Models;
using MinhlndShop.Model.Model;
using MinhlndShop.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        #region Initialize
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper, IErrorService errorService) : base(errorService)
        {
            _productService = productService;
            _mapper = mapper;
        }
        #endregion

        #region api  

        // GET: api/<ProductCategoryController>
        [HttpGet]
        public async Task<ActionResult<PaginationSet<ProductViewModel>>> GetAll(string keyword, int page, int pageSize = 20)
        {
            var responseData = new List<ProductViewModel>();
            var paginationSet = new PaginationSet<ProductViewModel>();
            try
            {
                int totalRow = 0;
                var productCategories = await _productService.GetAll(keyword);

                totalRow = productCategories.Count();
                productCategories = productCategories.OrderByDescending(x => x.UpdatedDate).Skip(page * pageSize).Take(pageSize);
                //productCategories = productCategories.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);

                responseData = _mapper.Map<List<ProductViewModel>>(productCategories);

                paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex);
            }
            return Ok(paginationSet);
        }

        //GET: api/<ProductCategoryController>
        [HttpGet("getParentProduct")]
        public async Task<ActionResult<ProductViewModel>> GetAllParent()
        {
            var responseData = new List<ProductViewModel>();
            try
            {
                var productCategories = await _productService.GetAll();

                responseData = _mapper.Map<List<ProductViewModel>>(productCategories);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex);
            }
            return Ok(responseData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetById(int id)
        {
            var responseData = new ProductViewModel();
            try
            {
                var productCategories = await _productService.GetById(id);

                if (productCategories == null)
                {
                    return NotFound();
                }
                responseData = _mapper.Map<ProductViewModel>(productCategories);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex);
            }
            return Ok(responseData);
        }

        // POST api/<ProductCategoryController>
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Create(ProductViewModel ProductViewModel)
        {
            var responseData = new ProductViewModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var newProduct = new Product();

                newProduct.UpdateProduct(ProductViewModel);
                newProduct.CreatedDate = DateTime.Now;
                newProduct.UpdatedDate = DateTime.Now;

                newProduct = _productService.Add(newProduct);
                //await _productService.SaveChange();

                responseData = _mapper.Map<ProductViewModel>(newProduct);

            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex);
            }

            //return CreatedAtAction("ProductCategory", new { id = responseData.ID }, responseData);
            return Ok(CreatedAtAction("ProductCategory", responseData));
        }

        // PUT api/<ProductCategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductViewModel>> Update(ProductViewModel ProductViewModel)
        {
            var responseData = new ProductViewModel();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    var dbProduct = await _productService.GetById(ProductViewModel.ID);

                    dbProduct.UpdateProduct(ProductViewModel);
                    dbProduct.UpdatedDate = DateTime.Now;
                    _productService.Update(dbProduct);
                    await _productService.SaveChange();
                    //responseData = _mapper.Map<ProductViewModel>(response);
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return BadRequest(ex);
                }
            }
            return Ok();
        }


        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                { 
                    _productService.Delete(id);
                    await _productService.SaveChange();
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return BadRequest(ex.Message);
                }
            }
            return Ok();
        }

        [HttpDelete("deleteMulti")]
        public async Task<ActionResult> DeleteMulti(string listid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    List<int> productCategoryId = JsonConvert.DeserializeObject<List<int>>(listid);

                    foreach (int id in productCategoryId)
                    {
                        _productService.Delete(id);
                    }
                    await _productService.SaveChange();
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return BadRequest(ex);
                }
            }
            return Ok();
        }
        #endregion
    }

}
