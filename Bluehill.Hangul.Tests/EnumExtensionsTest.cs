namespace Bluehill.Hangul.Tests;

public sealed class EnumExtensionsTest {
    [Fact]
    public void ToCharTest() {
        Assert.Equal('ㅇ', Choseong.Ieung.ToChar());
        Assert.Equal('ㅏ', Jungseong.A.ToChar());
        Assert.Equal('ㄴ', Jongseong.Nieun.ToChar());
    }
}