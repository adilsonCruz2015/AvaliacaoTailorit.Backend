using AvaliacaoTailorit.Backend.Idc.Modulos;
using SimpleInjector;

namespace AvaliacaoTailorit.Backend.Idc
{
    public static class IdC
    {
        public static void Carregar(Container recipiente)
        {
            ServicoModulo.Carregar(recipiente);
            RepositorioModulo.Carregar(recipiente);
        }
    }
}
