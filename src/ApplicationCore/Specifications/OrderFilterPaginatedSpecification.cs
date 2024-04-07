using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class OrderFilterPaginatedSpecification : Specification<Order>
{
    public OrderFilterPaginatedSpecification(int skip, int take, int? Id)
        : base()
    {
        if (take == 0)
        {
            take = int.MaxValue;
        }
        Query
            .Where(i => (!Id.HasValue || i.Id == Id)).Include(o => o.OrderItems)
            .Skip(skip).Take(take);
    }
}
