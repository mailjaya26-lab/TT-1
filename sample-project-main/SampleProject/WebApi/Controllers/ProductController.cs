using BusinessEntities;
using Core.Services.Products;
using Core.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Models.Products;
using WebApi.Models.Users;


namespace WebApi.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IDeleteProductService _deleteProductService;


        public ProductController(ICreateProductService createProductService, IGetProductService getProductService, IDeleteProductService deleteProductService, IUpdateProductService updateProductService)
        { 
            _createProductService = createProductService;
            _getProductService = getProductService;
            _deleteProductService = deleteProductService;
            _updateProductService = updateProductService;

        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {            
            var product = _createProductService.Create(productId, model.Name, model.Description, model.Category, model.Price,model.Quantity, model.IsActive);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/getbyid")]
        [HttpGet]
        public HttpResponseMessage GetProductById(Guid productId)
        {
            var product = _getProductService.GetProductById(productId);
            return Found(new ProductData(product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            var products = _getProductService.GetProductList()
                                       .ToList();
            return Found(products);
        }

        [Route("list/category")]
        [HttpGet]
        public HttpResponseMessage GetProductByCategory(string category)
        {
            var products = _getProductService.GetProductList()
                                .Where(pr=>pr.Category.ToLower() == category.ToLower())
                                       .Select(q => new ProductData(q))
                                       .ToList();
            return Found(products);
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProductById(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _updateProductService.Update(product, model.Name, model.Description, model.Category, model.Price, model.Quantity, model.CreatedAt, model.IsActive);
            return Found(new ProductData(product));
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            _deleteProductService.DeleteAllProducts();
            return Found();
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
            var product = _getProductService.GetProductById(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _deleteProductService.DeleteProduct(product);
            return Found();
        }
    }
}