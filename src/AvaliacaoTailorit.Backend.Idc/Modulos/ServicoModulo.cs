using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Servicos;
using SimpleInjector;

namespace AvaliacaoTailorit.Backend.Idc.Modulos
{
    public static class ServicoModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IUsuarioServico, UsuarioServico>(Lifestyle.Scoped);
            recipiente.Register<ISexoServico, SexoServico>(Lifestyle.Scoped);
        }
    }
}
