/// <summary>
/// Normally copyright stuff
/// </summary>

namespace WaveCounter
{
    using System;

    /// <summary>
    /// Pattern detecting interface
    /// </summary>
    /// <typeparam name="T"> Numeric value Ideally</typeparam>
    public interface IPatternDetector<T>
        where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Sets the input array which will be searched by the detector
        /// </summary>
        /// <param name="array"></param>
        void SetDataForPatternDetection(T[] array);

        /// <summary>
        /// Try to detect pattern return true if it successfully ran without any exceptions
        /// </summary>
        /// <returns></returns>
        bool TryToDetectPattern();

        /// <summary>
        /// Result of pattern detector
        /// </summary>
        string Result { get; }
    }
}
