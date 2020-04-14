using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRScard.Models;

namespace BlazorRScard.Client.Components
{
    public class ExperiencesBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected IApiService ApiService { get; set; }

        public int PageIndex { get; set; }

        public string AjaxLoaderDisplayClass { get; set; }

        public string ButtonMoreDisplayClass { get; set; }

        protected IEnumerable<Experience> Experiences { get; set; }

        private static readonly int PAGE_SIZE = 6;

        public int Id { get; set; }

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
            Experiences = await ApiService.GetExperiencesAsync(PageIndex, PAGE_SIZE);

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync("positioningTimelineElements");
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task LoadMoreExperiences()
        {
            PageIndex++;
            AjaxLoaderDisplayClass = "d-inline-block";
            ButtonMoreDisplayClass = "d-none";
            var experiences = await ApiService.GetExperiencesAsync(PageIndex, PAGE_SIZE);

            if (experiences.Count == PAGE_SIZE)
                ButtonMoreDisplayClass = "d-inline-block";

            Experiences = Experiences.Concat(experiences);
            await JsRuntime.InvokeVoidAsync("triggerScroll");
            AjaxLoaderDisplayClass = "d-none";
            
        }
    }
}
