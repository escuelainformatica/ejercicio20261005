using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;

namespace WinFormsApp1.UI.Tests;

public class Form1UiTests
{
    [Fact(Skip = "Requiere sesión interactiva de Windows (desktop) para ejecutarse localmente.")]
    public void CalculateArea_Click_ShowsExpectedResult()
    {
        var appPath = ResolveAppPath();
        using var app = Application.Launch(appPath);
        using var automation = new UIA3Automation();

        var window = app.GetMainWindow(automation);
        window.WaitUntilClickable();

        var alto = window.FindFirstDescendant(cf => cf.ByAutomationId("nudAlto"))?.AsSpinner();
        var ancho = window.FindFirstDescendant(cf => cf.ByAutomationId("nudAncho"))?.AsSpinner();
        var largo = window.FindFirstDescendant(cf => cf.ByAutomationId("nudLargo"))?.AsSpinner();
        var button = window.FindFirstDescendant(cf => cf.ByAutomationId("btnCalcularArea"))?.AsButton();
        var result = window.FindFirstDescendant(cf => cf.ByAutomationId("lblResultado"))?.AsLabel();

        Assert.NotNull(alto);
        Assert.NotNull(ancho);
        Assert.NotNull(largo);
        Assert.NotNull(button);
        Assert.NotNull(result);

        alto!.Value = 2;
        ancho!.Value = 3;
        largo!.Value = 4;

        button!.Invoke();
        Retry.WhileTrue(() => !result!.Text.Contains("52.00"), timeout: TimeSpan.FromSeconds(2));

        Assert.Contains("52.00", result!.Text);
    }

    private static string ResolveAppPath()
    {
        var current = AppContext.BaseDirectory;
        var root = Path.GetFullPath(Path.Combine(current, "..", "..", "..", "..", ".."));
        return Path.Combine(root, "WinFormsApp1", "bin", "Debug", "net6.0-windows", "WinFormsApp1.exe");
    }
}
