using System.Collections.Generic;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepositorioBaseLeitura<TEntidade> 
        where TEntidade : class
    {
        TEntidade[] Get();

        TEntidade Get(int id);
    }
}
