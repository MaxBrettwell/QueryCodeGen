using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryCodeGen.Factory
{
    class MockCodeGenerator : ICodeGenerator
    {
        private string _template =
@"
New Template configuration.
...
...
...
End Template
";
        private string _generatorName;

        public MockCodeGenerator() { }
        public MockCodeGenerator(string generatorName) {
            _generatorName = generatorName;
        }

        public string template { get { return _template; } set { _template = value;}}

        string ICodeGenerator.GeneratorName { get => _generatorName;}

        public string GeneratorName()
        {
            return "New Generator";
        }

        public string Generate(string className, System.Data.DataTable dataTable)
        {
            return "New Generated Code";
        }

        public void launchConfigurator() {
            return;
        }
    }
}
