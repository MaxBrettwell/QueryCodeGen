using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QueryCodeGen.Factory
{
    partial class AngularFormClassGenerator : ICodeGenerator
    {
        private string _generatorName;

        public void launchConfigurator()
        {
            return;
        }

        private string _template;

        public AngularFormClassGenerator(string generatorName = "Angular Form Class Generator")
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
            string classNameUCase = Char.ToUpperInvariant(className[0]) + className.Substring(1);
            string classNameLCase = Char.ToLowerInvariant(className[0]) + className.Substring(1);

            schemaTable = null; //schema table not required for this generator

            string code =
@"
import { Component, OnInit } from '@angular/core';
import { %classNameUCase% } from '../../model/%classNameUCase%';
import { JsonConvert, OperationMode, ValueCheckingMode } from 'json2typescript'
import { DatePipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
  providers: [DatePipe]
})
export class FormComponent implements OnInit {
  
  public %classNameLCase%: %classNameUCase% = new %classNameUCase%();

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    var ctrl = this;
    var obs: Observable<string>;

    //hard coded api call in template should be updated to be dynamically generated
    obs = this.http.get<string>('api/sqlserver?searchValue=' + '789456123');
    obs.subscribe(function (response: string) {

      var json%classNameUCase% = JSON.stringify(response);
      
      let jsonConvert: JsonConvert = new JsonConvert();
      jsonConvert.operationMode = OperationMode.ENABLE; // print some debug data
      jsonConvert.ignorePrimitiveChecks = false; // don't allow assigning number to string etc.
      jsonConvert.valueCheckingMode = ValueCheckingMode.ALLOW_NULL; 

      let obj%classNameUCase%: %classNameUCase%[];
      
      obj%classNameUCase% = jsonConvert.deserialize(response,%classNameUCase%);      
      ctrl.%classNameLCase% = objReturnMail[0];      
    });
  }

  submit() { }

  horseFeathers() {
    console.log('horse feathers');
    this.%classNameLCase% = new %classNameUCase%();
  }

  fiddleFaddle() {
    console.log('fiddle faddle');
    this.%classNameLCase% = new %classNameUCase%();
  }
}

";
            code = code.Replace("%classNameUCase%", classNameUCase);
            code = code.Replace("%classNameLCase%", classNameLCase);

            return code;
        }
    }
}