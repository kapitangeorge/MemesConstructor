using MemesConstructorClient.Interfaces;
using MemesConstructorClient.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.ComponentsBase
{
    public class AddMemBase : ComponentBase
    {
        public Mem mem = new Mem() { PublishDate = DateTime.Now, Rating = 0 };

        [Inject]
        public IMemesService MemesService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task HandleValidSubmit()
        {

            var result = await MemesService.AddNewMem(mem);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected void AddImageUrl(string imageUrl)
        {
            mem.ImagePath = imageUrl;
        }
    }
}
