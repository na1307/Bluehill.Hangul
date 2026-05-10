namespace Bluehill.Hangul.Tests;

public sealed class JosaTest {
    private const string Sagwa = "사과";
    private const string Subak = "수박";
    private const string Gamgyul = "감귤";
    private const string Banana = "Banana";
    private const string Apple = "Apple";
    private const string Watermellon = "Watermellon";
    private const string Yunha = "윤하";
    private const string Hajun = "하준";
    private const string Eunyul = "은율";
    private const string Julie = "Julie";
    private const string Ben = "Ben";
    private const string Michael = "Michael";
    private const string Daegu = "대구";
    private const string Busan = "부산";
    private const string Seoul = "서울";
    private const string California = "California";
    private const string Newyork = "New York";

    [Theory]
    [InlineData(Sagwa, Neun)]
    [InlineData(Subak, Eun)]
    [InlineData(Gamgyul, Eun)]
    [InlineData(Banana, Eun_Neun)]
    [InlineData(Apple, Eun_Neun)]
    [InlineData(Watermellon, Eun_Neun)]
    public void EunNeun_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EunNeun());
    }

    [Theory]
    [InlineData(Banana, Neun)]
    [InlineData(Apple, Eun)]
    [InlineData(Watermellon, Eun)]
    public void EunNeun_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EunNeun(expectedJosa));
    }

    [Theory]
    [InlineData(Banana, Neun)]
    [InlineData(Apple, Eun)]
    [InlineData(Watermellon, Eun)]
    public void EunNeun_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.EunNeun(expectedJosa, true));
    }

    [Theory]
    [InlineData(Yunha, Ga)]
    [InlineData(Hajun, I)]
    [InlineData(Eunyul, I)]
    [InlineData(Julie, I_Ga)]
    [InlineData(Michael, I_Ga)]
    [InlineData(Ben, I_Ga)]
    public void IGa_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.IGa());
    }

    [Theory]
    [InlineData(Julie, Ga)]
    [InlineData(Michael, I)]
    [InlineData(Ben, I)]
    public void IGa_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.IGa(expectedJosa));
    }

    [Theory]
    [InlineData(Julie, Ga)]
    [InlineData(Michael, I)]
    [InlineData(Ben, I)]
    public void IGa_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.IGa(expectedJosa, true));
    }

    [Theory]
    [InlineData(Yunha, "")]
    [InlineData(Hajun, I)]
    [InlineData(Eunyul, I)]
    [InlineData(Julie, "")]
    [InlineData(Michael, "")]
    [InlineData(Ben, "")]
    public void I_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.I());
    }

    [Theory]
    [InlineData(Julie, "")]
    [InlineData(Michael, I)]
    [InlineData(Ben, I)]
    public void I_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.I(expectedJosa));
    }

    [Theory]
    [InlineData(Julie, "")]
    [InlineData(Michael, I)]
    [InlineData(Ben, I)]
    public void I_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.I(expectedJosa, true));
    }

    [Theory]
    [InlineData(Sagwa, Reul)]
    [InlineData(Subak, Eul)]
    [InlineData(Gamgyul, Eul)]
    [InlineData(Banana, Eul_Reul)]
    [InlineData(Apple, Eul_Reul)]
    [InlineData(Watermellon, Eul_Reul)]
    public void EulReul_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EulReul());
    }

    [Theory]
    [InlineData(Banana, Reul)]
    [InlineData(Apple, Eul)]
    [InlineData(Watermellon, Eul)]
    public void EulReul_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EulReul(expectedJosa));
    }

    [Theory]
    [InlineData(Banana, Reul)]
    [InlineData(Apple, Eul)]
    [InlineData(Watermellon, Eul)]
    public void EulReul_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.EulReul(expectedJosa, true));
    }

    [Theory]
    [InlineData(Yunha, Wa)]
    [InlineData(Hajun, Gwa)]
    [InlineData(Eunyul, Gwa)]
    [InlineData(Julie, Gwa_Wa)]
    [InlineData(Michael, Gwa_Wa)]
    [InlineData(Ben, Gwa_Wa)]
    public void GwaWa_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.GwaWa());
    }

    [Theory]
    [InlineData(Julie, Wa)]
    [InlineData(Michael, Gwa)]
    [InlineData(Ben, Gwa)]
    public void GwaWa_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.GwaWa(expectedJosa));
    }

    [Theory]
    [InlineData(Julie, Wa)]
    [InlineData(Michael, Gwa)]
    [InlineData(Ben, Gwa)]
    public void GwaWa_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.GwaWa(expectedJosa, true));
    }

    [Theory]
    [InlineData(Yunha, Ya)]
    [InlineData(Hajun, A)]
    [InlineData(Eunyul, A)]
    [InlineData(Julie, A_Ya)]
    [InlineData(Michael, A_Ya)]
    [InlineData(Ben, A_Ya)]
    public void AYa_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.AYa());
    }

    [Theory]
    [InlineData(Julie, Ya)]
    [InlineData(Michael, A)]
    [InlineData(Ben, A)]
    public void AYa_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.AYa(expectedJosa));
    }

    [Theory]
    [InlineData(Julie, Ya)]
    [InlineData(Michael, A)]
    [InlineData(Ben, A)]
    public void AYa_Test_DefaultJosa_JosaOnly(string str, string expectedJosa) {
        Assert.Equal(expectedJosa, str.AYa(expectedJosa, true));
    }

    [Theory]
    [InlineData(Daegu, Ro)]
    [InlineData(Busan, Euro)]
    [InlineData(Seoul, Ro)]
    [InlineData(California, Eu_Ro)]
    [InlineData(Newyork, Eu_Ro)]
    public void EuRo_Test(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EuRo());
    }

    [Theory]
    [InlineData(California, Ro)]
    [InlineData(Newyork, Euro)]
    public void EuRo_Test_DefaultJosa(string str, string expectedJosa) {
        Assert.Equal(str + expectedJosa, str.EuRo(expectedJosa));
    }

    [Theory]
    [InlineData(California, Ro)]
    [InlineData(Newyork, Euro)]
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
