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
    public class LogTransacaoRepository : ILogTransacaoRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["ProjectBancoItau"].ConnectionString;

        public void AtualizarLogTransacao(LogTransacao logTransacao)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_LogTransacaoUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@idConta", logTransacao.IdConta);
                cmd.Parameters.AddWithValue("@idCliente", logTransacao.IdCliente);
                cmd.Parameters.AddWithValue("@valorTrans", logTransacao.ValorTrans);
                cmd.Parameters.AddWithValue("@dataTrans", logTransacao.DataTrans);
                cmd.Parameters.AddWithValue("@idTrans", logTransacao.IdTrans);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<LogTransacao> LogTransacaosListar()
        {
            {
                //retorna lista de todos usuário CADASTRADOS
                List<LogTransacao> LogTransacoes = new List<LogTransacao>();
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[PBSP_LogTransacaoListar]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var logTransacao = new LogTransacao()
                        {
                            IdLogTransacao = Convert.ToInt32(dr["idLogTrans"]),
                            IdTrans = Convert.ToInt32(dr["idTrans"]),
                            IdConta = Convert.ToInt32(dr["idConta"]),
                            IdCliente = Convert.ToInt32(dr["idCliente"]),
                            ValorTrans = Convert.ToDecimal(dr["valorTrans"]),
                            DataTrans = Convert.ToDateTime(dr["dataTrans"])

                        };
                        LogTransacoes.Add(logTransacao);
                    }
                    return (LogTransacoes);
                }
            }
        }
        public IEnumerable<LogTransacao> ExtratoResumido(int? idCliente, int? idConta, int? idTrans, DateTime dataInicial, DateTime dataFinal)
            //ExtratoFiltrado por operação
        {
            {
                String dataInicialString = dataInicial.ToString("yyyy-MM-dd");
                String dataFinalString = dataFinal.ToString("yyyy-MM-dd");

                List<LogTransacao> LogTransacoes = new List<LogTransacao>();
                using (SqlConnection con = new SqlConnection(CS))
                {


                    SqlCommand cmd = new SqlCommand("[dbo].[PBSP_LogTransacaoExtratoResumido]", con);
                    SqlParameter param = new SqlParameter();
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idConta", idConta);
                    cmd.Parameters.AddWithValue("@idTrans", idTrans);
                    cmd.Parameters.AddWithValue("@dataInicial",dataInicialString);
                    cmd.Parameters.AddWithValue("@dataFinal", dataFinalString);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var logTransacao = new LogTransacao()
                        {
                            IdLogTransacao = Convert.ToInt32(dr["idLogTrans"]),
                            IdCliente = Convert.ToInt32(dr["idCliente"]),
                            IdConta = Convert.ToInt32(dr["idConta"]),
                            IdTrans = Convert.ToInt32(dr["idTrans"]),
                            ValorTrans = Convert.ToDecimal(dr["valorTrans"]),
                            DataTrans = Convert.ToDateTime(dr["dataTrans"])

                        };
                        LogTransacoes.Add(logTransacao);
                    }
                    return (LogTransacoes);
                }
            }
        }

        public LogTransacao LogTransacaoListaConta(int? idConta)
        {
            //retorna usuário pelo Id
            LogTransacao logTransacao = new LogTransacao();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_LogTransacaoListarIdConta", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@idConta", idConta);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    logTransacao.IdLogTransacao = Convert.ToInt32(dr["idLogTrans"]);
                    logTransacao.IdTrans = Convert.ToInt32(dr["idTrans"]);
                    logTransacao.IdConta = Convert.ToInt32(dr["idConta"]);
                    logTransacao.IdCliente = Convert.ToInt32(dr["idCliente"]);
                    logTransacao.ValorTrans = Convert.ToDecimal(dr["valorTrans"]);
                    logTransacao.DataTrans = Convert.ToDateTime(dr["dataTrans"]);

                }

                return logTransacao;
            }
        }



        public void DeletarLogTransacao(LogTransacao logTransacao)
        {
            //deleta registro na tabela logTransacao pelo Id
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_LogTransacaoDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@idLogTrans", logTransacao.IdLogTransacao);
                cmd.ExecuteNonQuery();

            }
        }

        public void InserirLogTransacao(LogTransacao logTransacao)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_LogTransacaoInsert", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTrans", logTransacao.IdTrans);
                cmd.Parameters.AddWithValue("@idConta", logTransacao.IdConta);
                cmd.Parameters.AddWithValue("@idCliente", logTransacao.IdCliente);
                cmd.Parameters.AddWithValue("@valorTrans", logTransacao.ValorTrans);
                cmd.Parameters.AddWithValue("@dataTrans", logTransacao.DataTrans);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
