# Changelog
[Back](README.md)

## 2.0-beta.2 (2022-12-15)
1. 몇몇 곳에서 '문자'에서 '음절'로 표기 수정
1. HangulChar → HangulSyllable 이름 변경
1. IsHangul → IsHangulSyllable 이름 변경
1. IsJamo → IsHangulJamo 이름 변경
1. ToChar → ToJamo 이름 변경
1. 메서드 추가
   1. IsHangul (이전 IsHangul과 다름)
   1. IsHangulConsonant
   1. IsHangulVowel
1. 상수 추가
   1. FirstConsonant
   1. LastConsonant
   1. FirstVowel
   1. LastVowel
   1. HangulFiller
   1. FirstIPFChoseong
   1. LastIPFChoseong
   1. FirstIPFJungseong
   1. LastIPFJungseong
   1. FirstIPFJongseong
   1. LastIPFJongseong

## 2.0-beta.1 (2022-11-24)
1. .NET Framework 2.0 지원 중단 (3.5 이상 필요)
1. HangulChar 추가
1. 어셈블리가 강력한 이름으로 서명됨

## 1.1.1 (2022-11-22)
1. 디버그 기호 (pdb) 제공

## 1.1 (2022-11-04)
1. 초성, 중성, 종성 열거형 추가
1. 문자에서 초성, 중성, 종성 열거형을 얻는 확장 메서드 추가
1. 문자가 한글 문자 또는 낱자인지 확인할 수 있는 <code>IsHangul()</code>, <code>IsJamo()</code> 메서드 추가
1. HangulConstants 추가

## 1.0.1 (2022-10-20)
1. XML 문서 추가
1. ExtensionAttribute 종속성 제거

## 1.0 (2022-10-16)
1. 최초 릴리스
