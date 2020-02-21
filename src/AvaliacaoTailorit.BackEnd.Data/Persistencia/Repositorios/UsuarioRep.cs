using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Fabrica;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Interfaces;
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
        public UsuarioRep(IConexao conexao)
        {
            _conexao = conexao;
            _conexao.InformarBanco(Banco.AvaliacaoTailorit);
        }

        private readonly IConexao _conexao;

        public Usuario[] Filtrar(FiltrarCmd comando)
        {
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
                sqlFiltro.Append(" AND U.Nome LIKE CONCAT('%',@Nome,'%') ");
                parametros.Add("@Nome", comando.Nome, DbType.AnsiString, size: 200);
            }

            if (!object.Equals(comando.Ativo, null))
            {
                sqlFiltro.Append(" AND U.Ativo = @Ativo  ");
                parametros.Add("@Ativo", comando.Ativo, DbType.Boolean);
            }

            sql.Append(Regex.Replace(sqlFiltro.ToString(), @"^ AND ", " WHERE "));

            try
            {
                return _conexao.Sessao.Query<Usuario, Sexo, Usuario>(sql.ToString(),
                               (usuario, sexo) =>
                               {
                                   usuario.Sexo = sexo;
                                   return usuario;
                               },
                               new
                               {
                                   comando.Nome,
                                   comando.Ativo
                               }, _conexao.Transicao,
                                    splitOn: "UsuarioId, SexoId").ToArray();
            }
            catch(SqlException ex) { return null; }
        }

        public Usuario[] Get()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"SELECT 
                        U.UsuarioId,
                        U.Nome,
                        U.DataNascimento,
                        U.Email,
                        U.Ativo,
                        U.SexoId
                        FROM { nameof(Usuario)} AS U ");

            return _conexao.Sessao.Query<Usuario>(
                          sql.ToString(), 
                          new { }, 
                          _conexao.Transicao).ToArray();
        }

        public Usuario Get(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"SELECT 
                        U.UsuarioId,
                        U.Nome,
                        U.DataNascimento,
                        U.Email,
                        U.Ativo,
                        U.SexoId
                        FROM { nameof(Usuario)} AS U ");

            return _conexao.Sessao.Query<Usuario>(
                          sql.ToString(),
                          new { UsuarioId = id },
                          _conexao.Transicao).FirstOrDefault();
        }

        public int Insert(Usuario obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"
                         INSERT INTO { nameof(Usuario) } (Nome, DataNascimento, Email, Senha, Ativo, SexoId)
                                VALUES(@Nome, @DataNascimento, @Email, @Senha, @Ativo, @SexoId)");

            var parametros = new DynamicParameters(new { obj.Sexo.SexoId });

            parametros.Add("@Nome", obj.Nome, DbType.AnsiString, size: 200);
            parametros.Add("@DataNascimento", obj.DataNascimento, DbType.DateTime);
            parametros.Add("@Email", obj.Email, DbType.AnsiString, size: 100);
            parametros.Add("@Senha", obj.Senha, DbType.AnsiString, size: 30);
            parametros.Add("@Ativo", obj.Ativo, DbType.Boolean);

            return _conexao.Sessao.Execute(sql.ToString(), parametros, _conexao.Transicao);
        }

        public int Update(Usuario obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"
                         UPDATE { nameof(Usuario) } SET  Nome = @Nome, 
                                                         DataNascimento = @DataNascimento,
                                                         Email = @Email, 
                                                         Ativo = @Ativo, 
                                                         SexoId = @SexoId
                                                    WHERE UsuarioId = @UsuarioId");

            var parametros = new DynamicParameters(new 
            { 
                obj.UsuarioId,
                obj.Sexo.SexoId 
            });

            parametros.Add("@Nome", obj.Nome, DbType.AnsiString, size: 200);
            parametros.Add("@DataNascimento", obj.DataNascimento, DbType.DateTime);
            parametros.Add("@Email", obj.Email, DbType.AnsiString, size: 100);
            parametros.Add("@Senha", obj.Senha, DbType.AnsiString, size: 30);
            parametros.Add("@Ativo", obj.Ativo, DbType.Boolean);

            return _conexao.Sessao.Execute(sql.ToString(), parametros, _conexao.Transicao);
        }
    }
}
