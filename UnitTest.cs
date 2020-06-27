/// <summary>
/// Normally copyright stuff
/// </summary>

namespace WaveCounter
{
    using NUnit.Framework;

    /// <summary>
    /// Test cases for pattern detectors
    /// </summary>
    public class Tests
    {
        private const string Nothing = "Nothing";

        private readonly int[] testNullArray = null;
        private readonly int[] testEmptyArray = new int[0];
        private IPatternDetector<int> patternDetector;

        public void Setup(IPatternDetector<int> detector, int[] array)
        {
            this.patternDetector = detector;
            this.patternDetector.SetDataForPatternDetection(array);
        }

        [TestCase(new int [] { 1, 2, 3, 4, 5, 6, 7, 6, 5, 4, 3, 2, 1}, "Crest at 7")]
        [TestCase(new int[] { 1, 2, 3, 1, 2, 3, 2, 3, 2 }, Nothing)]
        [TestCase(new int[] { 0, 0, 0, 0 }, Nothing)]
        public void TestCrestPatternDetector(int[] input, string expected)
        {
            this.Setup(new CrestPatternDetector(), input);

            if (this.patternDetector.TryToDetectPattern())
            {
                Assert.AreEqual(this.patternDetector.Result, expected);
            }
        }

        [TestCase(new int[] { 61, 52, 43, 34, 25, 16, 7, 16, 25, 34, 43, 52, 61 }, "Trough at 7")]
        [TestCase(new int[] { 1, 2, 3, 1, 2, 3, 2, 3, 2 }, Nothing)]
        [TestCase(new int[] { 0, 0, 0, 0 }, Nothing)]
        public void TestTroughPatternDetector(int[] input, string expected)
        {
            this.Setup(new TroughPatternDetector(), input);

            if (this.patternDetector.TryToDetectPattern())
            {
                Assert.AreEqual(this.patternDetector.Result, expected);
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 6, 5, 4, 3, 2, 1 }, "Crest")]
        [TestCase(new int[] { 61, 52, 43, 34, 25, 16, 7, 16, 25, 34, 43, 52, 61 }, "Trough")]
        [TestCase(new int[] { 1, 2, 3, 1, 2, 3, 2, 3, 2 }, Nothing)]
        [TestCase(new int[] { 0, 0, 0, 0 }, Nothing)]
        public void TestWavePatternDetector(int[] input, string expected)
        {
            this.Setup(new WavePatternDetector(new CrestPatternDetector(), new TroughPatternDetector()), input);

            if (this.patternDetector.TryToDetectPattern())
            {
                Assert.AreEqual(this.patternDetector.Result, expected);
            }
        }

        [Test]
        public void TestNullArray()
        {
            IPatternDetector<int> detector = new CrestPatternDetector();
            detector.SetDataForPatternDetection(this.testNullArray);
            Assert.IsFalse(detector.TryToDetectPattern());

            detector = new TroughPatternDetector();
            detector.SetDataForPatternDetection(this.testNullArray);
            Assert.IsFalse(detector.TryToDetectPattern());

            detector = new WavePatternDetector(new CrestPatternDetector(), new TroughPatternDetector());
            detector.SetDataForPatternDetection(this.testNullArray);
            Assert.IsFalse(detector.TryToDetectPattern());
        }

        [Test]
        public void TestEmptyArray()
        {
            IPatternDetector<int> detector = new CrestPatternDetector();
            detector.SetDataForPatternDetection(this.testEmptyArray);
            Assert.IsFalse(detector.TryToDetectPattern());

            detector = new TroughPatternDetector();
            detector.SetDataForPatternDetection(this.testEmptyArray);
            Assert.IsFalse(detector.TryToDetectPattern());

            detector = new WavePatternDetector(new CrestPatternDetector(), new TroughPatternDetector());
            detector.SetDataForPatternDetection(this.testEmptyArray);
            Assert.IsFalse(detector.TryToDetectPattern());
        }
    }
}