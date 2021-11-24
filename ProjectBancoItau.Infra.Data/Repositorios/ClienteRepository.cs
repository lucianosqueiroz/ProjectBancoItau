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
    public class ClienteRepository : IClienteRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["ProjectBancoItau"].ConnectionString;

        public void AtualizarCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_ClienteUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente ListaClienteNome(string nomeClienteConta)
        {
            //retorna cliente pelo nome do cliente
            Cliente cliente = new Cliente();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_ClienteListaNome", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@nome", nomeClienteConta);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                    cliente.Cpf = dr["Cpf"].ToString();
                    cliente.Nome = dr["Nome"].ToString();
                }
                return cliente;
            }
        }
        public IEnumerable<Cliente> BuscaTodosClientes()
        {

            {
                //retorna lista de todos usuário CADASTRADOS
                List<Cliente> Clientes = new List<Cliente>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[PBSP_ListaClientes]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var cliente = new Cliente()
                        {
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            Cpf = dr["Cpf"].ToString(),
                            Nome = dr["Nome"].ToString()
                        };
                        Clientes.Add(cliente);
                    }
                    return (Clientes);
                }
            }
        }



        public Cliente BuscaClientePorCPF(string cpfCliente)
        {
            //retorna Cliente pelo Cpf
            Cliente cliente = new Cliente();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("[PBSP_ClientePeloCPF]", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@cpfCliente", cpfCliente);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                    cliente.Cpf = dr["Cpf"].ToString();
                    cliente.Nome = dr["Nome"].ToString();
                }

                return cliente;
            }
        }



        public void DeletarCliente(Cliente cliente)
        {
            //retorna usuário pelo Id
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_DeletarClienteCPF", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@cpfCliente", cliente.Cpf);
                cmd.ExecuteNonQuery();

            }
        }

        public void InserirCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_ClienteInserir", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente BuscaClientePorId(int id)
        {
            //retorna Cliente pelo Id
            Cliente cliente = new Cliente();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("[PBSP_ClientePorId]", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@idCliente", id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                    cliente.Cpf = dr["Cpf"].ToString();
                    cliente.Nome = dr["Nome"].ToString();
                    cliente.Email = dr["Email"].ToString();
                }

                return cliente;
            }

        }

        

    }
}
