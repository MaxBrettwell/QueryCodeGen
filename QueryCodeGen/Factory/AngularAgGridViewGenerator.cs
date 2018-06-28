using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QueryCodeGen.Factory
{
    partial class AngularAgGridViewGenerator : ICodeGenerator
    {
        private string _generatorName;

        public void launchConfigurator()
        {
            return;
        }

        private string _template;

        private string _template_JSONProperty = "@JsonProperty('%%fieldName%%', %%dataType%%)";
        private string _template_ModelField = "%%fieldName%%: %%dataType%%";

        public AngularAgGridViewGenerator(string generatorName = "Angular AgGrid View Generator")
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

            string classNameUCase = Char.ToUpperInvariant(className[0]) + className.Substring(1);
            string classNameLCase = Char.ToLowerInvariant(className[0]) + className.Substring(1);

            string template =
@"<div id='gridtable' class='row'>
  <ag-grid-angular #agGrid style='width: 100%;height: 500px;' class='ag-theme-material' [gridOptions]='gridOptions' [enableSorting]='true'
    [enableFilter]='true' [enableColResize]='true' [rowData]='%%classNameLCase%%Array' [showToolPanel]='true' [defaultColDef]='defaultColDef'
    [pagination]=true (gridReady)='onGridReady($event)'>
  </ag-grid-angular>
</div>

<div class='row'>
  <div class='col-sm-12'>
    <div class='form-group'>
      <div id='buttthesearchbuttons'>
        <a class='btn btn-primary btn-lg' style='float: left;' (click)='refresh()' role='button'>Refresh</a>
      </div>      
    </div>
  </div>
</div>";

            template = template.Replace("%%classNameLCase%%", classNameLCase);
            return template;

        }

                   
    }
}
