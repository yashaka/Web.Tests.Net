using Microsoft.Extensions.Configuration;

/*
 * The file is named AppSettings.cs for consistency with appsettings.json
 * 
 */
namespace Web.Tests
{
    /*
     * We break consistency with AppSettings.cs and appsettings.json
     * here in ProjectSettings name, because in fact our project
     * is a tests project, not an App
     * Yet we name it with `...Settings` ending 
     * for consistency with appsettings style of naming
     * (probably another examples in the web will use "...Configuration" style)
     */
    public class ProjectSettings
    {
        // TODO: consider something like = Settings.BoundTo(settingsRoot); 
        public ProjectSettings(IConfiguration configuration)
        {
            // TODO: is it good to put the folllwing in a constructur?
            configuration.Bind(NSeleneSettings.Key, this.NSelene);
            configuration.Bind(WebDriverSettings.Key, this.WebDriver);
        }

        public NSeleneSettings NSelene { get; set; } = new NSeleneSettings();

        public WebDriverSettings WebDriver { get; set; } 
            = new WebDriverSettings();
    }


    public class NSeleneSettings
    {
        public static readonly string Key = "NSelene";

        public double Timeout { get; set; } = 6;
    }

    public class WebDriverSettings
    {
        public static readonly string Key = "WebDriver";

        /* TODO: refactor for more natural and handy logic
         * 
         * if set to "chrome" then "execute in local chrome" browser
         * else execute on remote chrome settings specified further
         */
        public string Local { get; set; } = "";
        public RemoteSettings Remote { get; set; } = new RemoteSettings();

        public class RemoteSettings
        {
            public string uri { get; set; } = "http://localhost:4444/wd/hub";
            public bool enableVNC { get; set; } = true;
            public bool enableVideo { get; set; } = false;
        };

        public bool HoldBrowserOpen { get; set; } = false;
    }
}