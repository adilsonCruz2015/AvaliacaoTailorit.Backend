using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using System;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd
{
    public class InserirCmd
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int Sexo { get; set; }

        public void Aplicar(ref Usuario usuario, Sexo sexo)
        {
            usuario = new Usuario(Nome, DataNascimento, Email, Senha, sexo);
        }
    }
}
