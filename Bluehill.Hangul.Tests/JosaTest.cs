namespace Bluehill.Hangul.Tests;

public sealed class JosaTest {
    private const string sagwa = "사과";
    private const string subak = "수박";
    private const string gamgyul = "감귤";
    private const string banana = "Banana";
    private const string apple = "Apple";
    private const string watermellon = "Watermellon";
    private const string yunha = "윤하";
    private const string hajun = "하준";
    private const string eunyul = "은율";
    private const string julie = "Julie";
    private const string ben = "Ben";
    private const string michael = "Michael";
    private const string daegu = "대구";
    private const string busan = "부산";
    private const string seoul = "서울";
    private const string california = "California";
    private const string newyork = "New York";

    [Theory]
    [InlineData(sagwa, Neun)]
    [InlineData(subak, Eun)]
    [InlineData(gamgyul, Eun)]
    [InlineData(banana, Eun_Neun)]
    [InlineData(apple, Eun_Neun)]
    [InlineData(watermellon, Eun_Neun)]
    public void EunNeun_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EunNeun());
    }

    [Theory]
    [InlineData(banana, Neun)]
    [InlineData(apple, Eun)]
    [InlineData(watermellon, Eun)]
    public void EunNeun_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EunNeun(expectedJosa));
    }

    [Theory]
    [InlineData(banana, Neun)]
    [InlineData(apple, Eun)]
    [InlineData(watermellon, Eun)]
    public void EunNeun_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.EunNeun(expectedJosa, true));
    }

    [Theory]
    [InlineData(yunha, Ga)]
    [InlineData(hajun, I)]
    [InlineData(eunyul, I)]
    [InlineData(julie, I_Ga)]
    [InlineData(michael, I_Ga)]
    [InlineData(ben, I_Ga)]
    public void IGa_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.IGa());
    }

    [Theory]
    [InlineData(julie, Ga)]
    [InlineData(michael, I)]
    [InlineData(ben, I)]
    public void IGa_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.IGa(expectedJosa));
    }

    [Theory]
    [InlineData(julie, Ga)]
    [InlineData(michael, I)]
    [InlineData(ben, I)]
    public void IGa_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.IGa(expectedJosa, true));
    }

    [Theory]
    [InlineData(yunha, "")]
    [InlineData(hajun, I)]
    [InlineData(eunyul, I)]
    [InlineData(julie, "")]
    [InlineData(michael, "")]
    [InlineData(ben, "")]
    public void I_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.I());
    }

    [Theory]
    [InlineData(julie, "")]
    [InlineData(michael, I)]
    [InlineData(ben, I)]
    public void I_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.I(expectedJosa));
    }

    [Theory]
    [InlineData(julie, "")]
    [InlineData(michael, I)]
    [InlineData(ben, I)]
    public void I_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.I(expectedJosa, true));
    }

    [Theory]
    [InlineData(sagwa, Reul)]
    [InlineData(subak, Eul)]
    [InlineData(gamgyul, Eul)]
    [InlineData(banana, Eul_Reul)]
    [InlineData(apple, Eul_Reul)]
    [InlineData(watermellon, Eul_Reul)]
    public void EulReul_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EulReul());
    }

    [Theory]
    [InlineData(banana, Reul)]
    [InlineData(apple, Eul)]
    [InlineData(watermellon, Eul)]
    public void EulReul_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EulReul(expectedJosa));
    }

    [Theory]
    [InlineData(banana, Reul)]
    [InlineData(apple, Eul)]
    [InlineData(watermellon, Eul)]
    public void EulReul_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.EulReul(expectedJosa, true));
    }

    [Theory]
    [InlineData(yunha, Wa)]
    [InlineData(hajun, Gwa)]
    [InlineData(eunyul, Gwa)]
    [InlineData(julie, Gwa_Wa)]
    [InlineData(michael, Gwa_Wa)]
    [InlineData(ben, Gwa_Wa)]
    public void GwaWa_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.GwaWa());
    }

    [Theory]
    [InlineData(julie, Wa)]
    [InlineData(michael, Gwa)]
    [InlineData(ben, Gwa)]
    public void GwaWa_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.GwaWa(expectedJosa));
    }

    [Theory]
    [InlineData(julie, Wa)]
    [InlineData(michael, Gwa)]
    [InlineData(ben, Gwa)]
    public void GwaWa_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.GwaWa(expectedJosa, true));
    }

    [Theory]
    [InlineData(yunha, Ya)]
    [InlineData(hajun, A)]
    [InlineData(eunyul, A)]
    [InlineData(julie, A_Ya)]
    [InlineData(michael, A_Ya)]
    [InlineData(ben, A_Ya)]
    public void AYa_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.AYa());
    }

    [Theory]
    [InlineData(julie, Ya)]
    [InlineData(michael, A)]
    [InlineData(ben, A)]
    public void AYa_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.AYa(expectedJosa));
    }

    [Theory]
    [InlineData(julie, Ya)]
    [InlineData(michael, A)]
    [InlineData(ben, A)]
    public void AYa_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.AYa(expectedJosa, true));
    }

    [Theory]
    [InlineData(daegu, Ro)]
    [InlineData(busan, Euro)]
    [InlineData(seoul, Ro)]
    [InlineData(california, Eu_Ro)]
    [InlineData(newyork, Eu_Ro)]
    public void EuRo_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EuRo());
    }

    [Theory]
    [InlineData(california, Ro)]
    [InlineData(newyork, Euro)]
    public void EuRo_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EuRo(expectedJosa));
    }

    [Theory]
    [InlineData(california, Ro)]
    [InlineData(newyork, Euro)]
    public void EuRo_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.EuRo(expectedJosa, true));
    }

    [Fact]
    public void Jongseong_StrIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.Jongseong(null!, string.Empty, string.Empty, string.Empty, false));
    }

    [Fact]
    public void Jongseong_DefaultJosaIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.Jongseong(string.Empty, null!, string.Empty, string.Empty, false));
    }

    [Fact]
    public void Jongseong_JongseongIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.Jongseong(string.Empty, string.Empty, null!, string.Empty, false));
    }

    [Fact]
    public void Jongseong_NoJongseongIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.Jongseong(string.Empty, string.Empty, string.Empty, null!, false));
    }

    [Fact]
    public void NoJongseongOrRieul_StrIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.NoJongseongOrRieul(null!, string.Empty, string.Empty, string.Empty, false));
    }

    [Fact]
    public void NoJongseongOrRieul_DefaultJosaIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.NoJongseongOrRieul(string.Empty, null!, string.Empty, string.Empty, false));
    }

    [Fact]
    public void NoJongseongOrRieul_RieulIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.NoJongseongOrRieul(string.Empty, string.Empty, null!, string.Empty, false));
    }

    [Fact]
    public void NoJongseongOrRieul_NoRieulIsNull_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(() => Josa.NoJongseongOrRieul(string.Empty, string.Empty, string.Empty, null!, false));
    }
}
