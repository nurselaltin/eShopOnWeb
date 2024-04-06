using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

/// <summary>
/// List Catalog Items (paged)
/// </summary>
public class OrderListPagedEndpoint : IEndpoint<IResult, ListPagedOrderRequest, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public OrderListPagedEndpoint(IUriComposer uriComposer, IMapper mapper)
    {
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders",
            async (int? pageSize, int? pageIndex, int? Id, IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(new ListPagedOrderRequest(pageSize, pageIndex, Id), itemRepository);
            })
            .Produces<ListPagedOrderResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(ListPagedOrderRequest request, IRepository<Order> itemRepository)
    {
        await Task.Delay(1000);
        var response = new ListPagedOrderResponse(request.CorrelationId());

        var filterSpec = new OrderFilterSpecification(request.Id);
        int totalItems = await itemRepository.CountAsync(filterSpec);

        var pagedSpec = new OrderFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize,
            Id: request.Id);

        var items = await itemRepository.ListAsync(pagedSpec);

        response.Orders.AddRange(items.Select(_mapper.Map<OrderDto>));
       

        if (request.PageSize > 0)
        {
            response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
        }
        else
        {
            response.PageCount = totalItems > 0 ? 1 : 0;
        }

        return Results.Ok(response);
    }

}
