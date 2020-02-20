using System;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepository<TEntity> : IDisposable
    {
        TEntity Get(int id);        

        int Add(TEntity entity);             
    }
}
