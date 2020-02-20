using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Fabrica;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AvaliacaoTailorit.BackEnd.Data.Persistencia.Repositorios
{
    public class UsuarioRep : IUsuarioRep
    {
        public int Add(Usuario entity)
        {
            StringBuilder sql = new StringBuilder();
            int resultado = -1;

            sql.Append($@"
                         INSERT INTO { nameof(Usuario) } (Nome, DataNascimento, Email, Senha, Ativo, SexoId)
                                VALUES(@Nome, @DataNascimento, @Email, @Senha, @Ativo, @SexoId)");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
            {
                try
                {
                    var parametros = new DynamicParameters(new { entity.Sexo.SexoId });

                    parametros.Add("@Nome", entity.Nome, DbType.AnsiString, size: 200);
                    parametros.Add("@DataNascimento", entity.DataNascimento, DbType.DateTime);
                    parametros.Add("@Email", entity.Email, DbType.AnsiString, size: 100);
                    parametros.Add("@Senha", entity.Senha, DbType.AnsiString, size: 30);
                    parametros.Add("@Ativo", entity.Ativo, DbType.Boolean);

                    resultado = conn.Execute(sql.ToString(), parametros);
                }
                catch (SqlException) {  }
            }

            return resultado;
        }

        public void Dispose() { }

        public Usuario[] Filtrar(FiltrarCmd comando)
        {
            Usuario[] resultado = new Usuario[] { };
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlFiltro = new StringBuilder();
            var parametros = new DynamicParameters();

            sql.Append($@"SELECT 
                        U.UsuarioId,
                        U.Nome,
                        U.DataNascimento,
                        U.Email,
                        U.Ativo,
                        S.SexoId,
                        S.Descricao
                        FROM { nameof(Usuario)} AS U ");
            sql.Append($" INNER JOIN { nameof(Sexo)} As S On S.SexoId = U.SexoId ");

            if (!string.IsNullOrEmpty(comando.Nome))
            {
                sqlFiltro.Append(" AND U.Nome LIKE CONCAT('%',@Nome,'%'); ");
                parametros.Add("@Nome", comando.Nome, DbType.AnsiString, size: 200);
            }

            if (!object.Equals(comando.Ativo, null))
            {
                sqlFiltro.Append(" AND U.Ativo = @Ativo  ");
                parametros.Add("@Ativo", comando.Ativo, DbType.Boolean);
            }

            sql.Append(Regex.Replace(sqlFiltro.ToString(), @"^ AND ", " WHERE "));

            using (var conn = new SqlConnection(ConnectionString.Conexao))
            {
                resultado = conn.Query<Usuario, Sexo, Usuario>(sql.ToString(),
                    (usuario, sexo) => { usuario.Sexo = sexo; return usuario; }, new
                    {
                        comando.Nome,
                        comando.Ativo
                    }, splitOn: "UsuarioId, SexoId").ToArray();
            }

            return resultado;
        }

        public Usuario Get(int id)
        {
            Usuario resultado = null;
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlFiltro = new StringBuilder();
            var parametros = new DynamicParameters();

            sql.Append($@"SELECT 
                        U.UsuarioId,
                        U.Nome,
                        U.DataNascimento,
                        U.Email,
                        U.Ativo,
                        S.SexoId,
                        S.Descricao
                        FROM { nameof(Usuario)} AS U ");
            sql.Append($" INNER JOIN { nameof(Sexo)} As S On S.SexoId = U.SexoId ");
            sql.Append(" WHERE U.UsuarioId = @UsuarioId  ");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
                resultado = conn.Query<Usuario>(sql.ToString(), new {  id }).FirstOrDefault();

            return resultado;
        }
    }
}
