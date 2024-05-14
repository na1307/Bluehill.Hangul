namespace Bluehill.Hangul;

/// <summary>
/// <see cref="char"/> 확장 메서드 모음
/// </summary>
public static class CharExtensions {
    private static readonly Dictionary<char, char> ipfCompTable = new() {
        ['ᄀ'] = 'ㄱ',
        ['ᄁ'] = 'ㄲ',
        ['ᄂ'] = 'ㄴ',
        ['ᄃ'] = 'ㄷ',
        ['ᄄ'] = 'ㄸ',
        ['ᄅ'] = 'ㄹ',
        ['ᄆ'] = 'ㅁ',
        ['ᄇ'] = 'ㅂ',
        ['ᄈ'] = 'ㅃ',
        ['ᄉ'] = 'ㅅ',
        ['ᄊ'] = 'ㅆ',
        ['ᄋ'] = 'ㅇ',
        ['ᄌ'] = 'ㅈ',
        ['ᄍ'] = 'ㅉ',
        ['ᄎ'] = 'ㅊ',
        ['ᄏ'] = 'ㅋ',
        ['ᄐ'] = 'ㅌ',
        ['ᄑ'] = 'ㅍ',
        ['ᄒ'] = 'ㅎ',
        ['ᅡ'] = 'ㅏ',
        ['ᅢ'] = 'ㅐ',
        ['ᅣ'] = 'ㅑ',
        ['ᅤ'] = 'ㅒ',
        ['ᅥ'] = 'ㅓ',
        ['ᅦ'] = 'ㅔ',
        ['ᅧ'] = 'ㅕ',
        ['ᅨ'] = 'ㅖ',
        ['ᅩ'] = 'ㅗ',
        ['ᅪ'] = 'ㅘ',
        ['ᅫ'] = 'ㅙ',
        ['ᅬ'] = 'ㅚ',
        ['ᅭ'] = 'ㅛ',
        ['ᅮ'] = 'ㅜ',
        ['ᅯ'] = 'ㅝ',
        ['ᅰ'] = 'ㅞ',
        ['ᅱ'] = 'ㅟ',
        ['ᅲ'] = 'ㅠ',
        ['ᅳ'] = 'ㅡ',
        ['ᅴ'] = 'ㅢ',
        ['ᅵ'] = 'ㅣ',
        ['ᆨ'] = 'ㄱ',
        ['ᆩ'] = 'ㄲ',
        ['ᆪ'] = 'ㄳ',
        ['ᆫ'] = 'ㄴ',
        ['ᆬ'] = 'ㄵ',
        ['ᆭ'] = 'ㄶ',
        ['ᆮ'] = 'ㄷ',
        ['ᆯ'] = 'ㄹ',
        ['ᆰ'] = 'ㄺ',
        ['ᆱ'] = 'ㄻ',
        ['ᆲ'] = 'ㄼ',
        ['ᆳ'] = 'ㄽ',
        ['ᆴ'] = 'ㄾ',
        ['ᆵ'] = 'ㄿ',
        ['ᆶ'] = 'ㅀ',
        ['ᆷ'] = 'ㅁ',
        ['ᆸ'] = 'ㅂ',
        ['ᆹ'] = 'ㅄ',
        ['ᆺ'] = 'ㅅ',
        ['ᆻ'] = 'ㅆ',
        ['ᆼ'] = 'ㅇ',
        ['ᆽ'] = 'ㅈ',
        ['ᆾ'] = 'ㅊ',
        ['ᆿ'] = 'ㅋ',
        ['ᇀ'] = 'ㅌ',
        ['ᇁ'] = 'ㅍ',
        ['ᇂ'] = 'ㅎ'
    };

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
    /// 문자가 한글 첫가끝 코드 초성인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 첫가끝 코드 초성이라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangulIPFChoseong(this char c) => c is >= FirstIPFChoseong and <= LastIPFChoseong;

    /// <summary>
    /// 문자가 한글 첫가끝 코드 중성인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 첫가끝 코드 중성이라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangulIPFJungseong(this char c) => c is >= FirstIPFJungseong and <= LastIPFJungseong;

    /// <summary>
    /// 문자가 한글 첫가끝 코드 종성인지 여부
    /// </summary>
    /// <param name="c">문자</param>
    /// <returns>문자가 한글 첫가끝 코드 종성이라면 <see langword="true"/>, 아니라면 <see langword="false"/></returns>
    public static bool IsHangulIPFJongseong(this char c) => c is >= FirstIPFJongseong and <= LastIPFJongseong;

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

    /// <summary>
    /// 한글 첫가끝 자모(ᄀ ~ ᄒ, ᅡ ~ ᅵ, ᆨ ~ ᇂ)를 한글 호환용 자모(ㄱ ~ ㅣ)로 변환
    /// </summary>
    /// <param name="ipfJamo">한글 첫가끝 자모</param>
    /// <returns>한글 호환용 자모</returns>
    /// <exception cref="ArgumentException">문자가 한글 첫가끝 자모가 아님</exception>
    public static char ToCompatibilityJamo(this char ipfJamo) {
        if (!ipfJamo.IsHangulIPFChoseong() && !ipfJamo.IsHangulIPFJungseong() && !ipfJamo.IsHangulIPFJongseong()) {
            throw new ArgumentException("문자가 한글 첫가끝 자모가 아님", nameof(ipfJamo));
        }

        return ipfCompTable[ipfJamo];
    }
}
