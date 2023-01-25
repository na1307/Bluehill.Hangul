namespace Bluehill.Hangul;

/// <summary>
/// <see cref="char"/> 확장 메서드 모음
/// </summary>
public static class CharExtensions {
    /// <summary>
    /// 문자가 한글 음절이나 자모인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글이라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangul(this char c) => IsHangulSyllable(c) || IsHangulJamo(c);

    /// <summary>
    /// 문자가 한글 음절인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 음절이라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangulSyllable(this char c) => c is >= FirstSyllable and <= LastSyllable;

    /// <summary>
    /// 문자가 한글 낱자(자모)인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 낱자라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangulJamo(this char c) => c is >= FirstJamo and <= LastJamo;

    /// <summary>
    /// 문자가 한글 자음인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 자음이라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangulConsonant(this char c) => c is >= FirstConsonant and <= LastConsonant;

    /// <summary>
    /// 문자가 한글 모음인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 모음이라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangulVowel(this char c) => c is >= FirstVowel and <= LastVowel;

    /// <summary>
    /// 이 한글 음절의 초성에 해당하는 <see cref="Hangul.Choseong"/> 값을 반환함
    /// </summary>
    /// <param name="hangulSyllable">한글 음절</param>
    /// <returns><paramref name="hangulSyllable"/>의 초성에 해당하는 <see cref="Hangul.Choseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hangulSyllable"/>가 한글 음절이 아님</exception>
    public static Choseong Choseong(this char hangulSyllable) => ((HangulSyllable)hangulSyllable).Choseong;

    /// <summary>
    /// 이 한글 음절의 중성에 해당하는 <see cref="Hangul.Jungseong"/> 값을 반환함
    /// </summary>
    /// <param name="hangulSyllable">한글 음절</param>
    /// <returns><paramref name="hangulSyllable"/>의 초성에 해당하는 <see cref="Hangul.Jungseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hangulSyllable"/>가 한글 음절이 아님</exception>
    public static Jungseong Jungseong(this char hangulSyllable) => ((HangulSyllable)hangulSyllable).Jungseong;

    /// <summary>
    /// 이 한글 음절의 종성에 해당하는 <see cref="Hangul.Jongseong"/> 값을 반환함
    /// </summary>
    /// <param name="hangulSyllable">한글 음절</param>
    /// <returns><paramref name="hangulSyllable"/>의 초성에 해당하는 <see cref="Hangul.Jongseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hangulSyllable"/>가 한글 음절이 아님</exception>
    public static Jongseong Jongseong(this char hangulSyllable) => ((HangulSyllable)hangulSyllable).Jongseong;
}