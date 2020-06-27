/// <summary>
/// Normally copyright stuff
/// </summary>

namespace WaveCounter
{

    public class WavePatternDetector : BasePatternDetector<int>
    {
        IPatternDetector<int> crestDetector;
        IPatternDetector<int> troughDetector;

        public WavePatternDetector(IPatternDetector<int> crestDetector, IPatternDetector<int> troughDetector)
        {
            this.crestDetector = crestDetector;
            this.troughDetector = troughDetector;
        }

        public override bool TryToDetectPattern()
        {
            try
            {
                this.CheckInputArrayIsNullOrEmpty();

                this.troughDetector.SetDataForPatternDetection(this.DataToTest);
                this.crestDetector.SetDataForPatternDetection(this.DataToTest);
                if (this.troughDetector.TryToDetectPattern() && this.crestDetector.TryToDetectPattern())
                {
                    bool troughFound = false;
                    bool crestFound = false;
                    if(!this.troughDetector.Result.Equals(WavePoints.Nothing.ToString()))
                    {
                        troughFound = true;
                    }

                    if (!this.crestDetector.Result.Equals(WavePoints.Nothing.ToString()))
                    {
                        crestFound = true;
                    }

                    this.Result = troughFound && !crestFound ? WavePoints.Trough.ToString()
                        : !troughFound && crestFound ? WavePoints.Crest.ToString() : WavePoints.Nothing.ToString();

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
