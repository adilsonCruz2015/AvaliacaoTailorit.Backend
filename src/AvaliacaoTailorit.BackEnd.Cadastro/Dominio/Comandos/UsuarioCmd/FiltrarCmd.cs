using System;
using System.Collections.Generic;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd
{
    public class FiltrarCmd
    {
        public FiltrarCmd()
        {
            Nomes = new List<string>();
            DataNascimentos = new List<DateTime>();
            Emails = new List<string>();
            Sexos = new List<int>();
        }

        public List<string> Nomes { get; set; }

        public List<DateTime> DataNascimentos { get; set; }

        public List<string> Emails { get; set; }        

        public List<int> Sexos { get; set; }
    }
}
