using MemesConstructorClient.Interfaces;
using MemesConstructorClient.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.ComponentsBase
{
    public class MemProfileBase : ComponentBase
    {
        public Mem Mem { get; set; } = new Mem();

        [Inject]
        public IMemesService MemesService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Mem = await MemesService.GetMemById(int.Parse(Id));

        }

        protected async Task PlusRating()
        {
            Mem.Rating += 1;
            Mem = await MemesService.UpdateMem(int.Parse(Id), Mem);
            StateHasChanged();
        }

        protected async Task MinusRating()
        {
            Mem.Rating -= 1;
            Mem = await MemesService.UpdateMem(int.Parse(Id), Mem);
            StateHasChanged();
        }
    }

}
