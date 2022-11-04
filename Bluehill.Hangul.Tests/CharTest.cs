namespace Bluehill.Hangul.Tests;

public sealed class CharTest {
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
    public void ToJamoTest() {
        Assert.Equal(Choseong.Hieut, han.Choseong());
        Assert.Equal(Jungseong.A, han.Jungseong());
        Assert.Equal(Jongseong.Nieun, han.Jongseong());
    }

    [Fact]
    public void ToCharTest() {
        Assert.Equal('ㅎ', han.Choseong().ToChar());
        Assert.Equal('ㅏ', han.Jungseong().ToChar());
        Assert.Equal('ㄴ', han.Jongseong().ToChar());
    }
}