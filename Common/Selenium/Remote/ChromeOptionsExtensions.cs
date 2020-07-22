
using OpenQA.Selenium.Chrome;

namespace Web.Tests.Common.Selenium.Remote
{
    public static class ChromeOptionsExtensions
    {
        public static ChromeOptions AddGlobal(this ChromeOptions options, string capabilityName, object capabilityValue)
        {
            options.AddAdditionalCapability(capabilityName, capabilityValue, true); 
            return options;
        }
    }
}