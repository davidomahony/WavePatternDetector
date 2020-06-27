/// <summary>
/// Normally copyright stuff
/// </summary>

namespace WaveCounter
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A wave trough is an array with just one trough.
    /// All the elements on the left of the trough are decreasing and all on the right increasing.
    /// The trough cannot be the first or last element.
    /// </summary>
    public class TroughPatternDetector : BasePatternDetector<int>
    {
        public override bool TryToDetectPattern()
        {
            try
            {
                this.CheckInputArrayIsNullOrEmpty();

                List<int> detectedCrests = new List<int>();
                // For crest n -1 < n  && n > n+1

                // Cant be first or last
                for (int i = 1; i < this.DataToTest.Length - 1; i++)
                {
                    if (this.DataToTest[i - 1] > this.DataToTest[i] && this.DataToTest[i] < this.DataToTest[i + 1])
                    {
                        detectedCrests.Add(i);
                    }
                }

                // Based on the description a wave trough or crest must only have one trough. Check summary copied from description in challenge sheet
                this.Result = detectedCrests.Count == 1 ? $"Trough at {this.DataToTest[(int)detectedCrests?.First()]}" : WavePoints.Nothing.ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
