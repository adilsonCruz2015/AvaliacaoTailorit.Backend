using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;

namespace AvaliacaoTailorit.BackEnd.Data.Persistencia.Interfaces
{
    public interface IResolverConexao
    {
        string ObterReferencia(string nome);

        string ObterConexao(Banco banco);
    }
}
