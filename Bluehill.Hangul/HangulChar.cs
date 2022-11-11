namespace Bluehill.Hangul;

/// <summary>
/// 한글 문자(가 ~ 힣)를 나타냄
/// </summary>
public readonly struct HangulChar : IEquatable<HangulChar>, IComparable<HangulChar>
#if NET7_0_OR_GREATER
    , System.Numerics.IComparisonOperators<HangulChar, HangulChar, bool>, System.Numerics.IMinMaxValue<HangulChar>
#endif
    {
    /// <summary>
    /// 실제 <see cref="char"/>
    /// </summary>
    public required char WrappedChar { get; init; }

    /// <summary>
    /// <see cref="HangulChar"/>의 최소값을 나타냄
    /// </summary>
    public static HangulChar MinValue { get; } = new(FirstChar);

    /// <summary>
    /// <see cref="HangulChar"/>의 최대값을 나타냄
    /// </summary>
    public static HangulChar MaxValue { get; } = new(LastChar);

    /// <summary>
    /// 이 한글 문자의 초성에 대한 <see cref="Hangul.Choseong"/> 값
    /// </summary>
    public Choseong Choseong => IsValid ? (Choseong)((WrappedChar - FirstChar) / 28 / 21) : throw new InvalidOperationException(nameof(HangulChar) + " 인스턴스를 만드려면 항상 생성자를 사용해야 합니다.");

    /// <summary>
    /// 이 한글 문자의 중성에 대한 <see cref="Hangul.Jungseong"/> 값
    /// </summary>
    public Jungseong Jungseong => IsValid ? (Jungseong)((WrappedChar - FirstChar) / 28 % 21) : throw new InvalidOperationException(nameof(HangulChar) + " 인스턴스를 만드려면 항상 생성자를 사용해야 합니다.");

    /// <summary>
    /// 이 한글 문자의 종성에 대한 <see cref="Hangul.Jongseong"/> 값
    /// </summary>
    public Jongseong Jongseong => IsValid ? (Jongseong)((WrappedChar - FirstChar) % 28) : throw new InvalidOperationException(nameof(HangulChar) + " 인스턴스를 만드려면 항상 생성자를 사용해야 합니다.");

    /// <summary>
    /// 이 <see cref="HangulChar"/>가 올바른지 여부
    /// </summary>
    public bool IsValid => WrappedChar.IsHangul();

    /// <summary>
    /// 지정한 한글 문자를 사용하여 새 <see cref="HangulChar"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="c">한글 문자</param>
    /// <exception cref="ArgumentException"><paramref name="c"/>가 한글 문자가 아님</exception>
    [SetsRequiredMembers]
    public HangulChar(char c) {
        if (!c.IsHangul()) throw new ArgumentException("문자가 한글 문자가 아닙니다.", nameof(c));

        WrappedChar = c;
    }

    /// <summary>
    /// 지정한 초성, 중성, 종성 값을 사용하여 새 <see cref="HangulChar"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="choseong">초성 값</param>
    /// <param name="jungseong">중성 값</param>
    /// <param name="jongseong">종성 값</param>
    [SetsRequiredMembers]
    public HangulChar(Choseong choseong, Jungseong jungseong, Jongseong jongseong) => WrappedChar = getChar((byte)choseong, (byte)jungseong, (byte)jongseong);

    /// <summary>
    /// 지정한 초성, 중성, 종성 값을 사용하여 새 <see cref="HangulChar"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="choseong">초성 값</param>
    /// <param name="jungseong">중성 값</param>
    /// <param name="jongseong">종성 값</param>
    /// <exception cref="ArgumentOutOfRangeException">초성 값이 18보다 높을 경우 또는 중성 값이 20보다 높을 경우 또는 종성 값이 27보다 높을 경우</exception>
    [SetsRequiredMembers]
    public HangulChar(byte choseong, byte jungseong, byte jongseong) {
        if (choseong > 18) throw new ArgumentOutOfRangeException(nameof(choseong), choseong, "초성 값은 18 이하여야 합니다.");
        if (jungseong > 20) throw new ArgumentOutOfRangeException(nameof(jungseong), jungseong, "중성 값은 20 이하여야 합니다.");
        if (jongseong > 27) throw new ArgumentOutOfRangeException(nameof(jongseong), jongseong, "종성 값은 27 이하여야 합니다.");

        WrappedChar = getChar(choseong, jungseong, jongseong);
    }

    /// <summary>
    /// 지정한 초성, 중성, 종성 낱자를 사용하여 새 <see cref="HangulChar"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="choseong">초성 낱자</param>
    /// <param name="jungseong">중성 낱자</param>
    /// <param name="jongseong">종성 낱자</param>
    /// <exception cref="ArgumentException"><paramref name="choseong"/>이 초성 낱자가 아님 또는 <paramref name="jungseong"/>이 중성 낱자가 아님 또는 <paramref name="jongseong"/>이 종성 낱자가 아님</exception>
    [SetsRequiredMembers]
    public HangulChar(char choseong, char jungseong, char jongseong) {
        if (!JamoLookup[0].Contains(choseong)) throw new ArgumentException("초성 낱자가 아닙니다.", nameof(choseong));
        if (!JamoLookup[1].Contains(jungseong)) throw new ArgumentException("중성 낱자가 아닙니다.", nameof(jungseong));
        if (!JamoLookup[2].Contains(jongseong)) throw new ArgumentException("종성 낱자가 아닙니다.", nameof(jongseong));

        WrappedChar = getChar(getByte(ChoseongIndex, choseong), getByte(JungseongIndex, jungseong), getByte(JongseongIndex, jongseong));

        static byte getByte(int index, char value) => (byte)Array.IndexOf(JamoLookup[index], value);
    }

    /// <summary>
    /// 이 한글 문자를 <see cref="HangulChar"/>로 변환
    /// </summary>
    /// <param name="hangulChar">한글 문자</param>
    /// <exception cref="ArgumentException"><paramref name="hangulChar"/>가 한글 문자가 아님</exception>
    public static explicit operator HangulChar(char hangulChar) => new(hangulChar);

    /// <summary>
    /// 이 <see cref="HangulChar"/>를 <see cref="char"/>로 변환
    /// </summary>
    /// <param name="hangulChar">한글 문자</param>
    public static implicit operator char(HangulChar hangulChar) => hangulChar.WrappedChar;

    /// <summary>
    /// 두 <see cref="HangulChar"/>가 같은지 확인
    /// </summary>
    /// <param name="left">한글 문자 1</param>
    /// <param name="right">한글 문자 2</param>
    /// <returns>두 <see cref="HangulChar"/>가 같다면 <see langword="true"/>, 다르다면 <see langword="falue"/></returns>
    public static bool operator ==(HangulChar left, HangulChar right) => left.Equals(right);

    /// <summary>
    /// 두 <see cref="HangulChar"/>가 다른지 확인
    /// </summary>
    /// <param name="left">한글 문자 1</param>
    /// <param name="right">한글 문자 2</param>
    /// <returns>두 <see cref="HangulChar"/>가 다르다면 <see langword="true"/>, 같다면 <see langword="falue"/></returns>
    public static bool operator !=(HangulChar left, HangulChar right) => !(left == right);

    /// <summary>
    /// 좌변이 우변보다 작은지 확인
    /// </summary>
    /// <param name="left">한글 문자 1</param>
    /// <param name="right">한글 문자 2</param>
    /// <returns>좌변이 우변보다 작다면 <see langword="true"/>, 크거나 같다면 <see langword="falue"/></returns>
    public static bool operator <(HangulChar left, HangulChar right) => left.CompareTo(right) < 0;

    /// <summary>
    /// 좌변이 우변보다 작거나 같은지 확인
    /// </summary>
    /// <param name="left">한글 문자 1</param>
    /// <param name="right">한글 문자 2</param>
    /// <returns>좌변이 우변보다 작거나 같다면 <see langword="true"/>, 크다면 <see langword="falue"/></returns>
    public static bool operator <=(HangulChar left, HangulChar right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// 좌변이 우변보다 큰지 확인
    /// </summary>
    /// <param name="left">한글 문자 1</param>
    /// <param name="right">한글 문자 2</param>
    /// <returns>좌변이 우변보다 크다면 <see langword="true"/>, 작거나 같다면 <see langword="falue"/></returns>
    public static bool operator >(HangulChar left, HangulChar right) => left.CompareTo(right) > 0;

    /// <summary>
    /// 좌변이 우변보다 크거나 같은지 확인
    /// </summary>
    /// <param name="left">한글 문자 1</param>
    /// <param name="right">한글 문자 2</param>
    /// <returns>좌변이 우변보다 크거나 같다면 <see langword="true"/>, 작다면 <see langword="falue"/></returns>
    public static bool operator >=(HangulChar left, HangulChar right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// 이 한글 문자를 문자열 표현으로 변환
    /// </summary>
    /// <returns>이 한글 문자의 문자열 표현</returns>
    public override string ToString() => WrappedChar.ToString();

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is HangulChar @char && Equals(@char);

    /// <inheritdoc/>
    public bool Equals(HangulChar other) => WrappedChar.Equals(other.WrappedChar);

    /// <inheritdoc/>
    public override int GetHashCode() => WrappedChar.GetHashCode();

    /// <inheritdoc/>
    public int CompareTo(HangulChar other) => WrappedChar.CompareTo(other.WrappedChar);

    /// <summary>
    /// 이 <see cref="HangulChar"/>를 초성, 중성, 종성 열거형으로 분해
    /// </summary>
    /// <param name="choseong">초성</param>
    /// <param name="jungseong">중성</param>
    /// <param name="jongseong">종성</param>
    public void Deconstruct(out Choseong choseong, out Jungseong jungseong, out Jongseong jongseong) {
        choseong = Choseong;
        jungseong = Jungseong;
        jongseong = Jongseong;
    }

    private static char getChar(byte choseong, byte jungseong, byte jongseong) => (char)(FirstChar + (((choseong * 21) + jungseong) * 28) + jongseong);
}