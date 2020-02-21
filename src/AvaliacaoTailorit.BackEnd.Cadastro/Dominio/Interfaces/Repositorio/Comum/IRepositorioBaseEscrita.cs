namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepositorioBaseEscrita<TEntidade> 
        where TEntidade : class
    {
        int Insert(TEntidade obj);

        int Update(TEntidade obj);
    }
}
