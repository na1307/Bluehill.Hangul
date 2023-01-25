namespace Bluehill.Hangul;

/// <summary>
/// 한글 조사 처리 확장 모음
/// </summary>
public static class Josa {
    /// <summary>
    /// 입력 문자열의 받침 여부에 따라 문자열을 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="jongseong">마지막 글자의 받침이 있다면 붙일 문자열</param>
    /// <param name="noJongseong">마지막 글자의 받침이 없다면 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>마지막 글자의 받침 여부에 따라 <paramref name="defaultJosa"/> 또는 <paramref name="jongseong"/> 또는 <paramref name="noJongseong"/>을 붙인 문자열</returns>
    public static string Jongseong(this string str, string defaultJosa, string jongseong, string noJongseong, bool josaOnly) {
        var text = !josaOnly ? str : null;

        // 한글 음절이 아니라면
        if (!str[str.Length - 1].IsHangul()) return text + defaultJosa;

        return text + (str[str.Length - 1].Jongseong() == Hangul.Jongseong.None ? noJongseong : jongseong);
    }

    /// <summary>
    /// 입력 문자열의 ㄹ받침 여부에 따라 문자열을 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="rieul">마지막 글자의 받침이 없거나 ㄹ받침일 경우 붙일 문자열</param>
    /// <param name="noRieul">마지막 글자가 ㄹ 이외의 받침일 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>마지막 글자의 ㄹ받침 여부에 따라 <paramref name="defaultJosa"/> 또는 <paramref name="rieul"/> 또는 <paramref name="noRieul"/>을 붙인 문자열</returns>
    public static string NoJongseongOrRieul(this string str, string defaultJosa, string rieul, string noRieul, bool josaOnly) {
        var text = !josaOnly ? str : null;

        // 한글 음절이 아니라면
        if (!str[str.Length - 1].IsHangul()) return text + defaultJosa;

        return text + (str[str.Length - 1].Jongseong() is Hangul.Jongseong.None or Hangul.Jongseong.Rieul ? rieul : noRieul);
    }

    /// <summary>
    /// 입력 문자열에 '은' 또는 '는'을 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <returns>'은' 또는 '는'을 붙인 문자열</returns>
    public static string EunNeun(this string str) => EunNeun(str, Eun_Neun);

    /// <summary>
    /// 입력 문자열에 '은' 또는 '는' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <returns>'은' 또는 '는'을 붙인 문자열</returns>
    public static string EunNeun(this string str, string defaultJosa) => EunNeun(str, defaultJosa, false);

    /// <summary>
    /// 입력 문자열에 '은' 또는 '는' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>'은' 또는 '는'을 붙인 문자열</returns>
    public static string EunNeun(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, Eun, Neun, josaOnly);

    /// <summary>
    /// 입력 문자열에 '이' 또는 '가'를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <returns>'이' 또는 '가'를 붙인 문자열</returns>
    public static string IGa(this string str) => IGa(str, I_Ga);

    /// <summary>
    /// 입력 문자열에 '이' 또는 '가' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <returns>'이' 또는 '가'를 붙인 문자열</returns>
    public static string IGa(this string str, string defaultJosa) => IGa(str, defaultJosa, false);

    /// <summary>
    /// 입력 문자열에 '이' 또는 '가' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열 </param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>'이' 또는 '가'를 붙인 문자열</returns>
    public static string IGa(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, HangulConstants.I, Ga, josaOnly);

    /// <summary>
    /// 입력 문자열에 '이'를 붙이거나 붙이지 않음
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <returns>'이'를 붙이거나 붙이지 않은 문자열</returns>
    public static string I(this string str) => I(str, string.Empty);

    /// <summary>
    /// 입력 문자열에 '이' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <returns>'이'를 붙이거나 붙이지 않은 문자열</returns>
    public static string I(this string str, string defaultJosa) => I(str, defaultJosa, false);

    /// <summary>
    /// 입력 문자열에 '이' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>'이'를 붙이거나 붙이지 않은 문자열</returns>
    public static string I(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, HangulConstants.I, string.Empty, josaOnly);

    /// <summary>
    /// 입력 문자열에 '을' 또는 '를'를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <returns>'을' 또는 '를'을 붙인 문자열</returns>
    public static string EulReul(this string str) => EulReul(str, Eul_Reul);

    /// <summary>
    /// 입력 문자열에 '을' 또는 '를' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <returns>'을' 또는 '를'을 붙인 문자열</returns>
    public static string EulReul(this string str, string defaultJosa) => EulReul(str, defaultJosa, false);

    /// <summary>
    /// 입력 문자열에 '을' 또는 '를' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>'을' 또는 '를'을 붙인 문자열</returns>
    public static string EulReul(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, Eul, Reul, josaOnly);

    /// <summary>
    /// 입력 문자열에 '과' 또는 '와'를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <returns>'과' 또는 '와'를 붙인 문자열</returns>
    public static string GwaWa(this string str) => GwaWa(str, Gwa_Wa);

    /// <summary>
    /// 입력 문자열에 '과' 또는 '와' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <returns>'과' 또는 '와'를 붙인 문자열</returns>
    public static string GwaWa(this string str, string defaultJosa) => GwaWa(str, defaultJosa, false);

    /// <summary>
    /// 입력 문자열에 '과' 또는 '와' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>'과' 또는 '와'를 붙인 문자열</returns>
    public static string GwaWa(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, Gwa, Wa, josaOnly);

    /// <summary>
    /// 입력 문자열에 '아' 또는 '야'를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <returns>'아' 또는 '야'를 붙인 문자열</returns>
    public static string AYa(this string str) => AYa(str, A_Ya);

    /// <summary>
    /// 입력 문자열에 '아' 또는 '야' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <returns>'아' 또는 '야'를 붙인 문자열</returns>
    public static string AYa(this string str, string defaultJosa) => AYa(str, defaultJosa, false);

    /// <summary>
    /// 입력 문자열에 '아' 또는 '야' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>'아' 또는 '야'를 붙인 문자열</returns>
    public static string AYa(this string str, string defaultJosa, bool josaOnly) => Jongseong(str, defaultJosa, A, Ya, josaOnly);

    /// <summary>
    /// 입력 문자열에 '로' 또는 '으로'를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <returns>'로' 또는 '으로'를 붙인 문자열</returns>
    public static string EuRo(this string str) => EuRo(str, Eu_Ro);

    /// <summary>
    /// 입력 문자열에 '로' 또는 '으로' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <returns>'로' 또는 '으로'를 붙인 문자열</returns>
    public static string EuRo(this string str, string defaultJosa) => EuRo(str, defaultJosa, false);

    /// <summary>
    /// 입력 문자열에 '로' 또는 '으로' 또는 <paramref name="defaultJosa"/>를 붙임
    /// </summary>
    /// <param name="str">입력 문자열</param>
    /// <param name="defaultJosa">마지막 글자가 한글이 아닐 경우 붙일 문자열</param>
    /// <param name="josaOnly">입력 문자열 없이 조사만 반환할지 여부</param>
    /// <returns>'로' 또는 '으로'를 붙인 문자열</returns>
    public static string EuRo(this string str, string defaultJosa, bool josaOnly) => NoJongseongOrRieul(str, defaultJosa, Ro, Euro, josaOnly);
}