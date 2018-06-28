using System.Data;

namespace QueryCodeGen.Service
{
    interface ISchemaService
    {
        string SchemaServiceName {get;}        
        DataTable getSchema(string connectionString, string query);
    }
}