using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components.Rendering;
namespace Microsoft.AspNetCore.Components.Forms;
public class InputTextAreaOnInput :
 InputBase<string?>
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "textarea");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValue));
        builder.AddAttribute(4, "oninput", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.CloseElement();
    }
    protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }
}
