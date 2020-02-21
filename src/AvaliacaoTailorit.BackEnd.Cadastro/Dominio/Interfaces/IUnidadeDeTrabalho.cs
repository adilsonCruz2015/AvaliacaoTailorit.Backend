using System;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        void IniciarTransicao();

        void SalvarAlteracoes();

        void DesfazerAlteracoes();

        bool HaAlteracoes();
    }
}
