namespace Bluehill.Hangul.Tests;

public sealed class CharExtensionsTest {
    private const char han = '한';
    private const char mul = '물';
    private const char sae = '새';
    private const char giyeok = 'ㄱ';
    private const char ae = 'ㅐ';
    private const char s = 's';
    private const char one = '1';
    private const char dollarSign = '$';

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(giyeok)]
    [InlineData(ae)]
    public void IsHangul_ReturnTrue(char input) {
        Assert.True(input.IsHangul());
    }

    [Theory]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangul_ReturnFalse(char input) {
        Assert.False(input.IsHangul());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    public void IsHangulSyllable_ReturnTrue(char input) {
        Assert.True(input.IsHangulSyllable());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulSyllable_ReturnFalse(char input) {
        Assert.False(input.IsHangulSyllable());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    public void IsHangulJamo_ReturnTrue(char input) {
        Assert.True(input.IsHangulJamo());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulJamo_ReturnFalse(char input) {
        Assert.False(input.IsHangulJamo());
    }

    [Theory]
    [InlineData(giyeok)]
    public void IsHangulConsonant_ReturnTrue(char input) {
        Assert.True(input.IsHangulConsonant());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(ae)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulConsonantTest(char input) {
        Assert.False(input.IsHangulConsonant());
    }

    [Theory]
    [InlineData(ae)]
    public void IsHangulVowel_ReturnTrue(char input) {
        Assert.True(input.IsHangulVowel());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(giyeok)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulVowel_ReturnFalse(char input) {
        Assert.False(input.IsHangulVowel());
    }

    [Theory]
    [InlineData(han, Choseong.Hieut)]
    [InlineData(mul, Choseong.Mieum)]
    [InlineData(sae, Choseong.Siot)]
    public void Choseong_Equals(char input, Choseong expected) {
        Assert.Equal(expected, input.Choseong());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void Choseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Choseong());
    }

    [Theory]
    [InlineData(han, Jungseong.A)]
    [InlineData(mul, Jungseong.U)]
    [InlineData(sae, Jungseong.Ae)]
    public void Jungseong_Equals(char input, Jungseong expected) {
        Assert.Equal(expected, input.Jungseong());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void Jngseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Jungseong());
    }

    [Theory]
    [InlineData(han, Jongseong.Nieun)]
    [InlineData(mul, Jongseong.Rieul)]
    [InlineData(sae, Jongseong.None)]
    public void Jongseong_Equals(char input, Jongseong expected) {
        Assert.Equal(expected, input.Jongseong());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void Jongseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Jungseong());
    }
}
