using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Infra.Data.Repositorios
{
    public class TransacaoRepository : RespositoryBase<Transacao>, ITransacaoRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["ProjectBancoItau"].ConnectionString;

        public void AtualizarTransacao(Transacao transacao)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_TransacaoUpdateId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@nome", transacao.Nome);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Transacao> BuscaTodosTransacaos()
        {

            {
                //retorna lista de todos usuário CADASTRADOS
                List<Transacao> Transacaos = new List<Transacao>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[PBSP_TransacaoSelectAll]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var transacao = new Transacao()
                        {
                            IdTransacao = Convert.ToInt32(dr["idTransacao"]),
                            Nome = dr["Nome"].ToString()
                        };
                        Transacaos.Add(transacao);
                    }
                    return (Transacaos);
                }
            }
        }



        public void DeletarTransacao(Transacao transacao)
        {
            //retorna usuário pelo Id
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_TransacaoDeleteId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@idTransacao", transacao.IdTransacao);
                cmd.ExecuteNonQuery();

            }
        }

        public void InserirTransacao(Transacao transacao)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_TransacaoInsert", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", transacao.Nome);
                cmd.ExecuteNonQuery();
            }
        }

        public Transacao BuscaTransacaoPorId(int id)
        {
            //retorna Transacao pelo Id
            Transacao transacao = new Transacao();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("[PBSP_TransacaoSelectId]", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@idTransacao", id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    transacao.IdTransacao = Convert.ToInt32(dr["idTransacao"]);
                    transacao.Nome = dr["Nome"].ToString();
                }

                return transacao;
            }
        }
    }
}
