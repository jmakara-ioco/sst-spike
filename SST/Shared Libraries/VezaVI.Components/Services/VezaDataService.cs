using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VezaVI.Light.Shared;
using System.Text.Json;
using System.Net.Http.Json;

namespace VezaVI.Light.Components
{
    public abstract class VezaDataService<TEntity> : IVezaDataService<TEntity> where TEntity : class, IVezaVIRecordBase, new()
    {
        public readonly HttpClient _httpClient;
        public readonly ILocalStorageService _localStorage;
        public readonly string _apiRootPath;
        public string APIRootPath
        {
            get
            {
                return _apiRootPath;
            }
        }

        public VezaDataService(string apiRootPath, HttpClient httpClient,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _apiRootPath = apiRootPath;
        }

        public async Task<VezaAPISubmitResult> AddAsync(TEntity item)
        {
            var result = new VezaAPISubmitResult();
            var tokenResult = await _localStorage.GetItemAsync<string>("authToken");
            string queryString = $"{_apiRootPath}";
            var jsonItem = JsonSerializer.Serialize(item);
            var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");
            if (tokenResult != null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
            var response = await _httpClient.PostAsync(queryString, content);
            if (response.IsSuccessStatusCode)
                result = JsonSerializer.Deserialize<VezaAPISubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<VezaAPISubmitResult> DeleteAsync(object id)
        {
            VezaAPISubmitResult result = new VezaAPISubmitResult();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiRootPath}/delete/{id}");
            var tokenResult = await _localStorage.GetItemAsync<string>("authToken");
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
                result = JsonSerializer.Deserialize<VezaAPISubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<TEntity> GetAsync(object id)
        {
            var result = new TEntity();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiRootPath}/{id}");
            var tokenResult = await _localStorage.GetItemAsync<string>("authToken");
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
            var response = await _httpClient.SendAsync(request);

            var str = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                result = JsonSerializer.Deserialize<TEntity>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<PaginatedList<TEntity>> GetAllAsync(string sortField)
        {
            return await GetAllAsync(sortField, new List<VezaVIGridFilter>());
        }

        public async Task<PaginatedList<TEntity>> GetAllAsync(string sortField, IList<VezaVIGridFilter> gridFilter)
        {
            var result = new PaginatedList<TEntity>();
            var tokenResult = await _localStorage.GetItemAsync<string>("authToken");
            string queryString = $"{_apiRootPath}/GetList?ReturnAll=true&sortField={sortField}&sortOrder=ASC";

            var filter = JsonSerializer.Serialize(gridFilter);
            var content = new StringContent(filter, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
            var response = await _httpClient.PostAsync(queryString, content);
            if (response.IsSuccessStatusCode)
                result = JsonSerializer.Deserialize<PaginatedList<TEntity>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true,  });
            return result;
        }

        public async Task<PaginatedList<TEntity>> GetListAsync(IList<VezaVIGridFilter> gridFilter, int pageIndex, int? pageSize, string sortField, string sortOrder, string searchText)
        {
            var result = new PaginatedList<TEntity>();
            var tokenResult = await _localStorage.GetItemAsync<string>("authToken");
            string queryString = $"{_apiRootPath}/GetList?pageIndex={pageIndex}";
            if (pageSize > 0)
                queryString += $"&pageSize={pageSize}";
            if (!string.IsNullOrEmpty(sortField))
                queryString += $"&sortField={sortField}";
            if (!string.IsNullOrEmpty(sortOrder))
                queryString += $"&sortOrder={sortOrder}";
            if (!string.IsNullOrEmpty(searchText))
                queryString += $"&searchText={searchText}";

            var filter = (gridFilter != null) ? JsonSerializer.Serialize(gridFilter) : JsonSerializer.Serialize(new List<VezaVIGridFilter>());
            var content = new StringContent(filter, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
            var response = await _httpClient.PostAsync(queryString, content);
            if (response.IsSuccessStatusCode)
                result = JsonSerializer.Deserialize<PaginatedList<TEntity>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<VezaAPISubmitResult> UpdateAsync(TEntity item)
        {
            var result = new VezaAPISubmitResult();
            var tokenResult = await _localStorage.GetItemAsync<string>("authToken");
            string queryString = $"{_apiRootPath}/Update/{item.GetID()}";
            var jsonItem = JsonSerializer.Serialize(item);
            var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
            var response = await _httpClient.PostAsync(queryString, content);
            if (response.IsSuccessStatusCode)
                result = JsonSerializer.Deserialize<VezaAPISubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<VezaAPISubmitResult> ImportAsync(string importFileBase64)
        {
            var result = new VezaAPISubmitResult();
            var tokenResult = await _localStorage.GetItemAsync<string>("authToken");
            string queryString = $"{_apiRootPath}/Import";
            var jsonItem = JsonSerializer.Serialize(importFileBase64);
            var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenResult);
            var response = await _httpClient.PostAsync(queryString, content);
            if (response.IsSuccessStatusCode)
                result = JsonSerializer.Deserialize<VezaAPISubmitResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result;
        }

    }
}
