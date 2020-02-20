namespace AvaliacaoTailorit.BackEnd.Data.Persistencia.Fabrica
{
    public static class ConnectionString
    {
        public static string Conexao
        {
            get { return "Data Source=(local);Initial Catalog=AvaliacaoTailorit;Integrated Security=False; User Id=sa; Password=sa;Connect Timeout=3600;Max Pool Size=36000;"; }
        }
    }
}
