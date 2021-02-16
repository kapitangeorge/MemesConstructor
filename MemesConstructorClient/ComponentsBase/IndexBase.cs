using MemesConstructorClient.Interfaces;
using MemesConstructorClient.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.ComponentsBase
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IMemesService MemesService { get; set; }

        public IEnumerable<Mem> Memes { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Memes = (await MemesService.GetMemes()).ToList();
        }
    }
}
