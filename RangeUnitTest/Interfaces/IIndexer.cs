
using System.ComponentModel.DataAnnotations.Schema;

namespace RangeUnitTest.Interfaces;

/// <summary>
/// Add Index properties to class
/// </summary>
public interface IIndexer
{
    /// <summary>
    /// Start <see cref="Index"/>
    /// </summary>
    public Index StartIndex { get; set; }
    /// <summary>
    /// End <see cref="Index"/>
    /// </summary>
    [NotMapped]
    public Index EndIndex { get; set; }

}