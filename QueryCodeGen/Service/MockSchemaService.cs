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
    class MockSchemaService: ISchemaService 
    {
        private string _schemaServiceName = "Mock Schema Service";

        string ISchemaService.SchemaServiceName => _schemaServiceName;

        public MockSchemaService()
        {}

        public MockSchemaService(string schemaServiceName)
        {
            _schemaServiceName = schemaServiceName;
        }

        private System.Data.Odbc.OdbcConnection getConnection(string connString) {
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(connString);
            return conn;
        }

        public System.Data.DataTable getTableSchema(string connString, string query) {
            return null;
        }

        public string SchemaServiceName()
        {
            return _schemaServiceName;
        }
    }
}
