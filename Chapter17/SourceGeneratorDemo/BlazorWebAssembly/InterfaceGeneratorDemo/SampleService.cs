namespace BlazorWebAssemblyApp.InterfaceGeneratorDemo;
using InterfaceGenerator;

[GenerateAutoInterface]
public class SampleService: ISampleService
{
    public double Multiply(double x, double y)
    {
        return x * y;
    }

    public int NiceNumber => 69;
}
