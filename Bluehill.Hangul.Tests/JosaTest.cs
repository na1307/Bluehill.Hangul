namespace Bluehill.Hangul.Tests;

public sealed class JosaTest {
    const string sagwa = "사과";
    const string subak = "수박";
    const string gamgyul = "감귤";
    const string apple = "Apple";
    const string watermellon = "Watermellon";
    const string yunha = "윤하";
    const string hajun = "하준";
    const string eunyul = "은율";
    const string michael = "Michael";
    const string ben = "Ben";
    const string daegu = "대구";
    const string busan = "부산";
    const string seoul = "서울";
    const string california = "California";
    const string newyork = "New York";

    [Fact]
    public void EunNeunTest() {
        // Expressions
        var r1 = sagwa.EunNeun();
        var r2 = subak.EunNeun();
        var r3 = gamgyul.EunNeun();
        var r4 = apple.EunNeun();
        var r5 = watermellon.EunNeun(Eun);
        var r6 = sagwa.EunNeun(Eul_Reul, true);

        // Expected
        const string e1 = sagwa + Neun;
        const string e2 = subak + Eun;
        const string e3 = gamgyul + Eun;
        const string e4 = apple + Eun_Neun;
        const string e5 = watermellon + Eun;
        const string e6 = Neun;

        // Asserts
        Assert.Equal(expected: e1, actual: r1);
        Assert.Equal(expected: e2, actual: r2);
        Assert.Equal(expected: e3, actual: r3);
        Assert.Equal(expected: e4, actual: r4);
        Assert.Equal(expected: e5, actual: r5);
        Assert.Equal(expected: e6, actual: r6);
    }

    [Fact]
    public void IGaTest() {
        // Expressions
        var r1 = yunha.IGa();
        var r2 = hajun.IGa();
        var r3 = eunyul.IGa();
        var r4 = michael.IGa();
        var r5 = ben.IGa(I);
        var r6 = yunha.IGa(I_Ga, true);

        // Expected
        const string e1 = yunha + Ga;
        const string e2 = hajun + I;
        const string e3 = eunyul + I;
        const string e4 = michael + I_Ga;
        const string e5 = ben + I;
        const string e6 = Ga;

        // Asserts
        Assert.Equal(expected: e1, actual: r1);
        Assert.Equal(expected: e2, actual: r2);
        Assert.Equal(expected: e3, actual: r3);
        Assert.Equal(expected: e4, actual: r4);
        Assert.Equal(expected: e5, actual: r5);
        Assert.Equal(expected: e6, actual: r6);
    }

    [Fact]
    public void ITest() {
        // Expressions
        var r1 = yunha.I();
        var r2 = hajun.I();
        var r3 = eunyul.I();
        var r4 = michael.I();
        var r5 = ben.I(I);
        var r6 = yunha.I(string.Empty, true);

        // Expected
        const string e1 = yunha;
        const string e2 = hajun + I;
        const string e3 = eunyul + I;
        const string e4 = michael;
        const string e5 = ben + I;
        const string e6 = "";

        // Asserts
        Assert.Equal(expected: e1, actual: r1);
        Assert.Equal(expected: e2, actual: r2);
        Assert.Equal(expected: e3, actual: r3);
        Assert.Equal(expected: e4, actual: r4);
        Assert.Equal(expected: e5, actual: r5);
        Assert.Equal(expected: e6, actual: r6);
    }

    [Fact]
    public void EulReulTest() {
        // Expressions
        var r1 = sagwa.EulReul();
        var r2 = subak.EulReul();
        var r3 = gamgyul.EulReul();
        var r4 = apple.EulReul();
        var r5 = watermellon.EulReul(Eul);
        var r6 = sagwa.EulReul(Eul_Reul, true);

        // Expected
        const string e1 = sagwa + Reul;
        const string e2 = subak + Eul;
        const string e3 = gamgyul + Eul;
        const string e4 = apple + Eul_Reul;
        const string e5 = watermellon + Eul;
        const string e6 = Reul;

        // Asserts
        Assert.Equal(expected: e1, actual: r1);
        Assert.Equal(expected: e2, actual: r2);
        Assert.Equal(expected: e3, actual: r3);
        Assert.Equal(expected: e4, actual: r4);
        Assert.Equal(expected: e5, actual: r5);
        Assert.Equal(expected: e6, actual: r6);
    }

    [Fact]
    public void GwaWaTest() {
        // Expressions
        var r1 = yunha.GwaWa();
        var r2 = hajun.GwaWa();
        var r3 = eunyul.GwaWa();
        var r4 = michael.GwaWa();
        var r5 = ben.GwaWa(Gwa);
        var r6 = yunha.GwaWa(Gwa_Wa, true);

        // Expected
        const string e1 = yunha + Wa;
        const string e2 = hajun + Gwa;
        const string e3 = eunyul + Gwa;
        const string e4 = michael + Gwa_Wa;
        const string e5 = ben + Gwa;
        const string e6 = Wa;

        // Asserts
        Assert.Equal(expected: e1, actual: r1);
        Assert.Equal(expected: e2, actual: r2);
        Assert.Equal(expected: e3, actual: r3);
        Assert.Equal(expected: e4, actual: r4);
        Assert.Equal(expected: e5, actual: r5);
        Assert.Equal(expected: e6, actual: r6);
    }

    [Fact]
    public void AYaTest() {
        // Expressions
        var r1 = yunha.AYa();
        var r2 = hajun.AYa();
        var r3 = eunyul.AYa();
        var r4 = michael.AYa();
        var r5 = ben.AYa(A);
        var r6 = yunha.AYa(A_Ya, true);

        // Expected
        const string e1 = yunha + Ya;
        const string e2 = hajun + A;
        const string e3 = eunyul + A;
        const string e4 = michael + A_Ya;
        const string e5 = ben + A;
        const string e6 = Ya;

        // Asserts
        Assert.Equal(expected: e1, actual: r1);
        Assert.Equal(expected: e2, actual: r2);
        Assert.Equal(expected: e3, actual: r3);
        Assert.Equal(expected: e4, actual: r4);
        Assert.Equal(expected: e5, actual: r5);
        Assert.Equal(expected: e6, actual: r6);
    }

    [Fact]
    public void EuRoTest() {
        // Expressions
        var r1 = daegu.EuRo();
        var r2 = busan.EuRo();
        var r3 = seoul.EuRo();
        var r4 = california.EuRo();
        var r5 = newyork.EuRo(Euro);
        var r6 = daegu.EuRo(Eu_Ro, true);

        // Expected
        const string e1 = daegu + Ro;
        const string e2 = busan + Euro;
        const string e3 = seoul + Ro;
        const string e4 = california + Eu_Ro;
        const string e5 = newyork + Euro;
        const string e6 = Ro;

        // Asserts
        Assert.Equal(expected: e1, actual: r1);
        Assert.Equal(expected: e2, actual: r2);
        Assert.Equal(expected: e3, actual: r3);
        Assert.Equal(expected: e4, actual: r4);
        Assert.Equal(expected: e5, actual: r5);
        Assert.Equal(expected: e6, actual: r6);
    }
}