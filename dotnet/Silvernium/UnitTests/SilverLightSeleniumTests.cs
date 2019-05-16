using Moq;
using NUnit.Framework;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace UnitTests
{
    [TestFixture]
    public class SilverLightSeleniumTests
    {
        private Mock<ISelenium> _mockSelenium;
        private ISelenium _selenium;
        private Silvernium _silvernium;

        [SetUp]
        public void SetUp()
        {
            _mockSelenium = new Mock<ISelenium>();
            _selenium = _mockSelenium.Object;
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
        }

        [TearDown]
        public void TearDown()
        {
            _mockSelenium.Verify();
        }


        [Test]
        public void ShouldCreateXamlContent()
        {
            _mockSelenium.Setup(x => x.GetEval("document['Test'].content.createFromXaml('xamlContent','namescope');"));
            _silvernium = new Silvernium(_selenium, "Test");
            _silvernium.CreateFromXaml("xamlContent", "namescope");
        }

        [Test]
        public void ShouldFindName()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].content.findName('objectName');"))
                .Returns("Return Name");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Return Name", _silvernium.FindName("objectName"));
        }

        [Test]
        public void ShouldInitParams()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].initParams;"))
                .Returns("List of init params");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("List of init params", _silvernium.InitParams());
        }

        [Test]
        public void ShouldReturnAccessibilityValue()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].content.accessibility;"))
                .Returns("Some Accessibility Return Value");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Some Accessibility Return Value", _silvernium.Accessibility());
        }

        [Test]
        public void ShouldReturnActualHeightOfMovie()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].content.actualHeight;"))
                .Returns("42");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual(42, _silvernium.ActualHeight());
        }

        [Test]
        public void ShouldReturnActualWidthOfMovie()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].content.actualWidth;"))
                .Returns("24");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual(24, _silvernium.ActualWidth());
        }

        [Test]
        public void ShouldReturnFullScreenAttributes()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].content.fullScreen;"))
                .Returns("True");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.IsTrue(_silvernium.FullScreen());
        }

        [Test]
        public void ShouldReturnTrueIfLoaded()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].isLoaded;"))
                .Returns("True");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.IsTrue(_silvernium.IsLoaded());
        }

        [Test]
        public void ShouldReturnTrueIfVersionIsSupported()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].isVersionSupported('10');"))
                .Returns("true");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.IsTrue(_silvernium.IsVersionSupported("10"));
        }

        [Test]
        public void ShouldReturnRoot()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].root;"))
                .Returns("Root Content");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Root Content", _silvernium.Root());
        }

        [Test]
        public void ShouldReturnBackgroundInformation()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].settings.background;"))
                .Returns("Bg Info");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Bg Info", _silvernium.Background());
        }

        [Test]
        public void ShouldCallSettingsProperties()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].settings.enabledFramerateCounter;"))
                .Returns("True");
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].settings.enableRedrawRegions;"))
                .Returns("True");
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].settings.enableHtmlAccess;"))
                .Returns("True");
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].settings.maxFrameRate;"))
                .Returns("42");
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].settings.windowless;"))
                .Returns("True");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.IsTrue(_silvernium.EnabledFrameRateCounter());
            Assert.IsTrue(_silvernium.EnableRedrawRegions());
            Assert.IsTrue(_silvernium.EnableHtmlAccess());
            Assert.AreEqual(42, _silvernium.MaxFrameRate());
            Assert.IsTrue(_silvernium.WindowLess());
        }

        [Test]
        public void ShouldReturnSource()
        {
            _mockSelenium
                .Setup(x => x.GetEval("document['Test'].source;"))
                .Returns("Source Code");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Source Code", _silvernium.Source());
        }
    }
}