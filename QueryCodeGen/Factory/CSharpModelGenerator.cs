using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QueryCodeGen.Factory
{
    partial class CSharpModelGenerator : ICodeGenerator
    {
        private string _generatorName;

        public void launchConfigurator()
        {
            return;
        }

        private string _template;

        private string _template_JSONProperty = "@JsonProperty('%%fieldName%%', %%dataType%%)";
        private string _template_ModelField = "%%fieldName%%: %%dataType%%";

        public CSharpModelGenerator(string generatorName = "C# Model Generator")
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

        public string GeneratorName()
        {
            return _generatorName;
        }

        public string Generate(string className, System.Data.DataTable schemaTable)
        {           
            string classNameUCase = Char.ToUpperInvariant(className[0]) + className.Substring(1);
            string classNameLCase = Char.ToLowerInvariant(className[0]) + className.Substring(1);
            string props = generateProps(schemaTable, classNameUCase);

            string strTemplate = 
@"using System;

namespace App.model
{
    public class %%classNameLCase%%
    {
%%props%%
    }
}

";            
            strTemplate = strTemplate.Replace("%%classNameLCase%%", classNameLCase);
            strTemplate = strTemplate.Replace("%%props%%", props);
            return strTemplate;
        }

        private string generateProps(System.Data.DataTable schemaTable, string className)
        {
            List<string> chunks = new List<string>();
            
            foreach (System.Data.DataRow row in schemaTable.Rows)
            {                
                string strProp = genProp(row["DataType"].ToString(), row["DataType"].ToString()); 
                chunks.Add(strProp);
            }

            string ModelBodyCode = String.Join("\r\n", chunks.ToArray());
            return ModelBodyCode;
        }

        private string genProp(string propName, string dataType)
        {
            dataType = dataType.Replace("System.", "");
            string strProp = "        public {propName} {dataType} {get; set;}";
            strProp = strProp.Replace("{propName}", propName);
            strProp = strProp.Replace("{dataType}", dataType);
            return strProp;
        }
    }       
}

