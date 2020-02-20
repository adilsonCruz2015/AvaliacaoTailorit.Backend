using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Servicos.Comum;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Servicos
{
    public class SexoServico : BaseService, ISexoServico
    {
        public SexoServico(INotificador notificador,
                           ISexoRep rep)
            : base(notificador)
        {
            _rep = rep;
        }

        private readonly ISexoRep _rep;

        public Sexo[] Obter()
        {
            return _rep.Get();
        }
    }
}
