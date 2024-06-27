using AutoMapper;
using EcoClean.Data.Contexts;
using EcoClean.Models;
using EcoClean.Services;
using EcoClean.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EcoClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorController : ControllerBase
    {
        private readonly ILogger<MoradorController> _logger;
        private readonly IMoradorService _moradorService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public MoradorController(
            ILogger<MoradorController> logger,
            DatabaseContext context,
            IMoradorService service,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _moradorService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MoradorViewModel>> Get()
        {
            var moradores = _moradorService.ListarMoradores();
            var viewModelList = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<MoradorViewModel> Get(int id)
        {
            var morador = _moradorService.ObterMoradorPorId(id);
            if (morador == null)
                return NotFound();

            var viewModel = _mapper.Map<MoradorViewModel>(morador);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MoradorViewModel viewModel)
        {
            var morador = _mapper.Map<MoradorModel>(viewModel);
            _moradorService.CriarMorador(morador);
            return CreatedAtAction(nameof(Get), new { id = morador.Id }, morador);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MoradorViewModel viewModel)
        {
            var moradorExistente = _moradorService.ObterMoradorPorId(id);
            if (moradorExistente == null)
                return NotFound();

            _mapper.Map(viewModel, moradorExistente);
            _moradorService.AtualizarMorador(moradorExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _moradorService.DeletarMorador(id);
            return NoContent();
        }
    }
}
