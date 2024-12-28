namespace Bluehill.Hangul.Tests;

public sealed class EnumExtensionsTest {
    [Fact]
    public void ToJamoTest1() {
        Assert.Equal('ㅇ', Choseong.Ieung.ToJamo());
    }

    [Fact]
    public void ToJamoTest2() {
        Assert.Equal('ㅏ', Jungseong.A.ToJamo());
    }

    [Fact]
    public void ToJamoTest3() {
        Assert.Equal('ㄴ', Jongseong.Nieun.ToJamo());
    }
}
