using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;
public interface IOrderService
{
    Task<List<Order>> List();
    Task<Order> Edit(Order order);
    Task<Order> GetById(int id);
}
