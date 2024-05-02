using Microsoft.Extensions.Localization;

namespace Bluehill.Hangul.Pages.Tests;

public sealed class HomeTest : TestContext {
    public HomeTest() {
        Services.AddLocalization();
    }

    [Fact]
    public void Home_H1() {
        // Act
        var cut = RenderComponent<Home>();

        // Assert
        cut.Find("h1").MarkupMatches("<h1>Bluehill.Hangul</h1>");
    }

    [Fact]
    public void Home_Badges() {
        // Act
        var cut = RenderComponent<Home>();

        // Assert
        cut.Find("#badges").MarkupMatches("""
            <p id="badges">
              <img alt="GitHub License" src="https://img.shields.io/github/license/na1307/Bluehill.Hangul?style=flat-square">
              <a href="https://www.nuget.org/packages/Bluehill.Hangul">
                <img alt="NuGet Version" src="https://img.shields.io/nuget/v/Bluehill.Hangul?style=flat-square&amp;logo=nuget">
              </a>
              <a href="https://www.nuget.org/packages/Bluehill.Hangul">
                <img alt="NuGet Version (with prereleases)" src="https://img.shields.io/nuget/vpre/Bluehill.Hangul?style=flat-square&amp;logo=nuget&amp;label=preview&amp;color=616">
              </a>
              <a href="https://www.nuget.org/packages/Bluehill.Hangul">
                <img alt="NuGet Downloads" src="https://img.shields.io/nuget/dt/Bluehill.Hangul?style=flat-square&amp;logo=nuget">
              </a>
              <a href="https://github.com/na1307/Bluehill.Hangul/issues">
                <img alt="GitHub Issues" src="https://img.shields.io/github/issues-raw/na1307/Bluehill.Hangul?style=flat-square&amp;logo=github">
              </a>
              <a href="https://github.com/na1307/Bluehill.Hangul/pulls">
                <img alt="GitHub Pull Requests" src="https://img.shields.io/github/issues-pr-raw/na1307/Bluehill.Hangul?style=flat-square&amp;logo=github">
              </a>
              <img alt="GitHub Actions Workflow Status" src="https://img.shields.io/github/actions/workflow/status/na1307/Bluehill.Hangul/dotnet.yml?style=flat-square&amp;logo=github-actions&amp;logoColor=white">
              <a href="https://sonarcloud.io/summary/new_code?id=na1307_Bluehill.Hangul">
                <img alt="Sonar Quality Gate" src="https://img.shields.io/sonar/quality_gate/na1307_Bluehill.Hangul?server=https%3A%2F%2Fsonarcloud.io&amp;style=flat-square&amp;logo=sonarcloud">
              </a>
              <a href="https://sonarcloud.io/summary/new_code?id=na1307_Bluehill.Hangul">
                <img alt="Sonar Coverage" src="https://img.shields.io/sonar/coverage/na1307_Bluehill.Hangul?server=https%3A%2F%2Fsonarcloud.io&amp;style=flat-square&amp;logo=sonarcloud">
              </a>
            </p>
            """);
    }

    [Fact]
    public void Home_HeadText() {
        var localizer = Services.GetService<IStringLocalizer<Home>>()!;

        // Act
        var cut = RenderComponent<Home>();

        // Assert
        cut.Find("#headtext").MarkupMatches($"<p id=\"headtext\">{localizer.GetString("Head")}</p>");
    }

    [Fact]
    public void Home_Links() {
        var localizer = Services.GetService<IStringLocalizer<Home>>()!;

        // Act
        var cut = RenderComponent<Home>();

        // Assert
        cut.Find("#links").MarkupMatches($"""
            <ul id="links">
              <li>
                <a href="howtouse">{localizer.GetString("HowToUse")}</a>
              </li>
              <li>{localizer.GetString("Try")}</li>
              <li style="list-style-type:none">
                <ul>
                  <li>
                    <a href="tryjosa">{localizer.GetString("TryJosa")}</a>
                  </li>
                  <li>
                    <a href="trychar">{localizer.GetString("TryChar")}</a>
                  </li>
                </ul>
              </li>
              <li>
                <a href="changelog">{localizer.GetString("Changelog")}</a>
              </li>
            </ul>
            """);
    }
}
