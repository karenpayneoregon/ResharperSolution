using System.ComponentModel.DataAnnotations.Schema;
using RangeUnitTest.Interfaces;

namespace RangeUnitTest.Classes
{
    public class City : IIndexer
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of city
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Start <see cref="Index"/>
        /// </summary>
        [NotMapped]
        public Index StartIndex { get; set; }
        /// <summary>
        /// End <see cref="Index"/>
        /// </summary>
        [NotMapped]
        public Index EndIndex { get; set; }
        /// <summary>
        /// Visual for inspection
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name,25} {StartIndex, 3} {EndIndex,4}";

    }
}
