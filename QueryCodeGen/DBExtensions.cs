using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QueryCodeGen

{

    public static class DBEXtensions
    {
        public static IDbTransaction BeginTran(this IDbConnection conn)
        {
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            return conn.BeginTransaction();
        }
        
        private static void setParamsFromKeyValuePair(this IDbCommand command, List<KeyValuePair<string, object>> parameters)
        {
            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    var param = command.CreateParameter();
                    param.ParameterName = pair.Key;
                    param.Value = pair.Value;
                    command.Parameters.Add(param);
                }
            }
        }

        private static IDbCommand GetCommand(this IDbConnection conn, string commandText, List<KeyValuePair<string, object>> parameters, int commandTimeout, CommandType commandType, IDbTransaction tran = null)
        {
            if (conn.State != ConnectionState.Open) { conn.Open(); }

            var command = conn.CreateCommand();
            command.CommandText = commandText;
            command.setParamsFromKeyValuePair(parameters);
            command.CommandTimeout = commandTimeout;
            command.CommandType = commandType;
            command.Transaction = tran;                    
            return command;
        }

        public static int ExecuteCommand(this IDbConnection conn, string commandText, List<KeyValuePair<string, object>> parameters = null, IDbTransaction tran = null, int commandTimeout = 300, CommandType commandType = CommandType.Text)
        {
            IDbCommand command = conn.GetCommand(commandText, parameters, commandTimeout, commandType, tran);
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        public static IDataReader GetDataReader(this IDbConnection conn, string commandText, List<KeyValuePair<string, object>> parameters = null, System.Data.IDbTransaction transaction = null, int commandTimeout = 300, CommandType commandType = CommandType.Text, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            IDbCommand command = conn.GetCommand(commandText, parameters, commandTimeout, commandType);
            var reader = command.ExecuteReader(commandBehavior);
            return reader;
        }

        public static DataTable GetDataTable(this IDbConnection conn, string commandText, List<KeyValuePair<string, object>> parameters = null, System.Data.IDbTransaction transaction = null, int commandTimeout = 300, CommandType commandType = CommandType.Text, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            IDbCommand command = conn.GetCommand(commandText, parameters, commandTimeout, commandType);
            var reader = command.ExecuteReader(commandBehavior);
            return reader.GetDataTable();
        }

        public static DataTable GetDataTable(this IDataReader reader) {
            var set = new DataSet();
            var table = new DataTable();
            set.Tables.Add(table);
            set.EnforceConstraints = false;
            table.Load(reader);
            reader.Close();
            return table;
        }

    }

}
