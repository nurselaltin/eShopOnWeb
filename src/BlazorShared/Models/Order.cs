
using System.Collections.Generic;
using System;

namespace BlazorShared.Models;

public class Order
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public string OrderStatus { get; set; }

    public List<OrderItemViewModel> OrderItems { get; private set; }

    public OrderAddress ShipToAddress { get; private set; }

}

