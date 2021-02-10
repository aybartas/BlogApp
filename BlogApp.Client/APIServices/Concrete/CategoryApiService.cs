using BlogApp.Client.APIServices.Interface;
using BlogApp.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogApp.Client.APIServices.Concrete
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("http://localhost:52624/api/categories/");

        }

        public async Task<List<CategoryListModel>> GetAll()
        {
            var httpResponse = await httpClient.GetAsync("");

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CategoryListModel>>(responseContent);
            }

            return null;
        }
    }
}
