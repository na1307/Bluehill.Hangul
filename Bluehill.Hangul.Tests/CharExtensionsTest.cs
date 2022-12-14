namespace Bluehill.Hangul.Tests;

public sealed class CharExtensionsTest {
    const char han = '한';
    const char giyeok = 'ㄱ';
    const char s = 's';

    [Fact]
    public void IsHangulSyllableTest() {
        Assert.True(han.IsHangulSyllable());
        Assert.False(giyeok.IsHangulSyllable());
        Assert.False(s.IsHangulSyllable());
    }

    [Fact]
    public void IsHangulJamoTest() {
        Assert.False(han.IsHangulJamo());
        Assert.True(giyeok.IsHangulJamo());
        Assert.False(s.IsHangulJamo());
    }

    [Fact]
    public void ChoseongTest() {
        Assert.Equal(Choseong.Hieut, han.Choseong());
        Assert.Throws<ArgumentException>("c", () => giyeok.Choseong());
        Assert.Throws<ArgumentException>("c", () => s.Choseong());
    }

    [Fact]
    public void JungseongTest() {
        Assert.Equal(Jungseong.A, han.Jungseong());
        Assert.Throws<ArgumentException>("c", () => giyeok.Jungseong());
        Assert.Throws<ArgumentException>("c", () => s.Jungseong());
    }

    [Fact]
    public void JongseongTest() {
        Assert.Equal(Jongseong.Nieun, han.Jongseong());
        Assert.Throws<ArgumentException>("c", () => giyeok.Jongseong());
        Assert.Throws<ArgumentException>("c", () => s.Jongseong());
    }
}