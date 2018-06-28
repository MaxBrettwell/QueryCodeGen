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
using System.Data.SqlClient;


namespace QueryCodeGen.Service
{
    class SQLServerSchemaService : ISchemaService
    {

        private string _schemaServiceName = "SQL Server Schema Service";

        public SQLServerSchemaService()
        { }

        public SQLServerSchemaService(string schemaServiceName)
        {
            _schemaServiceName = schemaServiceName;
        }
        
        string ISchemaService.SchemaServiceName => _schemaServiceName;
                
        private SqlConnection getConnection(string connString) {
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        public System.Data.DataTable getSchema(string connString, string query) {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            //DataTable table = conn.GetDataTable(commandText: query, commandBehavior: System.Data.CommandBehavior.SchemaOnly);
            IDataReader reader = conn.GetDataReader(commandText: query, commandBehavior: CommandBehavior.SchemaOnly);

            //DataTable dt = reader.GetDataTable();


            DataTable schemaTable = reader.GetSchemaTable();
            return schemaTable;
        }
    }
}
