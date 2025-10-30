public sealed class AppSettings
{
    private static readonly System.Lazy<AppSettings> _instance =
        new System.Lazy<AppSettings>(() => new AppSettings(string.Empty, string.Empty));

    public static AppSettings Instance => _instance.Value;

    public string Environment { get; set; }
    public string ApiBaseUrl { get; set; }

    private AppSettings(string environment, string apiBaseUrl)
    {
        Environment = environment;
        ApiBaseUrl = apiBaseUrl;
    }

    public static void Initialize(string environment, string apiBaseUrl)
    {
        Instance.Environment = environment;
        Instance.ApiBaseUrl = apiBaseUrl;
    }

    public static void Reset()
    {
        Instance.Environment = string.Empty;
        Instance.ApiBaseUrl = string.Empty;
    }

    public string GetSummary()
    {
        return $"Entorno: {Environment}, API: {ApiBaseUrl}";
    }
}
