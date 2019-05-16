using NMock;
using NUnit.Framework;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace UnitTests
{
    [TestFixture]
    public class SilverLightSeleniumTests
    {
        private DynamicMock _mockProcessor;
        private ISelenium _selenium;
        private Silvernium _silvernium;

        [SetUp]
        public void SetUp()
        {
            _mockProcessor = new DynamicMock(typeof (ISelenium));
            _selenium = (ISelenium) _mockProcessor.MockInstance;
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
        }

        [TearDown]
        public void TearDown()
        {
            _mockProcessor.Verify();
        }


        [Test]
        public void ShouldCreateXamlContent()
        {
            _mockProcessor.Expect("GetEval", "document['Test'].content.createFromXaml('xamlContent','namescope');");
            _silvernium = new Silvernium(_selenium, "Test");
            _silvernium.CreateFromXaml("xamlContent", "namescope");
        }

        [Test]
        public void ShouldFindName()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Return Name", "document['Test'].content.findName('objectName');");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Return Name", _silvernium.FindName("objectName"));
        }

        [Test]
        public void ShouldInitParams()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "List of init params", "document['Test'].initParams;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("List of init params", _silvernium.InitParams());
        }

        [Test]
        public void ShouldReturnAccessibilityValue()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Some Accessibility Return Value",
                                          "document['Test'].content.accessibility;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Some Accessibility Return Value", _silvernium.Accessibility());
        }

        [Test]
        public void ShouldReturnActualHeightOfMovie()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "42", "document['Test'].content.actualHeight;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual(42, _silvernium.ActualHeight());
        }

        [Test]
        public void ShouldReturnActualWidthOfMovie()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "24", "document['Test'].content.actualWidth;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual(24, _silvernium.ActualWidth());
        }

        [Test]
        public void ShouldReturnFullScreenAttributes()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].content.fullScreen;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.IsTrue(_silvernium.FullScreen());
        }

        [Test]
        public void ShouldReturnTrueIfLoaded()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].isLoaded;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.IsTrue(_silvernium.IsLoaded());
        }

        [Test]
        public void ShouldReturnTrueIfVersionIsSupported()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "true", "document['Test'].isVersionSupported('10');");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.IsTrue(_silvernium.IsVersionSupported("10"));
        }

        [Test]
        public void ShouldReturnRoot()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Root Content", "document['Test'].root;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Root Content", _silvernium.Root());
        }

        [Test]
        public void ShouldReturnBackgroundInformation()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Bg Info", "document['Test'].settings.background;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Bg Info", _silvernium.Background());
        }

        [Test]
        public void ShouldCallSettingsProperties()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.enabledFramerateCounter;");
            _mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.enableRedrawRegions;");
            _mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.enableHtmlAccess;");
            _mockProcessor.ExpectAndReturn("GetEval", "42", "document['Test'].settings.maxFrameRate;");
            _mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.windowless;");
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
            _mockProcessor.ExpectAndReturn("GetEval", "Source Code", "document['Test'].source;");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("Source Code", _silvernium.Source());
        }
    }
}