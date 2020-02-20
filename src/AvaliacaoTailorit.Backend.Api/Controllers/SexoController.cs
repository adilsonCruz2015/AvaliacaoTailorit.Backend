using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AvaliacaoTailorit.Backend.Api.Controllers
{
    [RoutePrefix("Servico/Sexo")]
    [Description("Gerenciar Sexo")]
    public class SexoController : MainController
    {
        public SexoController(INotificador notificador,
                              ISexoServico servico)
            : base(notificador)
        {
            _servico = servico;
        }

        private readonly ISexoServico _servico;

        [HttpGet, Route]
        [Display(Name = "Filtrar")]
        public async Task<HttpResponseMessage> Get()
        {
            Sexo[] sexo = _servico.Obter();
            return CustomResponse(sexo);
        }
    }
}