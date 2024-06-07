namespace Bluehill.Hangul.Tests;

public sealed class CharExtensionsTest {
    private const char han = '한';
    private const char mul = '물';
    private const char sae = '새';
    private const char giyeok = 'ㄱ';
    private const char ae = 'ㅐ';
    private const char ipfChosesongNieun = 'ᄂ';
    private const char ipfJungseongO = 'ᅩ';
    private const char ipfJongseongRieul = 'ᆯ';
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
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
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
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
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
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
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
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
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
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulVowel_ReturnFalse(char input) {
        Assert.False(input.IsHangulVowel());
    }

    [Theory]
    [InlineData(ipfChosesongNieun)]
    public void IsHangulIPFChoseong_ReturnTrue(char input) {
        Assert.True(input.IsHangulIPFChoseong());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulIPFChoseong_ReturnFalse(char input) {
        Assert.False(input.IsHangulIPFChoseong());
    }

    [Theory]
    [InlineData(ipfJungseongO)]
    public void IsHangulIPFJungseong_ReturnTrue(char input) {
        Assert.True(input.IsHangulIPFJungseong());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJongseongRieul)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulIPFJungseong_ReturnFalse(char input) {
        Assert.False(input.IsHangulIPFJungseong());
    }

    [Theory]
    [InlineData(ipfJongseongRieul)]
    public void IsHangulIPFJongseong_ReturnTrue(char input) {
        Assert.True(input.IsHangulIPFJongseong());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void IsHangulIPFJongseong_ReturnFalse(char input) {
        Assert.False(input.IsHangulIPFJongseong());
    }

    [Theory]
    [InlineData(han, Choseong.Hieut)]
    [InlineData(mul, Choseong.Mieum)]
    [InlineData(sae, Choseong.Siot)]
    public void Choseong_Equal(char input, Choseong expected) {
        Assert.Equal(expected, input.Choseong());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
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
    public void Jungseong_Equal(char input, Jungseong expected) {
        Assert.Equal(expected, input.Jungseong());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void Jungseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Jungseong());
    }

    [Theory]
    [InlineData(han, Jongseong.Nieun)]
    [InlineData(mul, Jongseong.Rieul)]
    [InlineData(sae, Jongseong.None)]
    public void Jongseong_Equal(char input, Jongseong expected) {
        Assert.Equal(expected, input.Jongseong());
    }

    [Theory]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(ipfChosesongNieun)]
    [InlineData(ipfJungseongO)]
    [InlineData(ipfJongseongRieul)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void Jongseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Jungseong());
    }

    [Theory]
    [InlineData(ipfChosesongNieun, 'ㄴ')]
    [InlineData(ipfJungseongO, 'ㅗ')]
    [InlineData(ipfJongseongRieul, 'ㄹ')]
    public void ToCompatibilityJamo_Equal(char input, char expected) {
        Assert.Equal(expected, input.ToCompatibilityJamo());
    }

    [Theory]
    [InlineData(han)]
    [InlineData(mul)]
    [InlineData(sae)]
    [InlineData(giyeok)]
    [InlineData(ae)]
    [InlineData(s)]
    [InlineData(one)]
    [InlineData(dollarSign)]
    public void ToCompatibilityJamo_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("ipfJamo", () => input.ToCompatibilityJamo());
    }

    [Fact]
    public void ToCompatibilityJamo_TableTest() {
        for (var choi = 0; choi <= LastIPFChoseong - FirstIPFChoseong; choi++) {
            Assert.Equal(Internal.Choseongs[choi], ((char)(FirstIPFChoseong + choi)).ToCompatibilityJamo());
        }

        for (var jungi = 0; jungi <= LastIPFJungseong - FirstIPFJungseong; jungi++) {
            Assert.Equal(Internal.Jungseongs[jungi], ((char)(FirstIPFJungseong + jungi)).ToCompatibilityJamo());
        }

        for (var jongi = 0; jongi <= LastIPFJongseong - FirstIPFJongseong; jongi++) {
            Assert.Equal(Internal.Jongseongs[jongi + 1], ((char)(FirstIPFJongseong + jongi)).ToCompatibilityJamo());
        }
    }
}
