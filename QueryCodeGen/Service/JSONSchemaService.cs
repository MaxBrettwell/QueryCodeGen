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
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QueryCodeGen.Service
{
    class JSONSchemaService : ISchemaService
    {

        private string _schemaServiceName = "JSON Schema Service";

        public JSONSchemaService()
        { }

        public JSONSchemaService(string schemaServiceName)
        {
            _schemaServiceName = schemaServiceName;
        }

        string ISchemaService.SchemaServiceName => _schemaServiceName;

        public DataTable getSchema(string connectionString = "", string query = "")
        {
            connectionString = "";
            string strJSON = query;

            Newtonsoft.Json.Linq.JObject jObj = Newtonsoft.Json.Linq.JObject.Parse(strJSON);

            DataTable schemaTable = new DataTable();
            schemaTable.Columns.Add("ColumnName");
            schemaTable.Columns.Add("DataType");


            foreach (var o in jObj)
            {
                DataRow row = schemaTable.NewRow();
                row["ColumnName"] = o.Key;

                switch (o.Value.Type)
                {
                    case JTokenType.Array:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Boolean:
                        row["DataType"] = "System.Boolean";
                        break;
                    case JTokenType.Bytes:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Comment:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Constructor:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Date:
                        row["DataType"] = "System.DateTime";
                        break;
                    case JTokenType.Float:
                        row["DataType"] = "System.Double";
                        break;
                    case JTokenType.Guid:
                        row["DataType"] = "System.Guid";
                        break;
                    case JTokenType.Integer:
                        row["DataType"] = "System.Int64";
                        break;
                    case JTokenType.None:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Null:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Object:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Property:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Raw:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.String:
                        row["DataType"] = "System.String";
                        break;
                    case JTokenType.TimeSpan:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Undefined:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    case JTokenType.Uri:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                    default:
                        throw new NotImplementedException("DataType mapping not implemented for type " + o.Value.Type.ToString() + " for field " + o.Key);
                }

                //row["DataType"] = "System." + o.Value.Type;
                schemaTable.Rows.Add(row);
            }
            return schemaTable;
        }

    }
}