using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace MemesConstructorClient.ComponentsBase
{
    public class UploadImageBase : ComponentBase
    {
        [Parameter]
        public string Folder { get; set; }

        [Parameter]
        public EventCallback<string> UploadImageCallback { get; set; }

        [Inject]
        public IFileReaderService fileReader { get; set; }

        [Inject]
        public HttpClient http { get; set; }

       
       protected string imagePath { get; set; } = null;


        protected ElementReference inputReference;
        protected string message = string.Empty;

        protected string fileName = string.Empty;
        protected string type = string.Empty;
        protected string size = string.Empty;

        Stream fileStream = null;

        protected async Task OpenFileAsync()
        {
            var file = (await fileReader.CreateReference(inputReference).EnumerateFilesAsync()).FirstOrDefault();

            if (file == null)
            {
                return;
            }

            var fileInfo = await file.ReadFileInfoAsync();

            fileName = fileInfo.Name;
            type = fileInfo.Type;
            size = $"{fileInfo.Size}b";


            using (var ms = await file.CreateMemoryStreamAsync((int)fileInfo.Size))
            {
                fileStream = new MemoryStream(ms.ToArray());
            }
        }

        protected async Task UploadFileAsync()
        {
            if (String.IsNullOrWhiteSpace(fileName)) return;

            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");

            content.Add(new StreamContent(fileStream, (int)fileStream.Length), "image", fileName);

            string url = "https://localhost:44309";

            var response = await http.PostAsync($"{url}/api/Image/{Folder}", content);

            if (response.IsSuccessStatusCode)
            {
                var uploadFileName = await response.Content.ReadAsStringAsync();

                imagePath = $"{url}/Images/{uploadFileName}";

                await UploadImageCallback.InvokeAsync(imagePath);

                message = "Файл был загружен";
            }
        }
    }
}
