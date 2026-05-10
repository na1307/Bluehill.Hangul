namespace Bluehill.Hangul.Tests;

public sealed class CharExtensionsTest {
    private const char Han = '한';
    private const char Mul = '물';
    private const char Sae = '새';
    private const char Giyeok = 'ㄱ';
    private const char Ae = 'ㅐ';
    private const char IpfChosesongNieun = 'ᄂ';
    private const char IpfJungseongO = 'ᅩ';
    private const char IpfJongseongRieul = 'ᆯ';
    private const char S = 's';
    private const char One = '1';
    private const char DollarSign = '$';

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    public void IsHangul_ReturnTrue(char input) {
        Assert.True(input.IsHangul());
    }

    [Theory]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangul_ReturnFalse(char input) {
        Assert.False(input.IsHangul());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    public void IsHangulSyllable_ReturnTrue(char input) {
        Assert.True(input.IsHangulSyllable());
    }

    [Theory]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangulSyllable_ReturnFalse(char input) {
        Assert.False(input.IsHangulSyllable());
    }

    [Theory]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    public void IsHangulJamo_ReturnTrue(char input) {
        Assert.True(input.IsHangulJamo());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangulJamo_ReturnFalse(char input) {
        Assert.False(input.IsHangulJamo());
    }

    [Theory]
    [InlineData(Giyeok)]
    public void IsHangulConsonant_ReturnTrue(char input) {
        Assert.True(input.IsHangulConsonant());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(Ae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangulConsonantTest(char input) {
        Assert.False(input.IsHangulConsonant());
    }

    [Theory]
    [InlineData(Ae)]
    public void IsHangulVowel_ReturnTrue(char input) {
        Assert.True(input.IsHangulVowel());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(Giyeok)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangulVowel_ReturnFalse(char input) {
        Assert.False(input.IsHangulVowel());
    }

    [Theory]
    [InlineData(IpfChosesongNieun)]
    public void IsHangulIPFChoseong_ReturnTrue(char input) {
        Assert.True(input.IsHangulIPFChoseong());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangulIPFChoseong_ReturnFalse(char input) {
        Assert.False(input.IsHangulIPFChoseong());
    }

    [Theory]
    [InlineData(IpfJungseongO)]
    public void IsHangulIPFJungseong_ReturnTrue(char input) {
        Assert.True(input.IsHangulIPFJungseong());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangulIPFJungseong_ReturnFalse(char input) {
        Assert.False(input.IsHangulIPFJungseong());
    }

    [Theory]
    [InlineData(IpfJongseongRieul)]
    public void IsHangulIPFJongseong_ReturnTrue(char input) {
        Assert.True(input.IsHangulIPFJongseong());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void IsHangulIPFJongseong_ReturnFalse(char input) {
        Assert.False(input.IsHangulIPFJongseong());
    }

    [Theory]
    [InlineData(Han, Choseong.Hieut)]
    [InlineData(Mul, Choseong.Mieum)]
    [InlineData(Sae, Choseong.Siot)]
    public void Choseong_Equal(char input, Choseong expected) {
        Assert.Equal(expected, input.Choseong());
    }

    [Theory]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void Choseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Choseong());
    }

    [Theory]
    [InlineData(Han, Jungseong.A)]
    [InlineData(Mul, Jungseong.U)]
    [InlineData(Sae, Jungseong.Ae)]
    public void Jungseong_Equal(char input, Jungseong expected) {
        Assert.Equal(expected, input.Jungseong());
    }

    [Theory]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void Jungseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Jungseong());
    }

    [Theory]
    [InlineData(Han, Jongseong.Nieun)]
    [InlineData(Mul, Jongseong.Rieul)]
    [InlineData(Sae, Jongseong.None)]
    public void Jongseong_Equal(char input, Jongseong expected) {
        Assert.Equal(expected, input.Jongseong());
    }

    [Theory]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(IpfChosesongNieun)]
    [InlineData(IpfJungseongO)]
    [InlineData(IpfJongseongRieul)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
    public void Jongseong_ThrowsArgumentException(char input) {
        Assert.Throws<ArgumentException>("c", () => input.Jungseong());
    }

    [Theory]
    [InlineData(IpfChosesongNieun, 'ㄴ')]
    [InlineData(IpfJungseongO, 'ㅗ')]
    [InlineData(IpfJongseongRieul, 'ㄹ')]
    public void ToCompatibilityJamo_Equal(char input, char expected) {
        Assert.Equal(expected, input.ToCompatibilityJamo());
    }

    [Theory]
    [InlineData(Han)]
    [InlineData(Mul)]
    [InlineData(Sae)]
    [InlineData(Giyeok)]
    [InlineData(Ae)]
    [InlineData(S)]
    [InlineData(One)]
    [InlineData(DollarSign)]
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
