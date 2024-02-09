using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Model;

namespace ToDoListAPI.Repository
{
    public interface IRegisterPFRepository
    {
        Task<IEnumerable<RegisterPFVO>> FindAll();
        Task<RegisterPFVO> FindById(long id);
        Task<RegisterPFVO> Create(RegisterPFVO vo);
        Task<RegisterPFVO> Update(RegisterPFVO vo);
        Task<bool> Delete(long id);
    }
}
