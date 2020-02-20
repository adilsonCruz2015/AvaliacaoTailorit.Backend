using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Fabrica;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AvaliacaoTailorit.BackEnd.Data.Persistencia.Repositorios
{
    public class SexoRep : ISexoRep
    {
        public int Add(Sexo entity)
        {
            StringBuilder sql = new StringBuilder();
            int resultado = -1;

            sql.Append($@"
                         INSERT INTO { nameof(Sexo) } (Descricao)
                                VALUES(@Descricao)");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
            { 
                try
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@Descricao", entity.Descricao, DbType.AnsiString, size: 15);

                    resultado =  conn.Execute(sql.ToString(), parametros);
                }
                catch(SqlException)
                {
                    
                }
            }

            return resultado;
        }

        public void Dispose() {  }

        public Sexo Get(int id)
        {
            StringBuilder sql = new StringBuilder();
            Sexo sexo = null;

            sql.Append($@"SELECT 
                        SexoId,
                        Descricao 
                        FROM { nameof(Sexo) } 
                        WHERE SexoId = @SexoId");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
                sexo = conn.Query<Sexo>(sql.ToString(), new { SexoId = id }).FirstOrDefault();

            return sexo;
        }

        public Sexo[] Get()
        {
            StringBuilder sql = new StringBuilder();
            Sexo[] sexos = null;

            sql.Append($@"SELECT 
                        SexoId,
                        Descricao 
                        FROM { nameof(Sexo) }");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
                sexos = conn.Query<Sexo>(sql.ToString(), new { }).ToArray();

            return sexos;
        }
    }
}
