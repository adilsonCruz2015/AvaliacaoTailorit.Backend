
namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor
{
    public class Sexo
    {
        public Sexo(string descricao)
        {
            Descricao = descricao;
        }

        public int SexoId { get; private set; }

        public string Descricao { get; private set; }
    }
}
