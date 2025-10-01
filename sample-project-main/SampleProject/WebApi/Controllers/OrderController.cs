using Core.Services.Orders;
using Core.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Models.Orders;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IDeleteOrderService _deleteOrderService;


        public OrderController(ICreateOrderService createOrderService, IGetOrderService getOrderService, IDeleteOrderService deleteOrderService)
        {
            _createOrderService = createOrderService;
            _getOrderService = getOrderService;
            _deleteOrderService = deleteOrderService;

        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
           
            var order = _createOrderService.Create(orderId, model.UserId, model.ProductsOrdered);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/getbyid")]
        [HttpGet]
        public HttpResponseMessage GetOrderById(Guid orderId)
        {
            var order = _getOrderService.GetOrderById(orderId);
            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders()
        {
            var products = _getOrderService.GetOrderList()
                                       .ToList();
            return Found(products);
        }

        [Route("list/user")]
        [HttpGet]
        public HttpResponseMessage GetOrderByUser(Guid userId)
        {
            var orders = _getOrderService.GetOrderList()
                                .Where(pr => pr.UserId == userId)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(orders);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAllOrders();
            return Found();
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrderById(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.DeleteOrder(order);
            return Found();
        }
    }
}
