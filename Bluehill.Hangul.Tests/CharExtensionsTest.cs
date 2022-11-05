namespace Bluehill.Hangul.Tests;

public sealed class CharExtensionsTest {
    const char han = '한';
    const char giyeok = 'ㄱ';
    const char s = 's';

    [Fact]
    public void IsHangulTest() {
        Assert.True(han.IsHangul());
        Assert.False(giyeok.IsHangul());
        Assert.False(s.IsHangul());
    }

    [Fact]
    public void IsJamoTest() {
        Assert.False(han.IsJamo());
        Assert.True(giyeok.IsJamo());
        Assert.False(s.IsJamo());
    }

    [Fact]
    public void ChoseongTest() {
        Assert.Equal(Choseong.Hieut, han.Choseong());
        Assert.Throws<ArgumentException>(() => giyeok.Choseong());
        Assert.Throws<ArgumentException>(() => s.Choseong());
    }

    [Fact]
    public void JungseongTest() {
        Assert.Equal(Jungseong.A, han.Jungseong());
        Assert.Throws<ArgumentException>(() => giyeok.Jungseong());
        Assert.Throws<ArgumentException>(() => s.Jungseong());
    }

    [Fact]
    public void JongseongTest() {
        Assert.Equal(Jongseong.Nieun, han.Jongseong());
        Assert.Throws<ArgumentException>(() => giyeok.Jungseong());
        Assert.Throws<ArgumentException>(() => s.Jungseong());
    }
}