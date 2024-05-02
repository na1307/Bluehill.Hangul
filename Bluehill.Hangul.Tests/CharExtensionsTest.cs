namespace Bluehill.Hangul.Tests;

public sealed class CharExtensionsTest {
    private const char han = '한';
    private const char giyeok = 'ㄱ';
    private const char ae = 'ㅐ';
    private const char s = 's';

    [Fact]
    public void IsHangulTest() {
        Assert.True(han.IsHangul());
        Assert.True(giyeok.IsHangul());
        Assert.True(ae.IsHangul());
        Assert.False(s.IsHangul());
    }

    [Fact]
    public void IsHangulSyllableTest() {
        Assert.True(han.IsHangulSyllable());
        Assert.False(giyeok.IsHangulSyllable());
        Assert.False(ae.IsHangulSyllable());
        Assert.False(s.IsHangulSyllable());
    }

    [Fact]
    public void IsHangulJamoTest() {
        Assert.False(han.IsHangulJamo());
        Assert.True(giyeok.IsHangulJamo());
        Assert.True(ae.IsHangulJamo());
        Assert.False(s.IsHangulJamo());
    }

    [Fact]
    public void IsHangulConsonantTest() {
        Assert.False(han.IsHangulConsonant());
        Assert.True(giyeok.IsHangulConsonant());
        Assert.False(ae.IsHangulConsonant());
        Assert.False(s.IsHangulConsonant());
    }

    [Fact]
    public void IsHangulVowelTest() {
        Assert.False(han.IsHangulVowel());
        Assert.False(giyeok.IsHangulVowel());
        Assert.True(ae.IsHangulVowel());
        Assert.False(s.IsHangulVowel());
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
