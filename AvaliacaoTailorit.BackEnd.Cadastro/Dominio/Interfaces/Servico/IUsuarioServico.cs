using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico
{
    public interface IUsuarioServico : IDisposable
    {
        Task Adicionar(InserirCmd comando);

        Task<IEnumerable<Usuario>> Obtertodos();

        Task<IEnumerable<Usuario>> Filtrar(FiltrarCmd comando);
    }
}
