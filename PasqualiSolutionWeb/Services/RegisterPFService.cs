using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using PasqualiSolution.Web.Utils;
using PasqualiSolution.Web.Services.IServices;
using PasqualiSolution.Web.Models;

namespace PasqualiSolution.Web.Services
{
    public class RegisterPFService : IRegisterPFService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/RegisterPF";

        public RegisterPFService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<RegisterPFModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<RegisterPFModel>>();
        }

        public async Task<RegisterPFModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<RegisterPFModel>();
        }

        public async Task<RegisterPFModel> CreateProduct(RegisterPFModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<RegisterPFModel>();
            else throw new Exception("Something went wrong when calling API");
        }
        public async Task<RegisterPFModel> UpdateProduct(RegisterPFModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<RegisterPFModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
