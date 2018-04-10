/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

using System;

namespace QueryCodeGen.Service
{
    class ODBCSchemaService : ISchemaService
    {
        private string _connString;

        
        //public SchemaService(string connString)
        //{
        //    _connString = connString;
        //}

        private System.Data.Odbc.OdbcConnection getConnection(string connString) {
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(connString);
            return conn;
        }

        public System.Data.DataTable getTableSchema(string connString, string query) {
            return null;
        }

        public string SchemaServiceName()
        {
            return "ODBC Schema Service";
        }
    }
}
