using CourseZone.DataAccsess.Utils;
using CourseZone.Service.Dtos.Order;
using CourseZone.Service.Interfaces.Orders;
using CourseZone.Service.Validators.Dtos.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseZone.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IOrderService _service;
    private readonly int maxPageSize = 30;

    public OrderController(IOrderService orderService)
    {
        this._service = orderService;
    }

    [HttpPost]
    //[AllowAnonymous]
    public async Task<IActionResult> CreateAsync([FromForm] OrderCreateDto dto)
    {
        var createValidetor = new OrderCreateValidator();
        var result = createValidetor.Validate(dto);

        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet]
    //[AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));
}
