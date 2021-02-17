using MemesConstructorClient.Interfaces;
using MemesConstructorClient.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.ComponentsBase
{
    public class CommentsBase : ComponentBase
    {
        public Comment Comment { get; set; } = new Comment() {  Rating = 0 };
        public IEnumerable<Comment> Comments { get; set; }

        [Inject]
        public ICommentsService CommentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Comments = await CommentService.GetComments(Id);
        }

        protected async Task HandleValidSubmit()
        {
            Comment.PublishDate = DateTime.Now;
            Comment.Mem_Id = Id;

           var result = await CommentService.CreateComment(Comment);
           if(result != null)
            {
                Comments = await CommentService.GetComments(Id);
                NavigationManager.NavigateTo($"/MemProfile/{Id}");
            }
            
        }
    }
}
