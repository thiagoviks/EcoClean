using AutoMapper;
using EcoClean.Data.Contexts;
using EcoClean.Models;
using EcoClean.Services;
using EcoClean.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EcoClean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacaoController : ControllerBase
    {
        private readonly ILogger<NotificacaoController> _logger;
        private readonly INotificacaoService _notificacaoService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public NotificacaoController(
            ILogger<NotificacaoController> logger,
            DatabaseContext context,
            INotificacaoService service,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _notificacaoService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NotificacaoViewModel>> Get()
        {
            var notificacoes = _notificacaoService.ListarNotificacoes();
            var viewModelList = _mapper.Map<IEnumerable<NotificacaoViewModel>>(notificacoes);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<NotificacaoViewModel> Get(long id)
        {
            var notificacao = _notificacaoService.ObterNotificacaoPorId(id);
            if (notificacao == null)
                return NotFound();

            var viewModel = _mapper.Map<MoradorViewModel>(notificacao);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] NotificacaoViewModel viewModel)
        {
            var notificacao = _mapper.Map<NotificacaoModel>(viewModel);
            _notificacaoService.CriarNotificacao(notificacao);
            return CreatedAtAction(nameof(Get), new { id = notificacao.Id }, notificacao);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] MoradorViewModel viewModel)
        {
            var notificacaoExistente = _notificacaoService.ObterNotificacaoPorId(id);
            if (notificacaoExistente == null)
                return NotFound();

            _mapper.Map(viewModel, notificacaoExistente);
            _notificacaoService.AtualizarNotificacao(notificacaoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _notificacaoService.DeletarNotificacao(id);
            return NoContent();
        }


    }
}
