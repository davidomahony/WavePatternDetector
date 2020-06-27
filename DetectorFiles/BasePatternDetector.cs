/// <summary>
/// Normally copyright stuff
/// </summary>

namespace WaveCounter
{
    using System;

    /// <summary>
    /// Base pattern detecting class for setting data and validating
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasePatternDetector<T> : IPatternDetector<T>
        where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Data to check for a pattern
        /// </summary>
        public T[] DataToTest { get; private set; }

        /// <summary>
        /// Result from pattern detector
        /// </summary>
        public string Result { get; protected set; }

        /// inheritdoc
        public void SetDataForPatternDetection(T[] array)
        {
            this.DataToTest = array;
        }

        /// inheritdoc
        public abstract bool TryToDetectPattern();

        /// <summary>
        /// Check array is not null or empty
        /// </summary>
        public void CheckInputArrayIsNullOrEmpty()
        {
            if (this.DataToTest == null || this.DataToTest.Length == 0)
            {
                throw new ArgumentException("Inputted pattern is either null or empty");
            }
        }
    }
}
