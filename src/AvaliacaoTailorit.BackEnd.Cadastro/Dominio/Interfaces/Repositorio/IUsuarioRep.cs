using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio
{
    public interface IUsuarioRep : IRepository<Usuario> 
    {
        Task<IEnumerable<Usuario>> Filtrar(FiltrarCmd comando);
    }
}
