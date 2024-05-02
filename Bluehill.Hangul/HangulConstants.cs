namespace Bluehill.Hangul;

/// <summary>
/// 한글 관련 상수 모음
/// </summary>
public static class HangulConstants {
    /// <summary>
    /// 은(는)
    /// </summary>
    public const string Eun_Neun = "은(는)";

    /// <summary>
    /// 은
    /// </summary>
    public const string Eun = "은";

    /// <summary>
    /// 는
    /// </summary>
    public const string Neun = "는";

    /// <summary>
    /// 이(가)
    /// </summary>
    public const string I_Ga = "이(가)";

    /// <summary>
    /// 이
    /// </summary>
    public const string I = "이";

    /// <summary>
    /// 가
    /// </summary>
    public const string Ga = "가";

    /// <summary>
    /// 을(를)
    /// </summary>
    public const string Eul_Reul = "을(를)";

    /// <summary>
    /// 을
    /// </summary>
    public const string Eul = "을";

    /// <summary>
    /// 를
    /// </summary>
    public const string Reul = "를";

    /// <summary>
    /// 과(와)
    /// </summary>
    public const string Gwa_Wa = "과(와)";

    /// <summary>
    /// 과
    /// </summary>
    public const string Gwa = "과";

    /// <summary>
    /// 와
    /// </summary>
    public const string Wa = "와";

    /// <summary>
    /// 아(야)
    /// </summary>
    public const string A_Ya = "아(야)";

    /// <summary>
    /// 아
    /// </summary>
    public const string A = "아";

    /// <summary>
    /// 야
    /// </summary>
    public const string Ya = "야";

    /// <summary>
    /// (으)로
    /// </summary>
    public const string Eu_Ro = "(으)로";

    /// <summary>
    /// 로
    /// </summary>
    public const string Ro = "로";

    /// <summary>
    /// 으로
    /// </summary>
    public const string Euro = "으로";

    /// <summary>
    /// 유니코드에서 한글 완성형의 첫번째 문자(가)를 가리킴
    /// </summary>
    public const char FirstChar = '\uAC00'; // U+AC00 == 44032 == 가

    /// <summary>
    /// 유니코드에서 한글 완성형의 마지막 문자(힣)를 가리킴
    /// </summary>
    public const char LastChar = '\uD7A3'; // U+D7A3 == 55023 == 힣

    /// <summary>
    /// 유니코드에서 한글 자모의 첫번째 문자(ㄱ)를 가리킴
    /// </summary>
    public const char FirstJamo = '\u3131'; // U+3131 == 12593 == ㄱ

    /// <summary>
    /// 유니코드에서 한글 자모의 마지막 문자(ㅣ)를 가리킴
    /// </summary>
    public const char LastJamo = '\u3163'; // U+3163 == 12643 == ㅣ
}
