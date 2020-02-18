using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd.Validacao;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Servicos.Comum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Servicos
{
    public class UsuarioServico : BaseService, IUsuarioServico
    {
        public UsuarioServico(INotificador notificador,
                              IUsuarioRep rep,
                              ISexoRep sexoRep)
            : base(notificador)
        {
            _rep = rep;
            _sexoRep = sexoRep;
        }

        private readonly IUsuarioRep _rep;
        private readonly ISexoRep _sexoRep;

        public async Task Adicionar(InserirCmd comando)
        {
            Usuario usuario = null;
            Sexo sexo = null;

            if (!ExecutarValidacao(new UsuarioValidacao(), comando)) return;

            if(_rep.Find(x => x.Nome.Equals(comando.Nome) && x.Email.Equals(comando.Email)  ).Result.Any())
            {
                Notificar("Já existe um usuário com essas informações");
                return;
            }

            sexo = await _sexoRep.Get(comando.Sexo);

            if(!object.Equals(sexo, null))
            {
                Notificar("Não foi possível localizar o sexo do usuário");
                return;
            }

            comando.Aplicar(ref usuario, sexo);
            await _rep.Add(usuario);
        }

        public void Dispose()
        {
            _rep?.Dispose();
            _sexoRep?.Dispose();
        }

        public async Task<IEnumerable<Usuario>> Filtrar(FiltrarCmd comando)
        {
            return await _rep.Filtrar(comando);
        }

        public async Task<IEnumerable<Usuario>> Obtertodos()
        {
            return await _rep.Get();
        }
    }
}
