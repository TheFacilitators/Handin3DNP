// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WebClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\_Imports.razor"
using WebClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\Pages\AdultDetails.razor"
using WebClient.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\Pages\AdultDetails.razor"
using WebClient.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\Pages\AdultDetails.razor"
using Microsoft.Extensions.Hosting;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Adults/{id:int}")]
    public partial class AdultDetails : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "C:\Users\jodyc\RiderProjects\Handin2DNP\WebClient\Pages\AdultDetails.razor"
       
    [Parameter]
    public int Id { get; set; }
    private Adult adult;

    protected override async Task OnInitializedAsync()
    {
        adult = AdultData.GetById(Id);
    }
    
    private async Task RemoveAdult()
    {
        try
        {
            await AdultData.RemoveAdultAsync(Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("No such user found");
        }
    }

    private void EditAdult()
    {
        NavMag.NavigateTo($"EditAdult/{Id}");
    }

    private void Back()
    {
        NavMag.NavigateTo("Adults");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavMag { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAdultService AdultData { get; set; }
    }
}
#pragma warning restore 1591
