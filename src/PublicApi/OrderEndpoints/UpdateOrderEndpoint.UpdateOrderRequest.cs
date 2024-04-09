using System;
using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;


namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class UpdateOrderRequest : BaseRequest
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public string OrderStatus { get; set; }

    public List<OrderItem> OrderItems { get; private set; }

    public Address ShipToAddress { get; private set; }
}
