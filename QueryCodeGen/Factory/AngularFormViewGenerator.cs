using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QueryCodeGen.Factory
{
    partial class AngularFormtViewGenerator : ICodeGenerator
    {
        private string _generatorName;

        public void launchConfigurator()
        {
            return;
        }

        private string _template;

        private string _template_JSONProperty = "@JsonProperty('%%fieldName%%', %%dataType%%)";
        private string _template_ModelField = "%%fieldName%%: %%dataType%%";

        public AngularFormtViewGenerator(string generatorName = "Angular Form View Generator")
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
@"
<div class=""jumbotron"">
  <div class=""row"">
    <div class=""col-md-12"">

      <h3>Return Mail Checker</h3>
      <p>Provided by Document Strategy</p>

      <div class=""form - group"">
";

            string template_footer =
@"</div>

    <br>
    <br>
    <div class=""row"">
      <div class=""col-sm-12"">
        <div class=""form-group"">
          <div id=""buttthesearchbuttons"">
            <a class=""btn btn-primary btn-lg"" style=""float: left;"" (click)=""refresh()"" role=""button"">Refresh</a>
          </div>

          <div id=""buttthesearchbuttons"">
            <a class=""btn btn-primary btn-lg"" style=""float: left;"" (click)=""fiddleFaddle()"" role=""button"">Fiddle Faddle</a>
          </div>
          <div id=""buttthesearchbuttons"">
            <a class=""btn btn-primary btn-lg"" style=""float: left;"" (click)=""horseFeathers()"" role=""button"">Horse Feathers</a>
          </div>
          <div id=""buttthebuttons"">
            <a class=""btn btn-primary btn-lg"" style=""float: right;"" (click)=""submit()"" role=""button"">Submit</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>";

            
            string template_body = this.generateViewBodyCode(className, schemaTable);


            code = template_header + template_body + template_footer;
            return code;
        }

        private string generateViewBodyCode(string className, System.Data.DataTable schemaTable)
        {
            List<string> chunks = new List<string>();

            foreach (System.Data.DataRow row in schemaTable.Rows)
            {
                string fieldHTML = "";
                string fieldName = "";
                fieldHTML = getFieldHTML(row["DataType"].ToString());
                fieldName = row["ColumnName"].ToString();

                fieldHTML = fieldHTML.Replace("%id%", fieldName);
                fieldHTML = fieldHTML.Replace("%className%", className);
                fieldHTML = fieldHTML.Replace("%id%", fieldName);

                chunks.Add(fieldHTML);
            }

            string ModelBodyCode = String.Join("\r\n", chunks.ToArray());
            return ModelBodyCode;
        }

        private string getFieldHTML(string strDataType)
        {
            string fieldHTML = "";
            switch (strDataType)
            {
                case "System.Boolean":
                    fieldHTML = getFieldHTMLType("checkbox");
                    break;
                case "System.Byte":
                    fieldHTML = getFieldHTMLType("number");
                    break;
                case "System.Int16":
                    fieldHTML = getFieldHTMLType("number");
                    break;
                case "System.Int32":
                    fieldHTML = getFieldHTMLType("number");
                    break;
                case "System.Int64":
                    fieldHTML = getFieldHTMLType("number");
                    break;
                case "System.Single":
                    fieldHTML = getFieldHTMLType("number");
                    break;
                case "System.Double":
                    fieldHTML = getFieldHTMLType("number");
                    break;
                case "System.Decimal":
                    fieldHTML = getFieldHTMLType("number");
                    break;
                case "System.Guid":
                    fieldHTML = getFieldHTMLType("text");
                    break;
                case "System.String":
                    fieldHTML = getFieldHTMLType("text");
                    break;
                case "System.DateTime":
                    fieldHTML = getFieldHTMLType("date");
                    break;
                default:
                    return "any";
                    fieldHTML = getFieldHTMLType("text");
                    break;
            }

            return fieldHTML;
        }

        private string getFieldHTMLType(string fieldHTMLType)
        {
            switch (fieldHTMLType)
            {
                case "text":
                    return
@"<div class=""mb-3"">
          <div class=""row"">
            <div class=""col-md-6"">
              <label>%id%</label>
              <input class=""form-control"" type=""text"" id=""%id%"" placeholder=""Enter Text"" [(ngModel)]=""%className%.%id%"">
            </div>
          </div>
        </div>
";
                case "number":
                    return
@"
        <div class=""mb-3"">
          <div class=""row"">
            <div class=""col-md-6"">
              <label>%id%</label>
              <input class=""form-control"" type=""number"" id=""%id%"" placeholder=""Enter Number"" [(ngModel)]=""%className%.%id%"">

            </div>
          </div>
        </div>";
                case "checkbox":
                    return
@"        <div class=""mb-3"">
          <div class=""row"">
            <div class=""col-md-6"">
              <label>%id%</label>              
                <input style=""float:none; width:15px"" class=""form-control"" type=""checkbox"" id=""%id%"" [ngModel]=""%className%.%id%"">
            </div>
          </div>
        </div>";
                case "date":
                    return
@"        <div class=""mb-3"">
          <div class=""row"">
            <div class=""col-md-6"">
              <label>%id%</label>
              <!-- <input class=""form-control"" type=""date"" id=""search"" [(ngModel)]=""returnMailSQL.prnt_dt""> -->
              <input class=""form-control"" type=""date"" id=""%id%"" [ngModel] =""%className%.%id% | date:'yyyy-MM-dd'"" (ngModelChange)=""dt = $event"">              
            </div>
          </div>
        </div>";
                default:
                    return
@"<div class=""mb-3"">
          <div class=""row"">
            <div class=""col-md-6"">
              <label>%id%</label>
              <input class=""form-control"" type=""text"" id=""%id%"" placeholder=""Enter Text"" [(ngModel)]=""%className%.%id%"">
            </div>
          </div>
        </div>
";
            }
        }
    }
}
