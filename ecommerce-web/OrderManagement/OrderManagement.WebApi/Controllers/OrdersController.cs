using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models.InputModels;
using OrderManagement.Services.Interfaces;

namespace OrderManagement.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _orderService;

    public OrdersController(IOrdersService orderService)
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
    public async Task<IActionResult> CreateOrder([FromBody] OrderInputModel order)
    {
        var result = await _orderService.CreateOrder(order);
        if (!result) return BadRequest();
        return Ok(order);
    }

    [HttpGet("users/{username}")]
    public IActionResult getOrderForUser(string username)
    {
        var orders = _orderService.getOrderForUser(username);
        return Ok(orders);
    }

}