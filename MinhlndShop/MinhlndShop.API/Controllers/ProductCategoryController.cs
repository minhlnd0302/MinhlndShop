using AutoMapper;
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
    public class ProductCategoryController : ApiControllerBase
    {
        #region Initialize
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper; 
        public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper, IErrorService errorService) : base(errorService)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }
        #endregion

        #region api  

        // GET: api/<ProductCategoryController>
        [HttpGet]
        public async Task<ActionResult<PaginationSet<ProductCategoryViewModel>>> GetAll(string keyword ,int page, int pageSize = 20)
        {
            var responseData = new List<ProductCategoryViewModel>();
            var paginationSet = new PaginationSet<ProductCategoryViewModel>();
            try
            {
                int totalRow = 0;
                var productCategories = await _productCategoryService.GetAll(keyword);

                totalRow = productCategories.Count();
                productCategories = productCategories.OrderByDescending(x => x.UpdatedDate).Skip(page * pageSize).Take(pageSize);
                //productCategories = productCategories.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);

                responseData = _mapper.Map<List<ProductCategoryViewModel>>(productCategories);

                paginationSet = new PaginationSet<ProductCategoryViewModel>()
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
        public async Task<ActionResult<ProductCategoryViewModel>> GetAllParent()
        {
            var responseData = new List<ProductCategoryViewModel>();
            try
            {
                var productCategories = await _productCategoryService.GetAll();

                responseData = _mapper.Map<List<ProductCategoryViewModel>>(productCategories);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex); 
            }
            return Ok(responseData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryViewModel>> GetById(int id)
        {
            var responseData = new ProductCategoryViewModel();
            try
            {
                var productCategories = await _productCategoryService.GetById(id); 

                if(productCategories == null)
                {
                    return NotFound();
                } 
                responseData = _mapper.Map<ProductCategoryViewModel>(productCategories);
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
        public async Task<ActionResult<ProductCategoryViewModel>> Create(ProductCategoryViewModel productCategoryViewModel)
        {
            var responseData = new ProductCategoryViewModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                } 
                var newProductCategory = new ProductCategory();

                newProductCategory.UpdateProductCategory(productCategoryViewModel);
                newProductCategory.CreatedDate = DateTime.Now;
                newProductCategory.UpdatedDate = DateTime.Now;

                newProductCategory = _productCategoryService.Add(newProductCategory);
                await _productCategoryService.SaveChange();

                responseData = _mapper.Map<ProductCategoryViewModel>(newProductCategory);

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
        public async Task<ActionResult<ProductCategoryViewModel>> Update(ProductCategoryViewModel productCategoryViewModel)
        {
            var responseData = new ProductCategoryViewModel();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    var dbProductCategory = await _productCategoryService.GetById(productCategoryViewModel.ID);

                    dbProductCategory.UpdateProductCategory(productCategoryViewModel);
                    dbProductCategory.UpdatedDate = DateTime.Now;
                    var response = _productCategoryService.Update(dbProductCategory);
                    await _productCategoryService.SaveChange();
                    responseData = _mapper.Map<ProductCategoryViewModel>(response);
                }
                catch(Exception ex)
                {
                    LogError(ex);
                    return BadRequest(ex); 
                }
            }  
            return Ok(responseData);
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
                    id = 900;
                    _productCategoryService.Delete(id);
                    await _productCategoryService.SaveChange();
                }
                catch(Exception ex)
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
                        _productCategoryService.Delete(id);
                    } 
                    await _productCategoryService.SaveChange();
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
