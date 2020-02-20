using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AvaliacaoTailorit.Backend.Api.Controllers
{
    [RoutePrefix("Servico/Usuario")]
    [Description("Gerenciar Usuarios")]
    public class UsuarioController : MainController
    {
        public UsuarioController(INotificador notificador,
                                 IUsuarioServico usuarioServico)
            :base(notificador)
        {
            _usuarioServico = usuarioServico;
        }

        private readonly IUsuarioServico _usuarioServico;

        [HttpGet, Route]
        [Display(Name = "Filtrar")]
        public async Task<HttpResponseMessage> Get([FromUri] FiltrarCmd parametros) 
        {
            if (object.Equals(parametros, null))
                parametros = new FiltrarCmd();

            Usuario[] usuario =  _usuarioServico.Filtrar(parametros);
            return CustomResponse(usuario);
        }

        [HttpPost, Route]
        [Display(Name = "Inserir")]
        public async Task<HttpResponseMessage> Post([FromBody]InserirCmd parametros)
        {
            //if (!ModelState.IsValid) return CustomResponse(ModelState);

            _usuarioServico.Adicionar(parametros);

            return CustomResponse(parametros);

        }
    }
}