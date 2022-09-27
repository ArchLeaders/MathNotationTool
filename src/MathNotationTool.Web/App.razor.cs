using Avalonia.Web.Blazor;

namespace MathNotationTool.Web
{
    public partial class App
    {
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            WebAppBuilder.Configure<MathNotationTool.App>()
                .SetupWithSingleViewLifetime();
        }
    }
}