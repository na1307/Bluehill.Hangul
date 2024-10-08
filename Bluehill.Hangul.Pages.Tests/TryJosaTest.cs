﻿namespace Bluehill.Hangul.Pages.Tests;

public sealed class TryJosaTest : TestContext {
    public TryJosaTest() {
        Services.AddLocalization();
    }

    [Fact]
    public void TryJosa_Results_Empty() {
        var localizer = Services.GetService<IStringLocalizer<TryJosa>>()!;

        // Act
        var cut = RenderComponent<TryJosa>();

        // Assert
        cut.Find("table#results").MarkupMatches($"""
            <table id="results" class="table">
              <thead>
                <tr>
                  <th>{localizer.GetString("Method")}</th>
                  <th>{localizer.GetString("Result")}</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>EunNeun</td>
                  <td>{HangulConstants.Eun_Neun}</td>
                </tr>
                <tr>
                  <td>IGa</td>
                  <td>{HangulConstants.I_Ga}</td>
                </tr>
                <tr>
                  <td>I</td>
                  <td></td>
                </tr>
                <tr>
                  <td>EulReul</td>
                  <td>{HangulConstants.Eul_Reul}</td>
                </tr>
                <tr>
                  <td>GwaWa</td>
                  <td>{HangulConstants.Gwa_Wa}</td>
                </tr>
                <tr>
                  <td>AYa</td>
                  <td>{HangulConstants.A_Ya}</td>
                </tr>
                <tr>
                  <td>EuRo</td>
                  <td>{HangulConstants.Eu_Ro}</td>
                </tr>
              </tbody>
            </table>
            """);
    }

    [Theory]
    [InlineData("사과")]
    [InlineData("하준")]
    [InlineData("은율")]
    [InlineData("Ben")]
    [InlineData("ㅏ")]
    public void TryJosa_Results_Inputs(string input) {
        var localizer = Services.GetService<IStringLocalizer<TryJosa>>()!;

        // Act
        var cut = RenderComponent<TryJosa>();

        cut.Find("input#input").Change(input);

        // Assert
        cut.Find("table#results").MarkupMatches($"""
            <table id="results" class="table">
              <thead>
                <tr>
                  <th>{localizer.GetString("Method")}</th>
                  <th>{localizer.GetString("Result")}</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>EunNeun</td>
                  <td>{input.EunNeun()}</td>
                </tr>
                <tr>
                  <td>IGa</td>
                  <td>{input.IGa()}</td>
                </tr>
                <tr>
                  <td>I</td>
                  <td>{input.I()}</td>
                </tr>
                <tr>
                  <td>EulReul</td>
                  <td>{input.EulReul()}</td>
                </tr>
                <tr>
                  <td>GwaWa</td>
                  <td>{input.GwaWa()}</td>
                </tr>
                <tr>
                  <td>AYa</td>
                  <td>{input.AYa()}</td>
                </tr>
                <tr>
                  <td>EuRo</td>
                  <td>{input.EuRo()}</td>
                </tr>
              </tbody>
            </table>
            """);
    }
}
