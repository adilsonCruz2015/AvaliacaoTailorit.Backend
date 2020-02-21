using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Interfaces;
using System;

namespace AvaliacaoTailorit.BackEnd.Data.Persistencia.Contexto
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        public UnidadeDeTrabalho(IConexao conexao)
        {
            _conexao = conexao;
        }

        private readonly IConexao _conexao;

        public void DesfazerAlteracoes()
        {
            _conexao.DesfazerTransicao();
        }

        public void Dispose()
        {
            if (_conexao.HaSessao() && _conexao.HaTransicao())
                SalvarAlteracoes();

            _conexao.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool HaAlteracoes()
        {
            return _conexao.HaTransicao();
        }

        public void IniciarTransicao()
        {
            _conexao.IniciarTransicao();
        }

        public void SalvarAlteracoes()
        {
            _conexao.FecharTransicao();
        }
    }
}
