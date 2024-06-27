using AutoMapper;
using EcoClean.Data.Contexts;
using EcoClean.Models;
using EcoClean.Services;
using EcoClean.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoClean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CaminhaoController : ControllerBase
    {
        private readonly ILogger<CaminhaoController> _logger;
        private readonly ICaminhaoService _caminhaoService;
        private readonly IMapper _mapper;

        private readonly DatabaseContext _context;

        public CaminhaoController(
            ILogger<CaminhaoController> logger,
            DatabaseContext context,
            ICaminhaoService service,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _caminhaoService = service;
        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<CaminhaoViewModel>> Get()
        {
            var caminhoes = _caminhaoService.ListarCaminhoes();
            var viewModelList = _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<CaminhaoViewModel> Get(long id)
        {
            var caminhao = _caminhaoService.ObterCaminhaoPorId(id);
            if (caminhao == null)
                return NotFound();

            var viewModel = _mapper.Map<ColetaViewModel>(caminhao);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] CaminhaoViewModel viewModel)
        {
            var caminhao = _mapper.Map<CaminhaoModel>(viewModel);
            _caminhaoService.CriarCaminhao(caminhao);
            return CreatedAtAction(nameof(Get), new { id = caminhao.Id }, caminhao);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(long id, [FromBody] CaminhaoViewModel viewModel)
        {
            var caminhaoExistente = _caminhaoService.ObterCaminhaoPorId(id);
            if (caminhaoExistente == null)
                return NotFound();

            _mapper.Map(viewModel, caminhaoExistente);
            _caminhaoService.AtualizarCaminhao(caminhaoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(long id)
        {
            _caminhaoService.DeletarCaminhao(id);
            return NoContent();
        }

    }
}
