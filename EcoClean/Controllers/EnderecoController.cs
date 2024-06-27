using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using EcoClean.Services;
using EcoClean.ViewModel;

namespace EcoClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger<EnderecoController> _logger;
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public EnderecoController(
            ILogger<EnderecoController> logger,
            DatabaseContext context,
            IEnderecoService service,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _enderecoService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnderecoViewModel>> Get()
        {
            var enderecos = _enderecoService.ListarEnderecos();
            var viewModelList = _mapper.Map<IEnumerable<EnderecoViewModel>>(enderecos);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<EnderecoViewModel> Get(int id)
        {
            var endereco = _enderecoService.ObterEnderecoPorId(id);
            if (endereco == null)
                return NotFound();

            var viewModel = _mapper.Map<EnderecoViewModel>(endereco);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] EnderecoViewModel viewModel)
        {
            var endereco = _mapper.Map<EnderecoModel>(viewModel);
            _enderecoService.CriarEndereco(endereco);
            return CreatedAtAction(nameof(Get), new { id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EnderecoViewModel viewModel)
        {
            var enderecoExistente = _enderecoService.ObterEnderecoPorId(id);
            if (enderecoExistente == null)
                return NotFound();

            _mapper.Map(viewModel, enderecoExistente);
            _enderecoService.AtualizarEndereco(enderecoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _enderecoService.DeletarEndereco(id);
            return NoContent();
        }
    }
}
