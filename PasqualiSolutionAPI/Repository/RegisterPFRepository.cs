using AutoMapper;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Model.Context;
using ToDoListAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ToDoListAPI.Repository
{
    public class RegisterPFRepository : IRegisterPFRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;
        private readonly Messages.Messages _messages;

        public RegisterPFRepository(SqlContext context, IMapper mapper, Messages.Messages messages)
        {
            _context = context;
            _mapper = mapper;
            _messages = messages;
        }

        public async Task<IEnumerable<RegisterPFVO>> FindAll()
        {
            Log.Information(_messages.SearchAnyIntoDatabase(nameof(_context.Registers)));
            List<RegisterPF> tasks = await _context.Registers.ToListAsync();
            return _mapper.Map<List<RegisterPFVO>>(tasks);
        }

        public async Task<RegisterPFVO> FindById(long id)
        {
            RegisterPF register =
                await _context.Registers.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<RegisterPFVO>(register);
        }

        public async Task<RegisterPFVO> Create(RegisterPFVO vo)
        {
            RegisterPF createRegister = _mapper.Map<RegisterPF>(vo);
            Log.Information(_messages.CreateRegisterIntoDataBase(createRegister));
            _context.Registers.Add(createRegister);
            await _context.SaveChangesAsync();
            return _mapper.Map<RegisterPFVO>(createRegister);
        }
        public async Task<RegisterPFVO> Update(RegisterPFVO vo)
        {
            RegisterPF updateRegister = _mapper.Map<RegisterPF>(vo);
            _context.Registers.Update(updateRegister);
            await _context.SaveChangesAsync();
            return _mapper.Map<RegisterPFVO>(updateRegister);

        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                RegisterPF register =
                await _context.Registers.Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
                if (register== null) return false;
                _context.Registers.Remove(register);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
