using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using EcoClean.Services;
using EcoClean.ViewModel;

namespace EcoClean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RotaController : ControllerBase
    {
        private readonly ILogger<RotaController> _logger;
        private readonly IRotaService _rotaService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public RotaController(
            ILogger<RotaController> logger,
            DatabaseContext context,
            IRotaService service,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _rotaService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RotaViewModel>> Get()
        {
            var rotas = _rotaService.ListarRotas();
            var viewModelList = _mapper.Map<IEnumerable<RotaViewModel>>(rotas);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<RotaViewModel> Get(long id)
        {
            var rota = _rotaService.ObterRotaPorId(id);
            if (rota == null)
                return NotFound();

            var viewModel = _mapper.Map<MoradorViewModel>(rota);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RotaViewModel viewModel)
        {
            var rota = _mapper.Map<RotaModel>(viewModel);
            _rotaService.CriarRota(rota);
            return CreatedAtAction(nameof(Get), new { id = rota.Id }, rota);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] RotaViewModel viewModel)
        {
            var rotaExistente = _rotaService.ObterRotaPorId(id);
            if (rotaExistente == null)
                return NotFound();

            _mapper.Map(viewModel, rotaExistente);
            _rotaService.AtualizarRota(rotaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _rotaService.DeletarRota(id);
            return NoContent();
        }

    }
}
