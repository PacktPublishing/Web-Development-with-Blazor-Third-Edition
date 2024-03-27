using Microsoft.CodeAnalysis;
namespace SourceGenerator;
[Generator]
public class HelloSourceGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        // Build up the source code
        string source = """
namespace BlazorWebAssembly;
public class GeneratedService
    {
        public string GetHello()
        {
            return "Hello from generated code";
        }
    }
""";
        // Add the source code to the compilation
        context.AddSource($"GeneratedService.g.cs", source);
}

    public void Initialize(GeneratorInitializationContext context)
    {
        // No initialization required for this one
    }
}

