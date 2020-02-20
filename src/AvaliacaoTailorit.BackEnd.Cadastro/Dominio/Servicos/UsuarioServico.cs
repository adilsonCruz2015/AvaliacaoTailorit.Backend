using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd.Validacao;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Servicos.Comum;
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

        public Usuario Adicionar(InserirCmd comando)
        {
            Usuario usuario = null;
            int resultado = 0;

            if (ExecutarValidacao(new InserirValidacao(), comando))
            {
                FiltrarCmd filtro = new FiltrarCmd() { Nome = comando.Nome, Ativo = "true" };

                if (_rep.Filtrar(filtro)?.Count() > 0)
                    Notificar("Já existe um usuário com essas informações");
                   
                if(!HaNotificacoes())
                {
                    Sexo sexo = _sexoRep.Get(comando.Sexo);
                    if (object.Equals(sexo, null))
                        Notificar("Não foi possível localizar o sexo do usuário");

                    if (!HaNotificacoes())
                    {
                        comando.Aplicar(ref usuario, sexo);
                        resultado = _rep.Add(usuario);

                        if (resultado < 0)
                            Notificar("Não foi possível cadastrar o usuário");
                    }
                }
            }

            return usuario;
        }

        public void Dispose()
        {
            _rep?.Dispose();
            _sexoRep?.Dispose();
        }

        public Usuario[] Filtrar(FiltrarCmd comando)
        {
            Usuario[]  usuarios = _rep.Filtrar(comando);

            if (!object.Equals(usuarios, null) && usuarios.Count().Equals(0))
                Notificar("Registros não encontrados");
            

            return usuarios;
        }

        public Usuario Obter(int id)
        {
            Usuario usuario = _rep.Get(id);

            if (object.Equals(usuario, null))
                Notificar("Usuário não encontrado");
            
            return usuario;
        }
    }
}
