using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Notificacoes;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace AvaliacaoTailorit.Backend.Api
{
    public class IdCConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            Idc.IdC.Carregar(container);
            container.RegisterWebApiControllers(config);

            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}