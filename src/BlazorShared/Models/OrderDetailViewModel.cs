using System.Collections.Generic;

namespace BlazorShared.Models;

public class OrderDetailViewModel : Order
{
    public List<OrderItemViewModel> OrderItems { get; set; } = new();
}
