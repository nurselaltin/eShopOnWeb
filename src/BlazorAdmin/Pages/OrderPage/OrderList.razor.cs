using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Pages.OrderPage;

public partial class OrderList : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderService OrderService { get; set; }
        
    private List<Order> orders = new List<Order>();

    protected override async Task OnAfterRenderAsync(bool firstRender = true)
    {
        if (firstRender)
        {
            orders = await OrderService.List();

            CallRequestRefresh();
        }

        await base.OnAfterRenderAsync(firstRender);
    }
}
