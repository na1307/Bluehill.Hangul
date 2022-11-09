namespace Bluehill.Hangul;

/// <summary>
/// <see cref="char"/> 확장 메서드 모음
/// </summary>
public static class CharExtensions {
    /// <summary>
    /// 문자가 한글 문자인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 문자라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangul(this char c) => c is >= FirstChar and <= LastChar;

    /// <summary>
    /// 문자가 한글 낱자(자모)인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 낱자라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsJamo(this char c) => c is >= FirstJamo and <= LastJamo;

    /// <summary>
    /// 이 한글 문자의 <see cref="Hangul.Choseong"/> 값을 반환함
    /// </summary>
    /// <param name="hangulChar">한글 문자</param>
    /// <returns><paramref name="hangulChar"/>의 초성에 대한 <see cref="Hangul.Choseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hangulChar"/>가 한글 문자가 아님</exception>
    public static Choseong Choseong(this char hangulChar) => ((HangulChar)hangulChar).Choseong;

    /// <summary>
    /// 이 한글 문자의 <see cref="Hangul.Jungseong"/> 값을 반환함
    /// </summary>
    /// <param name="hangulChar">한글 문자</param>
    /// <returns><paramref name="hangulChar"/>의 초성에 대한 <see cref="Hangul.Jungseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hangulChar"/>가 한글 문자가 아님</exception>
    public static Jungseong Jungseong(this char hangulChar) => ((HangulChar)hangulChar).Jungseong;

    /// <summary>
    /// 이 한글 문자의 <see cref="Hangul.Jongseong"/> 값을 반환함
    /// </summary>
    /// <param name="hangulChar">한글 문자</param>
    /// <returns><paramref name="hangulChar"/>의 초성에 대한 <see cref="Hangul.Jongseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hangulChar"/>가 한글 문자가 아님</exception>
    public static Jongseong Jongseong(this char hangulChar) => ((HangulChar)hangulChar).Jongseong;
}