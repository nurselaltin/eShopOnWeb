
namespace BlazorShared.Models;

public class OrderViewModel
{
   
    public int OrderNumber { get; set; }
    public System.DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; }
    public OrderAddress? ShippingAddress { get; set; }
}
