using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Conexao
{
    public class Conexao
    {
        public Conexao()
        {
            _connection = Connect();
        }
        // Pega a minha connection string que esta no webConfig
        private string _connectionString => ConfigurationManager.ConnectionStrings["ProjectBancoItau"].ToString();
        private readonly SqlConnection _connection;
        private SqlCommand _command;
        // Testa a conexão com o banco se ela estiver quebrada entao fecha e abre denovo e se a conexao
        // estiver fechada abre ela
        private SqlConnection Connect()
        {
            var connection = new SqlConnection(_connectionString);

            if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        // Cria o metodo para executar procedure 
        public void ExecuteProcedure(object procName)
        {
            _command = new SqlCommand(procName.ToString(), _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        public void AddParameter(string parameterName, object parameterValue)
        {
            _command.Parameters.AddWithValue(parameterName, parameterValue);
        }

        protected void AddParameterOutput(string parameterName, object parameterValue, DbType parameterType)
        {
            _command.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.Output,
                Value = parameterValue,
                DbType = parameterType
            });
        }

        protected string GetParameterOutput(string parameter) => _command.Parameters[parameter].Value.ToString();

        // Método para executar procedure que não tem nenhum retorno (Insert,Delete,Update)
        public void ExecuteNonQuery()
        {
            _command.ExecuteNonQuery();
        }

        protected void AddParameterReturn(string parameterName = "@RETURN_VALUE", DbType parameterType = DbType.Int16)
        {
            _command.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.ReturnValue,
                DbType = parameterType
            });
        }
        // Método para executar procedure que tem retorno (Insert,Delete)
        public int ExecuteNonQueryWithReturn()
        {
            AddParameterReturn();
            _command.ExecuteNonQuery();
            return int.Parse(_command.Parameters["@RETURN_VALUE"].Value.ToString());
        }

        // Metodo exclusivo para procedure que retorna valores (Select)
        public SqlDataReader ExecuteReader()
        {
            return _command.ExecuteReader();
        }
    }

}
