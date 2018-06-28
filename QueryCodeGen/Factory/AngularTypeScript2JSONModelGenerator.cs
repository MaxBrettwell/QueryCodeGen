using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QueryCodeGen.Factory
{
    partial class AngularTypeScript2JSONModelGenerator : ICodeGenerator
    {
        private string _generatorName;

        public void launchConfigurator()
        {
            return;
        }

        private string _template;


        public AngularTypeScript2JSONModelGenerator(string generatorName = "Angular TypeScript2JSON TypeScript Model Generator")
        {
            _generatorName = generatorName;
        }

        public string template { get { return _template; } set { _template = value; } }

        string ICodeGenerator.GeneratorName
        {
            get
            {
                return _generatorName;
            }
        }

        //string ICodeGenerator.GeneratorName { get () => _generatorNamel; }

        public string GeneratorName()
        {
            return _generatorName;
        }

        public string Generate(string className, System.Data.DataTable schemaTable)
        {
            string code = "";
            string template_header =
@"import {JsonObject, JsonProperty, JsonConverter, JsonCustomConvert} from 'json2typescript'; //requires npm module json2typescript

@JsonConverter
class DateConverter implements JsonCustomConvert<Date> {

    serialize(date: Date): any {        
        if (date == null){return null;}
        let returnString: string = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' +  date.getDate();
        return returnString;
    }
    deserialize(date: any): Date {
        if (date == null){return null;}
        let returnDate: Date = new Date(date)
        return returnDate;
    }
}";

            var fields = this.generateModelBodyCode(schemaTable);
            string template_body =
$@"
@JsonObject 
export class {className} {{
{fields}
}}
";
            code = template_header + template_body;
            return code;
        }

        private string generateModelBodyCode(System.Data.DataTable schemaTable)
        {
            List<string> Lines = new List<string>();

            foreach (System.Data.DataRow row in schemaTable.Rows)
            {
                string tsDataType = getTSDataType(row["DataType"].ToString());
                string JSONPropertyConverter = getJSONPropertyConverter(row["DataType"].ToString());
                string TSJSONFieldName = row["ColumnName"].ToString();

                string strJSONProperty = $"@JsonProperty('{TSJSONFieldName}', {JSONPropertyConverter})";
                string strModelField = $"{TSJSONFieldName}: {tsDataType} = undefined;";

                Lines.Add("\t" + strJSONProperty);
                Lines.Add("\t" + strModelField);
            }

            string ModelBodyCode = String.Join("\r\n", Lines.ToArray());
            return ModelBodyCode;
        }

        private string getTSDataType(string strDataType)
        {
            switch (strDataType)
            {
                case "System.Boolean": return "boolaen";
                case "System.Byte": return "number";
                case "System.Int16": return "number";
                case "System.Int32": return "number";
                case "System.Int64": return "number";
                case "System.Single": return "number";
                case "System.Double": return "number";
                case "System.Decimal": return "number";
                case "System.Guid": return "string";
                case "System.String": return "string";
                case "System.DateTime": return "Date";
                default: return "any";
            }
        }

        private string getJSONPropertyConverter(string strDataType)
        {
            switch (strDataType)
            {
                case "System.Boolean": return "Boolean";
                case "System.Byte": return "Number";
                case "System.Int16": return "Number";
                case "System.Int32": return "Number";
                case "System.Int64": return "Number";
                case "System.Single": return "Number";
                case "System.Double": return "Number";
                case "System.Decimal": return "Number";
                case "System.Guid": return "String";
                case "System.String": return "String";
                case "System.DateTime": return "DateConverter";
                default: return "String";
            }
        }


    }
}
