using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio
{
    public interface ISexoRep : IRepositorioBaseEscrita<Sexo>, 
                                IRepositorioBaseLeitura<Sexo>
    {
        Sexo[] Get();
    }
}
