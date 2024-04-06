
namespace BlazorShared.Models;

public class Order
{
   
    public int BuyerId { get; set; }
    public System.DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public string OrderStatus { get; set; }
    //public OrderAddress? ShippingAddress { get; set; }
}
