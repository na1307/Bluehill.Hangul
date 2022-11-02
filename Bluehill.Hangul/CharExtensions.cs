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
    public static bool IsHanChar(this char c) => c is >= FirstChar and <= LastChar;

    /// <summary>
    /// 문자가 한글 자모인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 자모라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHanJamo(this char c) => c is >= FirstJamo and <= LastJamo;

    /// <summary>
    /// 문자가 한글인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 문자 또는 자모라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangul(this char c) => c.IsHanChar() || c.IsHanJamo();

    /// <summary>
    /// 이 한글 문자의 <see cref="Hangul.Choseong"/> 값을 반환함
    /// </summary>
    /// <param name="hanChar">한글 문자</param>
    /// <returns><paramref name="hanChar"/>의 초성에 대한 <see cref="Hangul.Choseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hanChar"/>가 한글 문자가 아님</exception>
    public static Choseong Choseong(this char hanChar) => hanChar.IsHanChar() ? (Choseong)((hanChar - FirstChar) / 28 / 21) : throw new ArgumentException("문자가 한글 문자가 아닙니다.");


    /// <summary>
    /// 이 한글 문자의 <see cref="Hangul.Jungseong"/> 값을 반환함
    /// </summary>
    /// <param name="hanChar">한글 문자</param>
    /// <returns><paramref name="hanChar"/>의 초성에 대한 <see cref="Hangul.Jungseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hanChar"/>가 한글 문자가 아님</exception>
    public static Jungseong Jungseong(this char hanChar) => hanChar.IsHanChar() ? (Jungseong)((hanChar - FirstChar) / 28 % 21) : throw new ArgumentException("문자가 한글 문자가 아닙니다.");


    /// <summary>
    /// 이 한글 문자의 <see cref="Hangul.Jongseong"/> 값을 반환함
    /// </summary>
    /// <param name="hanChar">한글 문자</param>
    /// <returns><paramref name="hanChar"/>의 초성에 대한 <see cref="Hangul.Jongseong"/> 값</returns>
    /// <exception cref="ArgumentException"><paramref name="hanChar"/>가 한글 문자가 아님</exception>
    public static Jongseong Jongseong(this char hanChar) => hanChar.IsHanChar() ? (Jongseong)((hanChar - FirstChar) % 28) : throw new ArgumentException("문자가 한글 문자가 아닙니다.");
}