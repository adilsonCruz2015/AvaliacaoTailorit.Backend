
namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor
{
    public class Sexo
    {
        public Sexo(int sexoId, string descricao)
        {
            Descricao = descricao;
            SexoId = sexoId;
        }

        public Sexo(string descricao)
            :this(0, descricao) { }

        public int SexoId { get; private set; }

        public string Descricao { get; private set; }
    }
}
