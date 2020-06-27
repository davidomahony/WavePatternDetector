/// <summary>
/// Normally copyright stuff
/// </summary>

namespace WaveCounter
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A wave crest is an array with just one crest.
    /// All the elements on the left of the crest are increasing and all on the right decreasing.
    /// The crest cannot be the first or last element.
    /// </summary>
    public class CrestPatternDetector : BasePatternDetector<int>
    {
        public override bool TryToDetectPattern()
        {
            try
            {
                this.CheckInputArrayIsNullOrEmpty();

                List<int> detectedTrough = new List<int>();
                // For crest n -1 < n  && n > n+1

                // Cant be first or last
                for (int i = 1; i < this.DataToTest.Length - 1; i++)
                {
                    if (this.DataToTest[i - 1] < this.DataToTest[i] && this.DataToTest[i] > this.DataToTest[i + 1])
                    {
                        detectedTrough.Add(i);
                    }
                }

                // Based on the description a wave trough or crest must only have one trough. Check summary copied from description in challenge sheet
                this.Result = detectedTrough.Count == 1 ? $"Crest at {this.DataToTest[(int)detectedTrough?.First()]}" : WavePoints.Nothing.ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
