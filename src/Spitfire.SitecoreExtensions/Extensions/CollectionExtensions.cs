namespace Spitfire.SitecoreExtensions.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods to make life easier
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Extension method to make life easier.
        /// </summary>
        /// <typeparam name="T">Type of enumerable</typeparam>
        /// <param name="source">Source enumerable</param>
        /// <returns>A new SmartEnumerable of the appropriate type</returns>
        public static SmartEnumerable<T> AsSmartEnumerable<T>(this IEnumerable<T> source)
        {
            return new SmartEnumerable<T>(source);
        }
    }
}