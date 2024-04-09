using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorAdmin.Services;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Pages.OrderPage;

public partial class OrderList : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderService OrderService { get; set; }
        
    private List<Order> orders = new List<Order>();

    private OrderEdit OrderEditComponent { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender = true)
    {
        if (firstRender)
        {
            orders = await OrderService.List();

            CallRequestRefresh();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task EditClick(int id)
    {
        await OrderEditComponent.Open(id);
    }

    private async Task ReloadOrders()
    {
        orders = await OrderService.List();
        StateHasChanged();
    }
}
