namespace Bluehill.Hangul;

/// <summary>
/// 한글 음절(가 ~ 힣)를 나타냄
/// </summary>
public readonly struct HangulSyllable : IEquatable<HangulSyllable>, IComparable<HangulSyllable>
#if NET7_0_OR_GREATER
    , System.Numerics.IComparisonOperators<HangulSyllable, HangulSyllable, bool>, System.Numerics.IMinMaxValue<HangulSyllable>
#endif
    {
    private const string invalidMessage = nameof(HangulSyllable) + " 인스턴스를 만드려면 항상 생성자를 사용해야 합니다.";
    private readonly char _Value;

    /// <summary>
    /// 실제 <see cref="char"/>
    /// </summary>
    public required char Value {
        get {
            if (!IsValid) throw new InvalidOperationException(invalidMessage);

            return _Value;
        }
        init {
            if (!value.IsHangulSyllable()) throw new ArgumentException("문자가 한글 음절 문자가 아닙니다.", nameof(value));

            _Value = value;
        }
    }

    /// <summary>
    /// <see cref="HangulSyllable"/>의 최소값을 나타냄
    /// </summary>
    public static HangulSyllable MinValue { get; } = new(FirstSyllable);

    /// <summary>
    /// <see cref="HangulSyllable"/>의 최대값을 나타냄
    /// </summary>
    public static HangulSyllable MaxValue { get; } = new(LastSyllable);

    /// <summary>
    /// 이 한글 음절의 초성에 대한 <see cref="Hangul.Choseong"/> 값
    /// </summary>
    public Choseong Choseong => IsValid ? (Choseong)((_Value - FirstSyllable) / 28 / 21) : throw new InvalidOperationException(invalidMessage);

    /// <summary>
    /// 이 한글 음절의 중성에 대한 <see cref="Hangul.Jungseong"/> 값
    /// </summary>
    public Jungseong Jungseong => IsValid ? (Jungseong)((_Value - FirstSyllable) / 28 % 21) : throw new InvalidOperationException(invalidMessage);

    /// <summary>
    /// 이 한글 음절의 종성에 대한 <see cref="Hangul.Jongseong"/> 값
    /// </summary>
    public Jongseong Jongseong => IsValid ? (Jongseong)((_Value - FirstSyllable) % 28) : throw new InvalidOperationException(invalidMessage);

    /// <summary>
    /// 이 <see cref="HangulSyllable"/>가 올바른지 여부
    /// </summary>
    public bool IsValid => _Value.IsHangulSyllable();

    /// <summary>
    /// 지정한 한글 음절 문자를 사용하여 새 <see cref="HangulSyllable"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="c">한글 음절 문자</param>
    /// <exception cref="ArgumentException"><paramref name="c"/>가 한글 음절 문자가 아님</exception>
    [SetsRequiredMembers]
    public HangulSyllable(char c) {
        if (!c.IsHangulSyllable()) throw new ArgumentException("문자가 한글 음절 문자가 아닙니다.", nameof(c));

        _Value = c;
    }

    /// <summary>
    /// 지정한 초성, 중성, 종성 값을 사용하여 새 <see cref="HangulSyllable"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="choseong">초성 값</param>
    /// <param name="jungseong">중성 값</param>
    /// <param name="jongseong">종성 값</param>
    [SetsRequiredMembers]
    public HangulSyllable(Choseong choseong, Jungseong jungseong, Jongseong jongseong) => _Value = getChar((byte)choseong, (byte)jungseong, (byte)jongseong);

    /// <summary>
    /// 지정한 초성, 중성, 종성 값을 사용하여 새 <see cref="HangulSyllable"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="choseong">초성 값</param>
    /// <param name="jungseong">중성 값</param>
    /// <param name="jongseong">종성 값</param>
    /// <exception cref="ArgumentOutOfRangeException">초성 값이 18보다 높을 경우 또는 중성 값이 20보다 높을 경우 또는 종성 값이 27보다 높을 경우</exception>
    [SetsRequiredMembers]
    public HangulSyllable(byte choseong, byte jungseong, byte jongseong) {
        if (choseong > 18) throw new ArgumentOutOfRangeException(nameof(choseong), choseong, "초성 값은 18 이하여야 합니다.");
        if (jungseong > 20) throw new ArgumentOutOfRangeException(nameof(jungseong), jungseong, "중성 값은 20 이하여야 합니다.");
        if (jongseong > 27) throw new ArgumentOutOfRangeException(nameof(jongseong), jongseong, "종성 값은 27 이하여야 합니다.");

        _Value = getChar(choseong, jungseong, jongseong);
    }

    /// <summary>
    /// 지정한 초성, 중성, 종성 낱자를 사용하여 새 <see cref="HangulSyllable"/> 인스턴스를 만듦
    /// </summary>
    /// <param name="choseong">초성 낱자</param>
    /// <param name="jungseong">중성 낱자</param>
    /// <param name="jongseong">종성 낱자</param>
    /// <exception cref="ArgumentException"><paramref name="choseong"/>이 초성 낱자가 아님 또는 <paramref name="jungseong"/>이 중성 낱자가 아님 또는 <paramref name="jongseong"/>이 종성 낱자가 아님</exception>
    [SetsRequiredMembers]
    public HangulSyllable(char choseong, char jungseong, char jongseong) {
        if (!Choseongs.Contains(choseong)) throw new ArgumentException("초성 낱자가 아닙니다.", nameof(choseong));
        if (!Jungseongs.Contains(jungseong)) throw new ArgumentException("중성 낱자가 아닙니다.", nameof(jungseong));
        if (!Jongseongs.Contains(jongseong)) throw new ArgumentException("종성 낱자가 아닙니다.", nameof(jongseong));

        _Value = getChar(getByte(Choseongs, choseong), getByte(Jungseongs, jungseong), getByte(Jongseongs, jongseong));

        static byte getByte(char[] array, char value) => (byte)Array.IndexOf(array, value);
    }

    /// <summary>
    /// 이 한글 음절 문자를 <see cref="HangulSyllable"/>로 변환
    /// </summary>
    /// <param name="hangulChar">한글 음절 문자</param>
    /// <exception cref="ArgumentException"><paramref name="hangulChar"/>가 한글 음절 문자이 아님</exception>
    public static explicit operator HangulSyllable(char hangulChar) => new(hangulChar);

    /// <summary>
    /// 이 <see cref="HangulSyllable"/>를 <see cref="char"/>로 변환
    /// </summary>
    /// <param name="hangulChar">한글 음절</param>
    public static implicit operator char(HangulSyllable hangulChar) => hangulChar.Value;

    /// <summary>
    /// 두 <see cref="HangulSyllable"/>가 같은지 확인
    /// </summary>
    /// <param name="left">한글 음절 1</param>
    /// <param name="right">한글 음절 2</param>
    /// <returns>두 <see cref="HangulSyllable"/>가 같다면 <see langword="true"/>, 다르다면 <see langword="falue"/></returns>
    public static bool operator ==(HangulSyllable left, HangulSyllable right) => left.Equals(right);

    /// <summary>
    /// 두 <see cref="HangulSyllable"/>가 다른지 확인
    /// </summary>
    /// <param name="left">한글 음절 1</param>
    /// <param name="right">한글 음절 2</param>
    /// <returns>두 <see cref="HangulSyllable"/>가 다르다면 <see langword="true"/>, 같다면 <see langword="falue"/></returns>
    public static bool operator !=(HangulSyllable left, HangulSyllable right) => !(left == right);

    /// <summary>
    /// 좌변이 우변보다 작은지 확인
    /// </summary>
    /// <param name="left">한글 음절 1</param>
    /// <param name="right">한글 음절 2</param>
    /// <returns>좌변이 우변보다 작다면 <see langword="true"/>, 크거나 같다면 <see langword="falue"/></returns>
    public static bool operator <(HangulSyllable left, HangulSyllable right) => left.CompareTo(right) < 0;

    /// <summary>
    /// 좌변이 우변보다 작거나 같은지 확인
    /// </summary>
    /// <param name="left">한글 음절 1</param>
    /// <param name="right">한글 음절 2</param>
    /// <returns>좌변이 우변보다 작거나 같다면 <see langword="true"/>, 크다면 <see langword="falue"/></returns>
    public static bool operator <=(HangulSyllable left, HangulSyllable right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// 좌변이 우변보다 큰지 확인
    /// </summary>
    /// <param name="left">한글 음절 1</param>
    /// <param name="right">한글 음절 2</param>
    /// <returns>좌변이 우변보다 크다면 <see langword="true"/>, 작거나 같다면 <see langword="falue"/></returns>
    public static bool operator >(HangulSyllable left, HangulSyllable right) => left.CompareTo(right) > 0;

    /// <summary>
    /// 좌변이 우변보다 크거나 같은지 확인
    /// </summary>
    /// <param name="left">한글 음절 1</param>
    /// <param name="right">한글 음절 2</param>
    /// <returns>좌변이 우변보다 크거나 같다면 <see langword="true"/>, 작다면 <see langword="falue"/></returns>
    public static bool operator >=(HangulSyllable left, HangulSyllable right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// 이 한글 음절을 문자열 표현으로 변환
    /// </summary>
    /// <returns>이 한글 음절의 문자열 표현</returns>
    public override string ToString() => Value.ToString();

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is HangulSyllable @char && Equals(@char);

    /// <inheritdoc/>
    public bool Equals(HangulSyllable other) => Value.Equals(other.Value);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode();

    /// <inheritdoc/>
    public int CompareTo(HangulSyllable other) => Value.CompareTo(other.Value);

    /// <summary>
    /// 이 <see cref="HangulSyllable"/>를 초성, 중성, 종성 열거형으로 분해
    /// </summary>
    /// <param name="choseong">초성</param>
    /// <param name="jungseong">중성</param>
    /// <param name="jongseong">종성</param>
    public void Deconstruct(out Choseong choseong, out Jungseong jungseong, out Jongseong jongseong) {
        choseong = Choseong;
        jungseong = Jungseong;
        jongseong = Jongseong;
    }

    private static char getChar(byte choseong, byte jungseong, byte jongseong) => (char)(FirstSyllable + (((choseong * 21) + jungseong) * 28) + jongseong);
}