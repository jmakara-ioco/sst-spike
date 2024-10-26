using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace VezaVI.Light.Components
{
    public partial class VezaFileUploader
    {
        private ElementReference _input;
        
        [Parameter]
        public string ImgUrl { get; set; }
        
        [Parameter]
        public EventCallback<string> OnChange { get; set; }
        
        [Inject]
        public IFileReaderService FileReaderService { get; set; }
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string UploadUrl { get; set; }
        [Parameter]
        public string DeleteUrl { get; set; }

        private async Task HandleSelected()
        {
            foreach (var file in await FileReaderService.CreateReference(_input).EnumerateFilesAsync())
            {
                if (file != null)
                {
                    var fileInfo = await file.ReadFileInfoAsync();
                    using (var ms = await file.CreateMemoryStreamAsync(4 * 1024))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(ms.Length)), "image", fileInfo.Name);

                        var tokenResult = await LocalStorage.GetItemAsync<string>("authToken");
                        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);

                        var postResult = await HttpClient.PostAsync(UploadUrl, content);
                        var postContent = await postResult.Content.ReadAsStringAsync();

                        if (!postResult.IsSuccessStatusCode)
                        {
                            throw new ApplicationException(postContent);
                        }
                        else
                        {
                            var imgUrl = Path.Combine(NavigationManager.BaseUri, postContent);
                            await OnChange.InvokeAsync(ImgUrl);
                        }
                    }
                }
            }
        }

    }
}
