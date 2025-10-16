using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models.InputModels;
using OrderManagement.Services.Interfaces;

namespace OrderManagement.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult getAllOrders()
    {
        var orders = _orderService.getAllOrders();
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public IActionResult getOrderById(int id)
    {
        var order = _orderService.getOrderById(id);
        return Ok(order);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderInputModel order)
    {
        return Ok(order);
    }

    [HttpGet("orders/users/{username:string}")]
    public IActionResult getOrderForUser(string username)
    {
        var orders = _orderService.getOrderForUser(username);
        return Ok(orders);
    }


}