using System.Numerics;

namespace Setters;

// Teaching C#11 INumber
public static class NumericExtensions
{
    public static T Round<T>(this T value, int decimalPlaces) where T : IFloatingPoint<T>
        => T.Round(value, decimalPlaces);
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T>
        => T.Clamp(value, min, max);
}