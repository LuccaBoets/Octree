// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Octree_GUI.Pages
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using Octree_GUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\_Imports.razor"
using Octree_GUI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\Pages\Index.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\Pages\Index.razor"
using System.Drawing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\Pages\Index.razor"
using Octree;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\Pages\Index.razor"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\Pages\Index.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 22 "C:\Users\boets\OneDrive\Documents\GitHub\Octree\Octree GUI\Pages\Index.razor"
       

    public List<Color> colors { get; set; }


    protected override void OnInitialized()
    {
        colors = new List<Color>();
    }

    async void LoadFile(InputFileChangeEventArgs e)
    {
        var filetype = files.FirstOrDefault().Name;
        if (filetype.Contains("png") || filetype.Contains("jpg") || filetype.Contains("gif"))
        {
            using (var reader = new System.IO.StreamReader(files.FirstOrDefault().Data))
            {
                var temp1 = await reader.ReadToEndAsync();
                //reader.read
            }
            var temp = files.FirstOrDefault().Data;
            var img = Bitmap.FromStream(temp);
            Control.run(img);
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
