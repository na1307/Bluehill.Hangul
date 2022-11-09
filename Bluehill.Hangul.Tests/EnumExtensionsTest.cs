namespace Bluehill.Hangul.Tests;

public sealed class EnumExtensionsTest {
    [Fact]
    public void ToCharTest1() {
        Assert.Equal('ㅇ', Choseong.Ieung.ToChar());
    }

    [Fact]
    public void ToCharTest2() {
        Assert.Equal('ㅏ', Jungseong.A.ToChar());
    }

    [Fact]
    public void ToCharTest3() {
        Assert.Equal('ㄴ', Jongseong.Nieun.ToChar());
    }
}