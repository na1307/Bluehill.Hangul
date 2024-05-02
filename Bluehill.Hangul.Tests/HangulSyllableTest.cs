namespace Bluehill.Hangul.Tests;

public sealed class HangulSyllableTest {
    private static readonly HangulSyllable gaChar = new('가');
    private static readonly HangulSyllable hitChar = new('힣');

    [Fact]
    public void ConstructorTest1() {
        _ = new HangulSyllable() { Value = '갈' };
        Assert.Throws<ArgumentException>("value", () => new HangulSyllable() { Value = 'e' });
    }

    [Fact]
    public void ConstructorTest2() {
        Assert.Throws<ArgumentException>("c", () => new HangulSyllable('e'));
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "Not Needed")]
    public void ConstructorTest3() {
        _ = new HangulSyllable(Choseong.Giyeok, Jungseong.A, Jongseong.None);
    }

    [Fact]
    public void ConstructorTest4() {
        _ = new HangulSyllable(1, 2, 3);
        Assert.Throws<ArgumentOutOfRangeException>("choseong", () => new HangulSyllable(19, 0, 0));
        Assert.Throws<ArgumentOutOfRangeException>("jungseong", () => new HangulSyllable(0, 21, 0));
        Assert.Throws<ArgumentOutOfRangeException>("jongseong", () => new HangulSyllable(0, 0, 28));
    }

    [Fact]
    public void ConstructorTest5() {
        _ = new HangulSyllable('ㄱ', 'ㅏ', 'ㅎ');
        Assert.Throws<ArgumentException>("choseong", () => new HangulSyllable('ㅐ', 'ㅏ', 'ㅎ'));
        Assert.Throws<ArgumentException>("jungseong", () => new HangulSyllable('ㄱ', 'ㄴ', 'ㅎ'));
        Assert.Throws<ArgumentException>("jongseong", () => new HangulSyllable('ㄱ', 'ㅏ', 'ㅛ'));
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "<보류 중>")]
    public void ValueTest1() {
        _ = new HangulSyllable() { Value = gaChar };
    }

    [Fact]
    public void ValueTest2() {
        Assert.Throws<ArgumentException>(() => new HangulSyllable() { Value = 'c' });
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "<보류 중>")]
    public void ValueTest3() {
        _ = new HangulSyllable() { Value = gaChar }.Value;
    }

    [Fact]
    public void ValueTest4() {
        Assert.Throws<InvalidOperationException>(() => _ = ((HangulSyllable)default).Value);
    }

    [Fact]
    public void ChoseongTest() {
        Assert.Equal(Choseong.Giyeok, HangulSyllable.MinValue.Choseong);
        Assert.Throws<InvalidOperationException>(() => default(HangulSyllable).Choseong);
    }

    [Fact]
    public void JungseongTest() {
        Assert.Equal(Jungseong.A, HangulSyllable.MinValue.Jungseong);
        Assert.Throws<InvalidOperationException>(() => default(HangulSyllable).Jungseong);
    }

    [Fact]
    public void JongseongTest() {
        Assert.Equal(Jongseong.None, HangulSyllable.MinValue.Jongseong);
        Assert.Throws<InvalidOperationException>(() => default(HangulSyllable).Jongseong);
    }

    [Fact]
    public void ExplicitOperatorTest() {
        _ = (HangulSyllable)'가';
        Assert.Throws<ArgumentException>("c", () => (HangulSyllable)'s');
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "Not Needed")]
    public void ImplicitOperatorTest() {
        _ = (char)gaChar;
    }

    [Fact]
    public void EqualityOperatorTest() {
        Assert.True(gaChar == HangulSyllable.MinValue);
        Assert.False(gaChar == HangulSyllable.MaxValue);
        Assert.False(hitChar == HangulSyllable.MinValue);
        Assert.True(hitChar == HangulSyllable.MaxValue);
    }

    [Fact]
    public void InequalityOperatorTest() {
        Assert.False(gaChar != HangulSyllable.MinValue);
        Assert.True(gaChar != HangulSyllable.MaxValue);
        Assert.True(hitChar != HangulSyllable.MinValue);
        Assert.False(hitChar != HangulSyllable.MaxValue);
    }

    [Fact]
    public void LessThanOperatorTest() {
        Assert.False(gaChar < HangulSyllable.MinValue);
        Assert.True(gaChar < HangulSyllable.MaxValue);
        Assert.False(hitChar < HangulSyllable.MinValue);
        Assert.False(hitChar < HangulSyllable.MaxValue);
    }

    [Fact]
    public void LessThanOrEqualOperatorTest() {
        Assert.True(gaChar <= HangulSyllable.MinValue);
        Assert.True(gaChar <= HangulSyllable.MaxValue);
        Assert.False(hitChar <= HangulSyllable.MinValue);
        Assert.True(hitChar <= HangulSyllable.MaxValue);
    }

    [Fact]
    public void GreaterThanOperatorTest() {
        Assert.False(gaChar > HangulSyllable.MinValue);
        Assert.False(gaChar > HangulSyllable.MaxValue);
        Assert.True(hitChar > HangulSyllable.MinValue);
        Assert.False(hitChar > HangulSyllable.MaxValue);
    }

    [Fact]
    public void GreaterThanOrEqualOperatorTest() {
        Assert.True(gaChar >= HangulSyllable.MinValue);
        Assert.False(gaChar >= HangulSyllable.MaxValue);
        Assert.True(hitChar >= HangulSyllable.MinValue);
        Assert.True(hitChar >= HangulSyllable.MaxValue);
    }

    [Fact]
    public void ToStringTest() {
        Assert.Equal("가", HangulSyllable.MinValue.ToString());
    }

    [Fact]
    public void EqualsTest1() {
        Assert.True(gaChar.Equals(HangulSyllable.MinValue));
        Assert.False(gaChar.Equals(HangulSyllable.MaxValue));
    }

    [Fact]
    public void EqualsTest2() {
        Assert.True(gaChar.Equals((object)HangulSyllable.MinValue));
        Assert.False(gaChar.Equals((object)HangulSyllable.MaxValue));
        Assert.False(gaChar.Equals(HangulSyllable.MinValue.Value));
    }

    [Fact]
    public void GetHashCodeTest() {
        Assert.Equal(HangulSyllable.MinValue.GetHashCode(), gaChar.GetHashCode());
        Assert.Equal(gaChar.Value.GetHashCode(), gaChar.GetHashCode());
    }

    [Fact]
    public void DeconstructTest() {
        var (choseong, jungseong, jongseong) = hitChar;

        Assert.Equal(Choseong.Hieut, choseong);
        Assert.Equal(Jungseong.I, jungseong);
        Assert.Equal(Jongseong.Hieut, jongseong);
    }
}
