using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
using System;
using ToDoListAPI.Repository;
using System.Linq;
using ToDoListAPI.Data.ValueObjects;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPFController : ControllerBase
    {
        private IRegisterPFRepository _repository;
        private readonly Messages.Messages _messages;

        public RegisterPFController(IRegisterPFRepository repository, Messages.Messages messages)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
            _messages = messages ?? throw new ArgumentNullException("Ocorreu um erro interno!");
        }

        /// <summary>
        /// Obtém todos os cadastros
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                Log.Information($"{nameof(RegisterPFController)} - {_messages.BeginRequestMessage(nameof(RegisterPFController))}");
                var registers = await _repository.FindAll();

                if (registers.Count() == 0)
                {
                    return Ok(registers);
                }

                return Ok(registers);
            }
            catch (Exception e)
            {
                Log.Information($"{nameof(RegisterPFController)} - {_messages.ErrorLog(e.ToString())}");
                return BadRequest(Messages.Messages.UnexpectedErrorMessage);
            }

        }
        /// <summary>
        /// Obtém um cadastro específico pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterPFVO>> FindById(long id)
        {
            try
            {
                var register = await _repository.FindById(id);
                if (register == null) return NotFound(Messages.Messages.NotFoundDataForThisIdMessage);
                return Ok(register);
            }
            catch (Exception e)
            {
                Log.Information($"{nameof(RegisterPFController)} - {_messages.ErrorLog(e.ToString())}");
                return BadRequest(Messages.Messages.UnexpectedErrorMessage);
            }
        }
        /// <summary>
        /// Cria um novo cadastro
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<RegisterPFVO>> Create([FromBody] RegisterPFVO vo)
        {
            try
            {
                if (vo == null) return BadRequest(Messages.Messages.ErrorObjectNullMessage);
                var register = await _repository.Create(vo);

                return Ok(register);
            }
            catch (Exception e)
            {
                Log.Information($"{nameof(RegisterPFController)} - {_messages.ErrorCreateRegisterIntoDataBase(e.ToString())}");
                return BadRequest(Messages.Messages.UnexpectedErrorMessage);
            }

        }
        /// <summary>
        /// Atualiza uma Cadastro já existente
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<RegisterPFVO>> Update([FromBody]RegisterPFVO vo)
        {
            try
            {
                if (vo == null) return BadRequest(Messages.Messages.ErrorObjectNullMessage);
                var register = await _repository.Update(vo);
                if (register == null) return BadRequest(Messages.Messages.ErrorUpdateRegisterMessage);
                else return Ok(register);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = "Erro interno no servidor.", details = e.Message });
            }

        }
        /// <summary>
        /// Deleta uma Cadastro existente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {

            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}

