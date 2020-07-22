using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Web.Tests.Common.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Web.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class BrowserTest
    {
        protected ProjectSettings Settings { get; set;}

        public BrowserTest()
        {
            var configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", 
                //     optional: true)  // TODO
                .AddEnvironmentVariables()
                .Build();

            this.Settings = new ProjectSettings(configurationRoot);
        }

        [SetUp]
        public void InitDriver()
        {
            NSelene.Configuration.Timeout = this.Settings.NSelene.Timeout;

            IWebDriver webDriver;
            if (this.Settings.WebDriver.Local == "chrome") 
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                webDriver = new ChromeDriver();
            } 
            else
            {
                var options = new ChromeOptions()
                    .AddGlobal("enableVNC",
                               this.Settings.WebDriver.Remote.enableVNC)
                    .AddGlobal("enableVideo",
                               this.Settings.WebDriver.Remote.enableVideo);

                webDriver = new RemoteWebDriver(
                    new Uri(this.Settings.WebDriver.Remote.uri),
                    options);
            }

            Selene.SetWebDriver(webDriver);
        }

        [TearDown]
        public void QuitDriver()
        {
            if (this.Settings.WebDriver.HoldBrowserOpen) return;

            Selene.GetWebDriver().Quit();
        }
    }
}