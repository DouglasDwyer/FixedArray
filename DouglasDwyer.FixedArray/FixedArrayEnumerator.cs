using System.Collections;

namespace DouglasDwyer.FixedArray
{
    /// <summary>
    /// Enumerates the elements of a fixed-size array.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <typeparam name="A">The fixed-size array type being enumerated.</typeparam>
    public struct FixedArrayEnumerator<T, A> : IEnumerator<T> where A : IFixedArray<T>
    {
        private readonly A _array;
        private int _index;

        /// <inheritdoc/>
        public T Current
        {
            get
            {
                // Unsigned cast treats negative _index as a very large number,
                // catching both "before first MoveNext" and "past end" in one check.
                if ((uint)_index >= (uint)_array.Length)
                    throw new InvalidOperationException("Enumerator is positioned before the first or after the last element.");
                return _array.Get(_index);
            }
        }

        /// <inheritdoc/>
        object IEnumerator.Current => Current!;

        /// <summary>
        /// Creates an enumerator for the given array.
        /// </summary>
        /// <param name="array">The array to enumerate.</param>
        public FixedArrayEnumerator(A array)
        {
            _array = array;
            _index = -1;
        }

        /// <inheritdoc/>
        public void Dispose() { }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            _index++;
            return _index < _array.Length;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            _index = -1;
        }
    }
}
