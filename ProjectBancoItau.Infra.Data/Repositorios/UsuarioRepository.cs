using ProjectBancoItau.Domain.Conexao;
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
    public class UsuarioRepository : RespositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["ProjectBancoItau"].ConnectionString;

        public void AtualizarUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_UsuarioUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@gerente", usuario.Gerente);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Usuario> BuscaTodosUsuarios()
        {
            {
                //retorna lista de todos usuário CADASTRADOS
                List<Usuario> Usuarios = new List<Usuario>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[PBSP_ListaUsuarios]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var usuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Login = dr["Login"].ToString(),
                            Gerente = Convert.ToBoolean(dr["Gerente"]),
                            Senha = dr["Senha"].ToString()
                        };
                        Usuarios.Add(usuario);
                    }
                    return (Usuarios);
                }
            }
        }

        public IEnumerable<Usuario> BuscaTodosUsuariosGerentes()
        {
            //retorna lista de todos usuário GERENTE
            List<Usuario> UsuariosGerentes = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[PBSP_SelectUsuarioGerente]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Login = dr["Login"].ToString(),
                        Gerente = Convert.ToBoolean(dr["Gerente"]),
                        Senha = dr["Senha"].ToString()
                    };
                    UsuariosGerentes.Add(usuario);
                }
                return (UsuariosGerentes);
            }
        }

        public Usuario BuscaUsuarioPorID(int?  idUsuario)
        {
            //retorna usuário pelo Id
            Usuario usuario = new Usuario();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_SelectUsuarioID", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@idUser", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.Login = dr["Login"].ToString();
                    usuario.Gerente = Convert.ToBoolean(dr["Gerente"]);
                    usuario.Senha = dr["Senha"].ToString();
                }

                return usuario;
            }
        }

        public Usuario ListaUsuarioPorLogin(string login)
        {
            //retorna usuário pelo Login
            Usuario usuario = new Usuario();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("PBSP_UsuarioListaPorLogin", con);

                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@login", login);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.Login = dr["Login"].ToString();
                    usuario.Gerente = Convert.ToBoolean(dr["Gerente"]);
                    usuario.Senha = dr["Senha"].ToString();
                }

                return usuario;
            }
        }




        public void DeletarUsuario(Usuario usuario)
        {
            //retorna usuário pelo Id
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_DeletarUsuarioId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@idUser", usuario.IdUsuario);
                cmd.ExecuteNonQuery();

            }
        }

        public void InserirUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("PBSP_InsertUsuario", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@gerente", usuario.Gerente);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
