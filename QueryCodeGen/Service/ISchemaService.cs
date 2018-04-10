using System.Data;

namespace QueryCodeGen.Service
{
    interface ISchemaService
    {
        string SchemaServiceName();
        DataTable getTableSchema(string connectionString, string query);
    }
}