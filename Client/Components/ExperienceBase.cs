using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorRScard.Client.Components
{
    public class ExperienceBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected BlazorRScard.Client.Services.ApiService ApiService { get; set; }

        protected IEnumerable<BlazorRScard.Models.Experience> Experiences { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Méthode 1
            // @using BlazorRScard.Client.Services 
            // @inherits OwningComponentBase<ApiService>
            // Experiences = await @Service.GetExperiencesAsync();

            // Méthode 2
            // [Inject] HttpClient Http { get; set; }
            // Experiences = await Http.GetJsonAsync<BlazorRScard.Models.Experience[]>("Experience");

            // Méthode 3
            // [Inject] protected BlazorRScard.Client.Services.ApiService ApiService { get; set; }
            Experiences = await ApiService.GetExperiencesAsync(PageIndex);

            //base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync("positioningTimelineElements");
            await base.OnAfterRenderAsync(firstRender);
        }

        public int Id { get; set; }

        public int PageIndex { get; set; }

        public string AjaxLoaderDisplayClass { get; set; }

        public string ButtonMoreDisplayClass { get; set; }

        protected async Task LoadMoreExperiences()
        {
            PageIndex++;
            AjaxLoaderDisplayClass = "d-inline-block";
            ButtonMoreDisplayClass = "d-none";
            var experiences = await ApiService.GetExperiencesAsync(PageIndex);
            Experiences = Experiences.Concat(experiences);
            await JsRuntime.InvokeVoidAsync("triggerScroll");
            AjaxLoaderDisplayClass = "d-none";
            ButtonMoreDisplayClass = "d-inline-block";
        }
    }
}
