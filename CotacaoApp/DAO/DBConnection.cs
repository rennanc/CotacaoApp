using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CotacaoApp.DAO
{
    public class DBConnection : IDisposable
    {

        #region Declaracao de Variaveis globais
        private bool _State;                // Indica ULTIMO Status da conexão
        private string _ErrorMessage;       // Indica ULTIMO Mensagem de Erro da conexao
        private int _ErrorNumber;           // Indica ULTIMO Numero de Erro da conexao
        private bool _CompleteCommand;      // Indica ULTIMO comando foi executado com sucesso
        private MySqlDataReader _rsData;      // Usado para retornar colecao de registros
        private MySqlConnection _Connection; // Representa a conexão com banco de dados

        #endregion

        public DBConnection()
        {
            _Connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            _Connection.Open();
        }

        public QuerySql CreateQuery(String sql)
        {
            return new QuerySql(sql, _Connection);
        }

        public void Close()
        {
            _Connection.Close();
        }

        #region Definicao de Metodos
        public void ExecuteCommand(string myConnectionName, string myQueryString)
        {
            // Metodo responsavel por executar uma instrução SQL
            // Recebe como parametro o nome de uma chave do arquivo web.config que contem string de conexão e
            // a instrução SQL a ser executada pode ser um SELECT ou uma procedure (preferencialmente)
            // Utililizo Tray..Catch para tratamento de erro
            try
            {
                // Definir valores padrões das variaveis
                _ErrorMessage = "";
                _State = false;

                // Se nao for passado nenhuma chave de conexão do arquivo web.config
                // vou setar uma chave padrao de conexão do arquivo Web.Config
                if (myConnectionName.Length == 0)
                { // Aqui estou indicando o nome da chave que contem a string de conexão no arquivo 
                    myConnectionName = "Connection_Developer";
                }

                string myConnectionString = ConfigurationManager.ConnectionStrings[myConnectionName].ConnectionString.ToString();

                // Se não for informado comando T-SQL retorno error
                if (myQueryString.Length > 0)
                {
                    // Inicio de Conexão com o banco de Dados
                    MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                    //Abrindo Conexão
                    myConnection.Open();

                    // Iniciar um comando
                    MySqlCommand myCommand = new MySqlCommand(myQueryString, myConnection);

                    //Executando um comando com ExecuteReader, pois este retorna dados a um SqlDataReader
                    _rsData = myCommand.ExecuteReader(); //Executa comando
                    _State = true;                       //Indica status da Operação
                    _CompleteCommand = true;
                }
            }
            catch (Exception ex)
            {
                //Caso de excessão desconhecida
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }
        }

        public void Dispose()
        {
            _rsData.Close();
            _Connection.Close();
        }

        public MySqlDataReader RecordSet
        {
            //Metodo para ler Registros
            get { return _rsData; }
        }

        public int ErrorNumber
        {
            //Metodo para ler ultimo codigo com erro
            get { return _ErrorNumber; }
        }

        public string ErrorDescription
        {
            //Metodo para ler a descrição do ultimo erro
            get { return _ErrorMessage; }
        }

        public bool ConnectionState
        {
            // Metodo para let ultimo status da conexao
            get { return _State; }
        }

        public bool CompleteCommand
        {
            //Metodo para ler status do ultimo comando executado
            get { return _CompleteCommand; }
        }
        #endregion
    }

    public class QuerySql
    {
        private MySqlCommand _Command;
        //private string _Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();


        public QuerySql(string sql, MySqlConnection connection)
        {
            _Command = new MySqlCommand(sql, connection);
            _Command.CommandText = sql + ";";
        }
        public void ExecuteUpdate()
        {
            _Command.ExecuteNonQuery();
        }
        public DbDataReader ExecuteQuery()
        {
            return _Command.ExecuteReader();
        }
        public QuerySql SetParameter(String nome, object valor)
        {
            _Command.Parameters.AddWithValue("@" + nome, valor);
            return this;
        }
    }

    public static class DataReaderExtensions
    {
        public static string GetStringOrNull(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static string GetStringOrNull(this IDataReader reader, string columnName)
        {
            return reader.GetStringOrNull(reader.GetOrdinal(columnName));
        }
    }
}