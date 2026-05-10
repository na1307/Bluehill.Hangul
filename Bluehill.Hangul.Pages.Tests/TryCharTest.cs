using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Bluehill.Hangul.Pages.Tests;

[SuppressMessage("Naming", "CA1707:식별자에는 밑줄을 사용할 수 없습니다.", Justification = "<보류 중>")]
public sealed class TryCharTest : BunitContext {
    public TryCharTest() {
        Services.AddLocalization();
    }

    [Fact]
    public void TryChar_Results_Empty() {
        var localizer = Services.GetService<IStringLocalizer<TryChar>>()!;

        // Act
        var cut = Render<TryChar>();

        // Assert
        cut.Find("table#results").MarkupMatches($"""
                                                 <table id="results" class="table">
                                                   <thead>
                                                     <tr>
                                                       <th>{localizer.GetString("Char")}</th>
                                                       <th>{localizer.GetString("Choseong")}</th>
                                                       <th>{localizer.GetString("Jungseong")}</th>
                                                       <th>{localizer.GetString("Jongseong")}</th>
                                                     </tr>
                                                   </thead>
                                                   <tbody></tbody>
                                                 </table>
                                                 """);
    }

    [Theory]
    [InlineData("나는 사과를 먹는다.")]
    [InlineData("Word bird wondering i desolate this then flutter and tufted sure i memories more thereis memories felt saintly land as")]
    public void TryChar_Results_Inputs(string input) {
        var localizer = Services.GetService<IStringLocalizer<TryChar>>()!;

        // Act
        var cut = Render<TryChar>();

        cut.Find("input#input").Change(input);

        // Assert
        cut.Find("table#results").MarkupMatches($"""
                                                 <table id="results" class="table">
                                                   <thead>
                                                     <tr>
                                                       <th>{localizer.GetString("Char")}</th>
                                                       <th>{localizer.GetString("Choseong")}</th>
                                                       <th>{localizer.GetString("Jungseong")}</th>
                                                       <th>{localizer.GetString("Jongseong")}</th>
                                                     </tr>
                                                   </thead>
                                                   <tbody>
                                                 """ + getOutput() + """
                                                                       </tbody>
                                                                     </table>
                                                                     """);

        string getOutput() {
            StringBuilder builder = new();

            foreach (var c in input) {
                builder.Append($"""
                                <tr>
                                    <td>{c}</td>
                                """);

                if (c.IsHangulSyllable()) {
                    builder.Append($"""
                                        <td>{$"{c.Choseong().ToJamo()} ({c.Choseong()})"} </td>
                                        <td>{$"{c.Jungseong().ToJamo()} ({c.Jungseong()})"} </td>
                                        <td>{(c.Jongseong() != Jongseong.None ? $"{c.Jongseong().ToJamo()} ({c.Jongseong()})" : $"{localizer.GetString("NoneJongseong")} ({Jongseong.None})")}</td>
                                    """);
                } else {
                    builder.Append($"""
                                        <td colspan="3" style="text-align: center;">{localizer.GetString("NotHangulSyllable")}</td>
                                    """);
                }

                builder.Append("""
                               </tr>
                               """);
            }

            return builder.ToString();
        }
    }
}
