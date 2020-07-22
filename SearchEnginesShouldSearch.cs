using NUnit.Framework;
using Web.Tests.Model;

namespace Web.Tests
{
    public class SearchEnginesShouldSearch : BrowserTest
    {
        [Test]
        public void Duckduckgo()
        {
            Www.duckduckgo.Open();

            Www.duckduckgo.Search("nselene dotnet");
            Www.duckduckgo.Results.ShouldHaveSizeAtLeast(5)
                .ShouldHaveText(0, "Consise API to Selenium for .Net");

            Www.duckduckgo.Results.FollowLink(0);
            Www.github.ShouldBeOn("yashaka/NSelene");
        }

        [Test]
        public void Ecosia()
        {
            Www.ecosia.Open();

            Www.ecosia.Search("nselene dotnet");
            Www.ecosia.Results.ShouldHaveSizeAtLeast(5)
                .ShouldHaveText(0, "Consise API to Selenium for .Net");

            Www.ecosia.Results.FollowLink(0);
            Www.github.ShouldBeOn("yashaka/NSelene");
        }
    }
}