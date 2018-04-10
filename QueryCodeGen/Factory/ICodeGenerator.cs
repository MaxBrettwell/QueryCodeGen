using System.Data;

namespace QueryCodeGen.Factory
{
    interface ICodeGenerator
    {
        string template { get; set; }

        string Generate(string className, DataTable dataTable);
        string GeneratorName();
        void launchConfigurator();
    }
}