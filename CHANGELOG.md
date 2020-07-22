# todo:

- support appsettings.<ENV>.json files
- provide examples of overriding env vars for windows powershell

# 0.0.next

- add Allure Reporting
- TBD

# 0.0.1
with...

- initial NUnit + NSelene + ... template for web ui tests
  -  ... + Microsoft.Extensions.Configuration & Co
  -  ... + WebDriverManager for local run
    - with only Chrome supported for now
- simple browser management through inheriting from BrowserTest
  - all tests should be parallelizable and are executed in parallel by default
  - simple webdriver management logic implemented in `BrowserTest#InitDriver`
- configuring tests through appsettings.json
    - with accessing settings in BrowserTest descendants via strongly typed
      `this.Settings`. e.g.: `this.Settings.WebDriver.Remote.enableVNC` 
- overriding settings in command line through env varibles, e.g.:
  `env -S "WebDriver:Local=chrome NSelene:Timeout=8" dotnet test`
- docker-compose example to setup selenoid with selenoid-ui
- PageObjects examples
  - with aka ApplicationManager as one enty point to all pageobjects 
    (see `Www.*` in tests)
- with some helpers and extension examples
  - like ChromeOptionsExtensions