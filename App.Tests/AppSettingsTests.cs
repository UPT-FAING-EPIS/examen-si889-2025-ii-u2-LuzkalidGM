using Xunit;

public class AppSettingsTests
{
    [Fact]
    public void CrearConfiguracion_DeberiaRetornarResumenCorrecto()
    {
        // Arrange
        AppSettings.Initialize("Producción", "https://api.miapp.com");
        var settings = AppSettings.Instance;

        // Act
        var resumen = settings.GetSummary();

        // Assert
        Assert.Equal("Entorno: Producción, API: https://api.miapp.com", resumen);

        // Cleanup
        AppSettings.Reset();
    }

    [Fact]
    public void CambiarConfiguracion_DeberiaActualizarValores()
    {
        // Arrange
        AppSettings.Initialize("Desarrollo", "http://localhost:5000");
        var settings = AppSettings.Instance;

        // Act
        settings.Environment = "QA";
        settings.ApiBaseUrl = "https://qa.api.miapp.com";
        var resumen = settings.GetSummary();

        // Assert
        Assert.Equal("Entorno: QA, API: https://qa.api.miapp.com", resumen);

        // Cleanup
        AppSettings.Reset();
    }
}
