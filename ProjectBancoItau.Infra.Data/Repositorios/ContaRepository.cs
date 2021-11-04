using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces;
using ProjectBancoItau.Domain.Interfaces.Repositories;
using ProjectBancoItau.Infra.Data.Repositorios;
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
    public class ContaRepository : RespositoryBase<Conta>, IContaRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["ProjectBancoItau"].ConnectionString;

        public void AtualizarConta(Conta conta)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_ContaUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@nConta", conta.NConta);
                cmd.Parameters.AddWithValue("@cDigito", conta.CDigito);
                cmd.Parameters.AddWithValue("@nAgencia", conta.NAgencia);
                cmd.Parameters.AddWithValue("@aDigito", conta.ADigito);
                cmd.Parameters.AddWithValue("@senha", conta.Senha);
                cmd.Parameters.AddWithValue("@idCliente", conta.idCliente);
                cmd.Parameters.AddWithValue("@saldo", conta.Saldo);
                
                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarSaldoConta(int idConta, decimal saldo)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_ContaUpdateSaldo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@idConta", idConta);
                cmd.Parameters.AddWithValue("@saldo", saldo);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Conta> ContasListar()
        {
            {
                //retorna lista de todos usuário CADASTRADOS
                List<Conta> Contas = new List<Conta>();
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[PBSP_ContaListar]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var conta = new Conta()
                        {
                            IdConta = Convert.ToInt32(dr["IdConta"]),
                            NConta = Convert.ToInt32(dr["nConta"]),
                            CDigito = Convert.ToInt32(dr["cDigito"]),
                            NAgencia = Convert.ToInt32(dr["nAgencia"]),
                            ADigito = Convert.ToInt32(dr["aDigito"]),
                            Senha = dr["senha"].ToString(),
                            idCliente= Convert.ToInt32(dr["idCliente"]),
                            Saldo = Convert.ToDecimal(dr["saldoCliente"])

                        };
                        Contas.Add(conta);
                    }
                    return (Contas);
                }
            }
        }

        public IEnumerable<Conta> ContaListaPorAgencia(int? nAgencia)
        {
            {
                //retorna lista de todas as contas de uma determinada agencia
                List<Conta> Contas = new List<Conta>();
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[PBSP_ContaListaPorAgencia]", con);
                    SqlParameter param = new SqlParameter();
                    cmd.Parameters.AddWithValue("@nAgencia", nAgencia);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var conta = new Conta()
                        {
                            IdConta = Convert.ToInt32(dr["IdConta"]),
                            NConta = Convert.ToInt32(dr["nConta"]),
                            CDigito = Convert.ToInt32(dr["cDigito"]),
                            NAgencia = Convert.ToInt32(dr["nAgencia"]),
                            ADigito = Convert.ToInt32(dr["aDigito"]),
                            Senha = dr["senha"].ToString(),
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            Saldo = Convert.ToDecimal(dr["saldoCliente"])

                        };
                        Contas.Add(conta);
                    }
                    return (Contas);
                }
            }
        }


        public Conta ContaListaCliente(int? idConta)
        {
            //retorna conta pelo Id
            Conta conta = new Conta();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_ContaListarPorIdConta", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@idConta", idConta);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    conta.IdConta = Convert.ToInt32(dr["IdConta"]);
                    conta.NConta = Convert.ToInt32(dr["nConta"]);
                    conta.CDigito = Convert.ToInt32(dr["cDigito"]);
                    conta.NAgencia = Convert.ToInt32(dr["nAgencia"]);
                    conta.ADigito = Convert.ToInt32(dr["aDigito"]);
                    conta.Senha = dr["Senha"].ToString();
                    conta.idCliente = Convert.ToInt32(dr["idCliente"]);
                    conta.Saldo = Convert.ToDecimal(dr["saldoCliente"]);
                }

                return conta;
            }
        }

        public Conta ContaListaClientePorNumConta(int? numConta)
        {
            //retorna conta pelo numero da conta
            Conta conta = new Conta();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_ContaListaPorNumConta", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@nConta", numConta);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    conta.IdConta = Convert.ToInt32(dr["IdConta"]);
                    conta.NConta = Convert.ToInt32(dr["nConta"]);
                    conta.CDigito = Convert.ToInt32(dr["cDigito"]);
                    conta.NAgencia = Convert.ToInt32(dr["nAgencia"]);
                    conta.ADigito = Convert.ToInt32(dr["aDigito"]);
                    conta.Senha = dr["Senha"].ToString();
                    conta.idCliente = Convert.ToInt32(dr["idCliente"]);
                    conta.Saldo = Convert.ToDecimal(dr["saldoCliente"]);
                }

                return conta;
            }
        }


        public Conta BuscaContaPeloIdCliente(int? idCliente)
        {
            //retorna conta pelo Id
            Conta conta = new Conta();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_ContaBuscaIdCliente", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    conta.IdConta = Convert.ToInt32(dr["IdConta"]);
                    conta.NConta = Convert.ToInt32(dr["nConta"]);
                    conta.CDigito = Convert.ToInt32(dr["cDigito"]);
                    conta.NAgencia = Convert.ToInt32(dr["nAgencia"]);
                    conta.ADigito = Convert.ToInt32(dr["aDigito"]);
                    conta.Senha = dr["Senha"].ToString();
                    conta.idCliente = Convert.ToInt32(dr["idCliente"]);
                    conta.Saldo = Convert.ToDecimal(dr["saldoCliente"]);
                }

                return conta;
            }
        }

        public Conta ContaListaClienteNumeroContaAgencia(int? numeroConta, int? numeroAgencia)
        {
            //retorna usuário pelo Id
            Conta conta = new Conta();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_ListaClientePeloNumeroConta", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@nConta", numeroConta);
                cmd.Parameters.AddWithValue("@nAgencia", numeroAgencia);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    conta.idCliente = Convert.ToInt32(dr["idCliente"]);
                    conta.IdConta = Convert.ToInt32(dr["IdConta"]);
                    conta.NConta = Convert.ToInt32(dr["nConta"]);
                    conta.CDigito = Convert.ToInt32(dr["cDigito"]);
                    conta.NAgencia = Convert.ToInt32(dr["nAgencia"]);
                    conta.ADigito = Convert.ToInt32(dr["aDigito"]);
                    conta.Saldo = Convert.ToDecimal(dr["saldoCliente"]);
                    conta.Senha = dr["Senha"].ToString();
                    
                    conta.Saldo = Convert.ToDecimal(dr["saldoCliente"]);
                }

                return conta;
            }
        }


        public void DeletarConta(Conta conta)
        {
            //retorna usuário pelo Id
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_ContaDeletar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@idconta", conta.IdConta);
                cmd.ExecuteNonQuery();

            }
        }

        public void InserirConta(Conta conta) 
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_ContaInserir", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nConta", conta.NConta);
                cmd.Parameters.AddWithValue("@cDigito", conta.CDigito);
                cmd.Parameters.AddWithValue("@nAgencia", conta.NAgencia);
                cmd.Parameters.AddWithValue("@aDigito", conta.ADigito);
                cmd.Parameters.AddWithValue("@senha", conta.Senha);
                cmd.Parameters.AddWithValue("@idCliente", conta.idCliente);
                cmd.Parameters.AddWithValue("@saldo", conta.Saldo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

