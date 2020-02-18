using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Notificacoes;
using System.Collections.Generic;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
