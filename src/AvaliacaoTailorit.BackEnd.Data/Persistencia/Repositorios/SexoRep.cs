using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades.ObjetoDeValor;
using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Interfaces;
using Dapper;
using System.Data;
using System.Linq;

namespace AvaliacaoTailorit.BackEnd.Data.Persistencia.Repositorios
{
    public class SexoRep : ISexoRep
    {
        public SexoRep(IConexao conexao)
        {
            _conexao = conexao;
            _conexao.InformarBanco(Banco.AvaliacaoTailorit);
        }

        private readonly IConexao _conexao;

        public Sexo[] Get()
        {
            return  _conexao.Sessao.Query<Sexo>(
                              $@"SELECT 
                                      SexoId,
                                      Descricao 
                                FROM { nameof(Sexo) }", 
                                new { }, 
                                _conexao.Transicao).ToArray();
        }

        public Sexo Get(int id)
        {
            return _conexao.Sessao.Query<Sexo>(
                     $@"SELECT 
                          SexoId,
                          Descricao 
                        FROM { nameof(Sexo) } 
                        WHERE SexoId = @SexoId", 
                     new { SexoId = id },
                     _conexao.Transicao
                     ).FirstOrDefault();
        }

        public int Insert(Sexo obj)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@Descricao", 
                            obj.Descricao, 
                            DbType.AnsiString, 
                            size: 15);

            return  _conexao.Sessao.Execute($@" INSERT INTO { nameof(Sexo) } (Descricao) 
                                                       VALUES(@Descricao)", 
                                            parametros, 
                                            _conexao.Transicao);
        }

        public int Update(Sexo obj)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@Descricao",
                            obj.Descricao,
                            DbType.AnsiString,
                            size: 15);

            return _conexao.Sessao.Execute($@"UPDATE { nameof(Sexo)} 
                                                SET Descricao = @Descricao WHERE SexoId = @SexoId",
                                                new { obj.SexoId },
                                                _conexao.Transicao);
        }
    }
}
