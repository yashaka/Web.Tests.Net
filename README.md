# NSelene + NUnit tests project template

## Overview and general guidelines

This is a template project. It's supposed to be cloned or downloaded and edited according to your needs.

The project itself reflects an implementation of acceptance web ui tests for a "web", i.e. as "application under test" we consider here the "whole web", under "root pages" we mean "web sites", under "sub-pages" we mean "web site pages". To apply this template to your context, usually you would need to rename all "Web" entries in names or some option values in config files (like TBD) to "Your.ProjectName" with the following exceptions:

- you can rename `Www.cs` to `App.cs` instead of `YourProjectName.cs` for conciseness

Hence, download it, rename the project folder to something like ``MyProduct.Tests``, then rename the `.csproj` and other `.cs` files and namespaces correspondingly...

And you should be ready to go ;)

## Installation

TBD

## Details

Features supported:
- so far, see [CHANGELOG](https://github.com/yashaka/Web.Tests.Net/blob/master/CHANGELOG.md) for more details
- TBD

## Run Tests

### With local Chrome

```bash
env -S "WebDriver:Local=chrome" dotnet test
```

#### overriding more than one param from appsettings.json

```bash
env -S "WebDriver:Local=chrome NSelene:Timeout=8" dotnet test
```

### Local Selenoid on Docker

#### Given

Check browser images in etc/selenoid/browsers.json and once performed `docker pull` for all corresponding images, like: 

```bash
docker pull selenoid/chrome:84.0 && docker pull selenoid/vnc_chrome:84.0
```

do either for "pure selenoid"

```bash
docker-compose -f etc/selenoid/compose.yaml up -d selenoid
```

or for "selenoid with selenoid UI"

```bash
docker-compose -f etc/selenoid/compose.yaml up -d
```

#### Then

```bash
dotnet test
```

##### overriding some settings from appsettings.json

```bash
env -S "WebDriver:Remote:enableVNC=false NSelene:Timeout=8" dotnet test
```

#### Finally

```bash
docker-compose -f etc/selenoid/compose.yaml stop
```

## Resources

* [Accessing Configuration in .NET Core Test Projects. By Rick Strahl. From February 18, 2018](https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects)