using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Interfaces;
using System.Collections.Generic;
using System.Configuration;

namespace AvaliacaoTailorit.Backend.Api.Auxiliar
{
    public class ResolverConexao : IResolverConexao
    {
        private IDictionary<Banco, string> _resultado = new Dictionary<Banco, string>()
        {
            {Banco.AvaliacaoTailorit, "AvaliacaoTailorit" }
        };

        public string ObterConexao(Banco banco)
        {
            return ObterReferencia(ObterNomeDaConnectionString(banco));
        }

        public string ObterReferencia(string nome)
        {
            return ConfigurationManager.ConnectionStrings[nome].ToString();
        }

        private string ObterNomeDaConnectionString(Banco banco)
        {
            return _resultado[banco];
        }
    }
}