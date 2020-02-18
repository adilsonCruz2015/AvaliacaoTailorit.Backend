using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using System;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades
{
    public class Usuario 
    {
        protected Usuario()
        {
            Status = true;
        }

        public Usuario(string nome,
                       DateTime dataNascimento,
                       string email,
                       string senha,
                       Sexo sexo)
            :this()
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Senha = senha;
            Sexo = sexo;
        }

        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public Sexo Sexo { get; set; }

        public bool Status { get; set; }
    }
}
