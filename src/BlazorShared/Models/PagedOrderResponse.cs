using System.Collections.Generic;

namespace BlazorShared.Models;

public class PagedOrderResponse
{
    public List<Order> Order { get; set; } = new List<Order>();
    public int PageCount { get; set; } = 0;
}
