using System.Collections.Generic;

namespace BlazorShared.Models;

public class OrderDetailViewModel : OrderViewModel
{
    public List<OrderItemViewModel> OrderItems { get; set; } = new();
}
