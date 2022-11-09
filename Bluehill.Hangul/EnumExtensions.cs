namespace Bluehill.Hangul;

/// <summary>
/// 열거형 확장 메서드 모음
/// </summary>
public static class EnumExtensions {
    /// <summary>
    /// 이 <see cref="Choseong"/> 값에 해당하는 초성 문자를 반환
    /// </summary>
    /// <param name="choseong"><see cref="Choseong"/></param>
    /// <returns><paramref name="choseong"/>에 해당하는 <see cref="char"/> 값</returns>
    public static char ToChar(this Choseong choseong) => JamoLookup[0][(int)choseong];

    /// <summary>
    /// 이 <see cref="Jungseong"/> 값에 해당하는 중성 문자를 반환
    /// </summary>
    /// <param name="jungseong"><see cref="Jungseong"/></param>
    /// <returns><paramref name="jungseong"/>에 해당하는 <see cref="char"/> 값</returns>
    public static char ToChar(this Jungseong jungseong) => JamoLookup[1][(int)jungseong];

    /// <summary>
    /// 이 <see cref="Jongseong"/> 값에 해당하는 종성 문자를 반환
    /// </summary>
    /// <param name="jongseong"><see cref="Jongseong"/></param>
    /// <returns><paramref name="jongseong"/>에 해당하는 <see cref="char"/> 값</returns>
    public static char ToChar(this Jongseong jongseong) => JamoLookup[2][(int)jongseong];
}