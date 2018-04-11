using System.Data;

namespace QueryCodeGen.Service
{
    interface ISchemaService
    {
        string SchemaServiceName {get;}        
        DataTable getTableSchema(string connectionString, string query);
    }
}