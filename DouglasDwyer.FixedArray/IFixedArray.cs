namespace DouglasDwyer.FixedArray
{
    /// <summary>
    /// Marks a fixed-size stack-allocated array type.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    public interface IFixedArray<T>
    {
        /// <summary>
        /// The number of elements in the array.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Returns the element at the given index.
        /// </summary>
        /// <param name="i">The zero-based index.</param>
        /// <returns>The element at position <paramref name="i"/>.</returns>
        T Get(int i);
    }
}
