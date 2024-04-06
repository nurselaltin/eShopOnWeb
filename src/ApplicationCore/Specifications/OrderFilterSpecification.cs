using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class OrderFilterSpecification : Specification<Order>
{
    public OrderFilterSpecification(int? Id)
    {
        Query.Where(i => (!Id.HasValue || i.Id == Id));
    }
}
