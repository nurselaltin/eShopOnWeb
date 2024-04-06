using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;


namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{

    private readonly HttpService _httpService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(
        HttpService httpService,
        ILogger<OrderService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching order from API.");

        var itemListTask = _httpService.HttpGet<PagedOrderResponse>($"order");
        await Task.WhenAll(itemListTask);
        var items = itemListTask.Result.Order;
        
        return items;
    }
}
