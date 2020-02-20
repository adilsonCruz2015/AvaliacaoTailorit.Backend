using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio
{
    public interface ISexoRep : IRepository<Sexo> 
    {
        Sexo[] Get();
    }
}
