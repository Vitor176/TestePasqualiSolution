using PasqualiSolution.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasqualiSolution.Web.Services.IServices
{
    public interface IRegisterPFService
    {
        Task<IEnumerable<RegisterPFModel>> FindAllProducts();
        Task<RegisterPFModel> FindProductById(long id);
        Task<RegisterPFModel> CreateProduct(RegisterPFModel model);
        Task<RegisterPFModel> UpdateProduct(RegisterPFModel model);
        Task<bool> DeleteProductById(long id);
    }
}
