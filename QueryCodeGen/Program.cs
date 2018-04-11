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
                new ODBCSchemaService(),                
                new MockSchemaService(),
                new MockSchemaService("A 2nd Mock schema Service")
            };
            return;
        }

        private static void loadCodeGenerators()
        {
            CodeGenerators = new List<ICodeGenerator> {
                new MockCodeGenerator(),
                new MockCodeGenerator("A Second Mock Generator")
            };
            return;
        }

        public static ICodeGenerator codeGenerator = null;
        public static ISchemaService schemaService = null;

    }
}
