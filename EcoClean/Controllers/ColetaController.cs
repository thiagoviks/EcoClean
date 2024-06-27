using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using EcoClean.Services;
using EcoClean.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace EcoClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColetaController : ControllerBase
    {
        private readonly ILogger<ColetaController> _logger;
        private readonly IColetaService _coletaService;
        private readonly IMapper _mapper;

        private readonly DatabaseContext _context;

        public ColetaController(
            ILogger<ColetaController> logger,
            DatabaseContext context,
            IColetaService service,
            IMapper mapper) 
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _coletaService = service;

        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<ColetaViewModel>> Get()
        {
            var coletas = _coletaService.ListarColetas();
            var viewModelList = _mapper.Map<IEnumerable<ColetaViewModel>>(coletas);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<ColetaViewModel> Get(long id)
        {
            var coleta = _coletaService.ObterColetaPorId(id);
            if (coleta == null)
                return NotFound();

            var viewModel = _mapper.Map<ColetaViewModel>(coleta);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] ColetaViewModel viewModel)
        {
            var coleta = _mapper.Map<ColetaModel>(viewModel);
            _coletaService.CriarColeta(coleta);
            return CreatedAtAction(nameof(Get), new { id = coleta.Id }, coleta);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(long id, [FromBody] ColetaViewModel viewModel)
        {
            var coletaExistente = _coletaService.ObterColetaPorId(id);
            if (coletaExistente == null)
                return NotFound();

            _mapper.Map(viewModel, coletaExistente);
            _coletaService.AtualizarColeta(coletaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(long id)
        {
            _coletaService.DeletarColeta(id);
            return NoContent();
        }
    }
}
