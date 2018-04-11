/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

using System;
using QueryCodeGen;
using System.Data;
using System.Data.Odbc;


namespace QueryCodeGen.Service
{
    class ODBCSchemaService : ISchemaService
    {
        private string _schemaServiceName = "ODBC Schema Service";
        string ISchemaService.SchemaServiceName => _schemaServiceName;
                
        private System.Data.Odbc.OdbcConnection getConnection(string connString) {
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(connString);
            return conn;
        }

        public System.Data.DataTable getTableSchema(string connString, string query) {

            IDbConnection conn = new OdbcConnection();
            conn.ConnectionString = connString;
            conn.Open();
            //DataTable table = conn.GetDataTable(commandText: query, commandBehavior: System.Data.CommandBehavior.SchemaOnly);
            IDataReader reader = conn.GetDataReader(commandText: query, commandBehavior: CommandBehavior.SchemaOnly);
            DataTable schemaTable = reader.GetSchemaTable();
            return schemaTable;
        }
    }
}
