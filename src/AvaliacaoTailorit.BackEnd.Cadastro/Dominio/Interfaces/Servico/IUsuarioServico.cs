using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using System;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Servico
{
    public interface IUsuarioServico 
    {
        Usuario Adicionar(InserirCmd comando);

        Usuario Obter(int id);

        Usuario[] Filtrar(FiltrarCmd comando);
    }
}
