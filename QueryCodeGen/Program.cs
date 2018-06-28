using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using QueryCodeGen.Service;
using QueryCodeGen.Factory;


namespace QueryCodeGen
{
    static class Program
    {

        public static List<ISchemaService> SchemaServices;
        public static List<ICodeGenerator> CodeGenerators;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            loadSchemaServices();
            loadCodeGenerators();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            Application.Run(new formQueryCodeGen());
        }

        private static void loadSchemaServices()
        {
            SchemaServices = new List<ISchemaService> {
                new SQLServerSchemaService("SQL Server Service WHOO!"),
                new ODBCSchemaService(),
                new JSONSchemaService(),
                new MockSchemaService("Mock Schema Service"),
                //new MockSchemaService("A 2nd Mock schema Service"),
                
            };
            return;
        }

        private static void loadCodeGenerators()
        {
            CodeGenerators = new List<ICodeGenerator> {
                
                //new MockCodeGenerator("A 2nd Mock Generator"),
                new AngularFormClassGenerator(),
                new AngularFormtViewGenerator(),
                new AngularAgGridViewGenerator(),
                new AngularAgGridClassGenerator(),

                new Factory.AngularAgGridViewGenerator(),
                new Factory.CSharpModelGenerator(),
                
                new AngularTypeScript2JSONModelGenerator(),
                new MockCodeGenerator("Mock Code Generator"),

            };
            return;
        }

        public static ICodeGenerator codeGenerator = null;
        public static ISchemaService schemaService = null;

    }
}
