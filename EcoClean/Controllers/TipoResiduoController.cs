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
    public class TipoResiduoController : ControllerBase
    {

        private readonly ILogger<TipoResiduoController> _logger;
        private readonly ITipoResiduoService _tipoResiduoService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public TipoResiduoController(
            ILogger<TipoResiduoController> logger,
            DatabaseContext context,
            ITipoResiduoService service,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _tipoResiduoService = service;
        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<TipoResiduoViewModel>> Get()
        {
            var tipoResiduos = _tipoResiduoService.ListarTipoResiduos();
            var viewModelList = _mapper.Map<IEnumerable<TipoResiduoViewModel>>(tipoResiduos);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<TipoResiduoViewModel> Get(long id)
        {
            var tipoResiduo = _tipoResiduoService.ObterTipoResiduoPorId(id);
            if (tipoResiduo == null)
                return NotFound();

            var viewModel = _mapper.Map<TipoResiduoViewModel>(tipoResiduo);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] TipoResiduoViewModel viewModel)
        {
            var tipoResiduo = _mapper.Map<TipoResiduoModel>(viewModel);
            _tipoResiduoService.CriarTipoResiduo(tipoResiduo);
            return CreatedAtAction(nameof(Get), new { id = tipoResiduo.Id }, tipoResiduo);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(long id, [FromBody] RotaViewModel viewModel)
        {
            var tipoResiduoExistente = _tipoResiduoService.ObterTipoResiduoPorId(id);
            if (tipoResiduoExistente == null)
                return NotFound();

            _mapper.Map(viewModel, tipoResiduoExistente);
            _tipoResiduoService.AtualizarTipoResiduo(tipoResiduoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(long id)
        {
            _tipoResiduoService.DeletarTipoResiduo(id);
            return NoContent();
        }


    }
}
