namespace RangeUnitTest.Classes;

/// <summary>
/// Container for <see cref="Helpers.RangeDetails"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public class ElementContainer<T>
{
    public T Value { get; set; }
    public Index StartIndex { get; set; }
    public Index EndIndex { get; set; }
}