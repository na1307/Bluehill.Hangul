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
    /// 유니코드에서 한글 완성형 음절의 첫번째 문자(가)를 가리킴
    /// </summary>
    public const char FirstSyllable = '\uAC00'; // U+AC00 == 44032 == 가

    /// <summary>
    /// 유니코드에서 한글 완성형 음절의 마지막 문자(힣)를 가리킴
    /// </summary>
    public const char LastSyllable = '\uD7A3'; // U+D7A3 == 55023 == 힣

    /// <summary>
    /// 유니코드에서 한글 자모의 첫번째 문자(ㄱ)를 가리킴
    /// </summary>
    public const char FirstJamo = '\u3131'; // U+3131 == 12593 == ㄱ

    /// <summary>
    /// 유니코드에서 한글 자모의 마지막 문자(ㅣ)를 가리킴
    /// </summary>
    public const char LastJamo = '\u3163'; // U+3163 == 12643 == ㅣ

    /// <summary>
    /// 유니코드에서 한글 자음의 첫번째 문자(ㄱ)를 가리킴
    /// </summary>
    public const char FirstConsonant = '\u3131'; // U+3131 == 12593 == ㄱ

    /// <summary>
    /// 유니코드에서 한글 자음의 마지막 문자(ㅎ)를 가리킴
    /// </summary>
    public const char LastConsonant = '\u314E'; // U+314E == 12622 == ㅎ

    /// <summary>
    /// 유니코드에서 한글 모음의 첫번째 문자(ㅏ)를 가리킴
    /// </summary>
    public const char FirstVowel = '\u314F'; // U+314F == 12623 == ㅏ

    /// <summary>
    /// 유니코드에서 한글 모음의 마지막 문자(ㅣ)를 가리킴
    /// </summary>
    public const char LastVowel = '\u3163'; // U+3163 == 12643 == ㅣ

    /// <summary>
    /// 유니코드에서 한글 채움 문자(ㅤ)를 가리킴
    /// </summary>
    public const char HangulFiller = '\u3164'; // U+3164 == 12644 == ㅤ

    /// <summary>
    /// 유니코드에서 한글 첫가끝 코드 초성의 첫번째 문자(ᄀ)를 가리킴
    /// </summary>
    public const char FirstIPFChoseong = '\u1100'; // U+1100 == 4352 == ᄀ

    /// <summary>
    /// 유니코드에서 한글 첫가끝 코드 초성의 마지막 문자(ᄒ)를 가리킴
    /// </summary>
    public const char LastIPFChoseong = '\u1112'; // U+1112 == 4370 == ᄒ

    /// <summary>
    /// 유니코드에서 한글 첫가끝 코드 중성의 첫번째 문자(ᅡ)를 가리킴
    /// </summary>
    public const char FirstIPFJungseong = '\u1161'; // U+1161 == 4449 == ᅡ

    /// <summary>
    /// 유니코드에서 한글 첫가끝 코드 중성의 마지막 문자(ᅵ)를 가리킴
    /// </summary>
    public const char LastIPFJungseong = '\u1175'; // U+1175 == 4469 == ᅵ

    /// <summary>
    /// 유니코드에서 한글 첫가끝 코드 종성의 첫번째 문자(ᆨ)를 가리킴
    /// </summary>
    public const char FirstIPFJongseong = '\u11A8'; // U+11A8 == 4520 == ᆨ

    /// <summary>
    /// 유니코드에서 한글 첫가끝 코드 종성의 마지막 문자(ᇂ)를 가리킴
    /// </summary>
    public const char LastIPFJongseong = '\u11C2'; // U+11C2 == 4546 == ᇂ
}