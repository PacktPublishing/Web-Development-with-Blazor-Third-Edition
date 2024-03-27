using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
namespace BlazorWebApp.Component.Pages;

[Route("/CounterWithoutRazor")]
public class CounterWithoutRazor : ComponentBase
{
    protected override void BuildRenderTree
      (RenderTreeBuilder builder)
    {
        builder.AddMarkupContent(0, "<h1>Counter</h1>\r\n\r\n");
        builder.OpenElement(1, "p");
        builder.AddContent(2, "Current count: ");
        builder.AddContent(3, currentCount);
        builder.CloseElement();
        builder.AddMarkupContent(4, "\r\n\r\n");
        builder.OpenElement(5, "button");
        builder.AddAttribute(6, "class", "btn btn-primary");
        builder.AddAttribute(7, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, IncrementCount));
        builder.AddContent(8, "Click me");
        builder.CloseElement();
    }
    private int currentCount = 0;
    private void IncrementCount()
    {
        currentCount++;
    }
}
