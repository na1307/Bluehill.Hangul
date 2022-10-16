namespace Bluehill.Hangul;

public static class Josa {
    private const string eun_neun = "은(는)";
    private const string eun = "은";
    private const string neun = "는";
    private const string i_ga = "이(가)";
    private const string i = "이";
    private const string ga = "가";
    private const string eul_reul = "을(를)";
    private const string eul = "을";
    private const string reul = "를";
    private const string gwa_wa = "과(와)";
    private const string gwa = "과";
    private const string wa = "와";
    private const string a_ya = "아(야)";
    private const string a = "아";
    private const string ya = "야";
    private const string eu_ro = "(으)로";
    private const string ro = "로";
    private const string euro = "으로";

    public static string Jongseong(this string str, string defaultJosa, string jongseong, string noJongseong, bool josaOnly) {
        var text = !josaOnly ? str : null;

        // 한글이 아니라면
        if (str[str.Length - 1] is < '가' or > '힣') return text + defaultJosa;

        return text + (((str[str.Length - 1] - 44032) % 28) == 0 ? noJongseong : jongseong);
    }

    public static string NoJongseongOrRieul(this string str, string defaultJosa, string rieul, string noRieul, bool josaOnly) {
        var text = !josaOnly ? str : null;

        // 한글이 아니라면
        if (str[str.Length - 1] is < '가' or > '힣') return text + defaultJosa;

        return text + (((str[str.Length - 1] - 44032) % 28) is 0 or 8 ? rieul : noRieul);
    }

    public static string EunNeun(this string str) => EunNeun(str, eun_neun);
    public static string EunNeun(this string str, string defaultJosa) => EunNeun(str, defaultJosa, false);
    public static string EunNeun(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, eun, neun, josaOnly);
    public static string I(this string str) => I(str, string.Empty);
    public static string I(this string str, string defaultJosa) => I(str, defaultJosa, false);
    public static string I(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, i, string.Empty, josaOnly);
    public static string IGa(this string str) => IGa(str, i_ga);
    public static string IGa(this string str, string defaultJosa) => IGa(str, defaultJosa, false);
    public static string IGa(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, i, ga, josaOnly);
    public static string EulReul(this string str) => EulReul(str, eul_reul);
    public static string EulReul(this string str, string defaultJosa) => EulReul(str, defaultJosa, false);
    public static string EulReul(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, eul, reul, josaOnly);
    public static string GwaWa(this string str) => GwaWa(str, gwa_wa);
    public static string GwaWa(this string str, string defaultJosa) => GwaWa(str, defaultJosa, false);
    public static string GwaWa(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, gwa, wa, josaOnly);
    public static string AYa(this string str) => AYa(str, a_ya);
    public static string AYa(this string str, string defaultJosa) => AYa(str, defaultJosa, false);
    public static string AYa(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, a, ya, josaOnly);
    public static string EuRo(this string str) => EuRo(str, eu_ro);
    public static string EuRo(this string str, string defaultJosa) => EuRo(str, defaultJosa, false);
    public static string EuRo(this string str, string defaultJosa, bool josaOnly) => NoJongseongOrRieul(str, defaultJosa, ro, euro, josaOnly);
}