using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio
{
    public interface IUsuarioRep : IRepository<Usuario> 
    {
        Usuario[] Filtrar(FiltrarCmd comando);
    }
}
