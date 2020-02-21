using AvaliacaoTailorit.BackEnd.Data.Persistencia.Contexto;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Interfaces;
using SimpleInjector;

namespace AvaliacaoTailorit.Backend.Idc.Modulos
{
    public static class InfraestruturaModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IConexao, Conexao>(Lifestyle.Scoped);
        }
    }
}
