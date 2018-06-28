using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;


namespace QueryCodeGen.Factory
{
    partial class AngularAgGridClassGenerator : ICodeGenerator
    {
        private string _generatorName;

        public void launchConfigurator()
        {
            return;
        }

        private string _template;

        private string classNameUCase;
        private string classNameLCase;
        private string classNameLowerKebabCase;
        private string classNameUpperKebabCase;

        public AngularAgGridClassGenerator(string generatorName = "Angular AgGrid Class Generator")
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

        public string Generate(string className, System.Data.DataTable schemaTable = null)
        {
            //return "you no code this yet!";
            classNameUCase = Char.ToUpperInvariant(className[0]) + className.Substring(1);
            classNameLCase = Char.ToLowerInvariant(className[0]) + className.Substring(1);
            //string classNameKebabCase = trim(both '_' from lower(Regex.Replace(classNameUCase, '([A-Z])', '_\1', 'g')));

            classNameLowerKebabCase = string.Concat(classNameLCase.Select((x, i) => i > 0 && char.IsUpper(x) ? "-" + x.ToString().ToLower() : x.ToString()));
            classNameUpperKebabCase = string.Concat(classNameUCase.Select((x, i) => i > 0 && char.IsUpper(x) ? "-" + x.ToString() : x.ToString()));

            //return classNameUpperKebabCase;

            

            string code =
@"
import { Component, OnInit } from '@angular/core';
import { GridOptions } from 'ag-grid';
import { ICellRendererComp } from 'ag-grid';
import { IAfterGuiAttachedParams } from 'ag-grid'; //not required, but could be useful

import { agAddOnComponent } from '../agaddoncomp/agaddoncomp.component';
import { DatePipe } from '@angular/common';

import { %%classNameUCase%% } from '../../model/%%classNameUCase%%';
import { %%classNameUCase%%Service } from '../../common/service/%%classNameLowerKebabCase%%.service';

@Component({
  selector: 'app-ag-grid',
  templateUrl: './ag-grid.component.html',
  styleUrls: ['./ag-grid.component.css'],
  providers: [DatePipe]
})

export class AgGridComponent implements OnInit {

  public gridOptions: GridOptions;
  public defaultColDef;
  public overlayLoadingTemplate;
  public %%classNameLCase%%Array: %%classNameUCase%%[];
  
  constructor(private %%classNameLCase%%Service: %%classNameUCase%%Service,
  ) {
    this.gridOptions = <GridOptions>{
      overlayLoadingTemplate: `<span class='ag-overlay-loading-center'>Please wait while your rows are loaded</span>`,
    };
    this.gridOptions.columnDefs = [
      %%columnDefs%%
    ];
    this.gridOptions.components

    this.defaultColDef = { editable: true };
    this.overlayLoadingTemplate = `<span class='ag-overlay-loading-center'>Please wait while your rows are loading</span>`;
  };

  ngOnInit() {    
    this.refresh();    
  }

  refresh() {    
    this.gridOptions.api.showLoadingOverlay(); //reshow loading overlay.
    this.%%classNameLCase%%Service.getData().subscribe(response => this.%%classNameLCase%% = response);    
  }

  onGridReady(event) {
    //do something with OnGridReady event
  }
}

export class DateCellRenderer implements ICellRendererComp {
  refresh(params: any): boolean {
    console.log('refresh!');
    return true;
  }

  getGui(): HTMLElement {
    //throw new Error('Method not implemented.');    
    return this.eGui;
  }
  destroy?(): void {
    console.log('destroyed!!!');
    //throw new Error('Method not implemented.');
  }
  afterGuiAttached?(params?: IAfterGuiAttachedParams): void {
    console.log('guid attached');
    //throw new Error('Method not implemented.');
  }

  public eGui: any;
  //public eValue: any;

  public init(dateObj: any) {
    let dateValue = dateObj.value;
    let datePipe: DatePipe = new DatePipe('en-US');
    let dateText = datePipe.transform(dateValue, 'MM-dd-yyyy');

    // create the cell
    this.eGui = document.createElement('div');
        
    // set value into cell
    //this.eGui.innerHTML = '<span>Oh Hello there</span>';
    this.eGui.innerHTML = dateText;
  };
}
";
            string strColumnDefs = generageColumnDefs(className, schemaTable);

            code = code.Replace("%%classNameUCase%%", classNameUCase);
            code = code.Replace("%%classNameLCase%%", classNameLCase);
            code = code.Replace("%%classNameLowerKebabCase%%", classNameLowerKebabCase);
            code = code.Replace("%%classNameUpperKebabCase%%", classNameUpperKebabCase);
            code = code.Replace("%%columnDefs%%", strColumnDefs);

            return code;
        }

        private string generageColumnDefs(string className, System.Data.DataTable schemaTable)
        {
            List<string> chunks = new List<string>();

            foreach (System.Data.DataRow row in schemaTable.Rows)
            {
                string columnDef = "";
                string fieldName = "";
                columnDef = getColumnDef(row["DataType"].ToString());
                fieldName = row["ColumnName"].ToString();

                columnDef = columnDef.Replace("%%headerName%%", fieldName);
                columnDef = columnDef.Replace("%%field%%", fieldName);
                columnDef = columnDef.Replace("%%className%%", className);                

                chunks.Add(columnDef);
            }

            string columnDefs = String.Join(",\r\n", chunks.ToArray());
            return columnDefs;
        }

        private string getColumnDef(string strDataType)
        {
            string columnDef = "";
            switch (strDataType)
            {
                case "System.Boolean":
                    columnDef = getColumnDefType("boolean");
                    break;
                case "System.Byte":
                    columnDef = getColumnDefType("number");
                    break;
                case "System.Int16":
                    columnDef = getColumnDefType("number");
                    break;
                case "System.Int32":
                    columnDef = getColumnDefType("number");
                    break;
                case "System.Int64":
                    columnDef = getColumnDefType("number");
                    break;
                case "System.Single":
                    columnDef = getColumnDefType("number");
                    break;
                case "System.Double":
                    columnDef = getColumnDefType("number");
                    break;
                case "System.Decimal":
                    columnDef = getColumnDefType("number");
                    break;
                case "System.Guid":
                    columnDef = getColumnDefType("text");
                    break;
                case "System.String":
                    columnDef = getColumnDefType("text");
                    break;
                case "System.DateTime":
                    columnDef = getColumnDefType("date");
                    break;
                default:                    
                    columnDef = getColumnDefType("text");
                    break;
            }

            return columnDef;
        }

        private string getColumnDefType(string fieldHTMLType)
        {
            switch (fieldHTMLType)
            {
                case "text":
                    return
@"{
        headerName: '%%headerName%%',
        field: '%%field%%',
        width: 100,
      }";
                case "number":
                    return
@"{
        headerName: '%%headerName%%',
        field: '%%field%%',
        width: 100,
      }";
                case "boolean":
                    return
@"{
        headerName: '%%headerName%%',
        field: '%%field%%',
        width: 100,
      }";
                case "date":
                    return
@"{
        headerName: '%%headerName%%',
        field: '%%field%%',
        width: 100,
        //cellRendererFramework: agAddOnComponent,
        cellRenderer: DateCellRenderer
      }";
                default:
                    return
@"";
            }
        }



        private string stuff() {

            var thingy = @"{
        headerName: 'Mail Out / Returned',
        field: 'returnorsendback',
        width: 100
      },
      {
        headerName: 'Account Number',
        field: 'acct_nbr',
        width: 150
      },
      {
        headerName: 'IMB Serial',
        field: 'imb_serial_zip',
        width: 275
      },
      {
        headerName: 'Print Date',
        field: 'prnt_dt',
        width: 175,
        //cellRendererFramework: agAddOnComponent,
        cellRenderer: DateCellRenderer
      },
      {
        headerName: 'Name',
        field: 'name_line1',
        width: 175,
      },
      {
        headerName: 'Form Type',
        field: 'form_type',
        width: 175,
      },
      {
        headerName: 'Vendor Desc.',
        field: 'vend_desc',
        width: 175,

      },
      {
        headerName: 'Return Date',
        field: 'file_dt',
        width: 175,
        //cellRendererFramework: agAddOnComponent,
        cellRenderer: DateCellRenderer
      },";
            return "";
        }

    }
}