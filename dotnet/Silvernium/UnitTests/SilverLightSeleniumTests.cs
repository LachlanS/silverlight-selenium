using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace UnitTests
{
    [TestClass]
    public class SilverLightSeleniumTests
    {
        private Mock<IJavaScriptExecutor> _mockJavaScriptExecutor;
        private IJavaScriptExecutor _javaScriptExecutor;
        private Silvernium _silvernium;

        [TestInitialize]
        public void SetUp()
        {
            _mockJavaScriptExecutor = new Mock<IJavaScriptExecutor>();
            _javaScriptExecutor = _mockJavaScriptExecutor.Object;
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
        }

        [TestMethod]
        public void TearDown()
        {
            _mockJavaScriptExecutor.Verify();
        }


        [TestMethod]
        public void ShouldCreateXamlContent()
        {
            _mockJavaScriptExecutor.Setup(x => x.ExecuteScript("return document['Test'].content.createFromXaml('xamlContent','namescope');"));
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            _silvernium.CreateFromXaml("xamlContent", "namescope");
        }

        [TestMethod]
        public void ShouldFindName()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].content.findName('objectName');"))
                .Returns("Return Name");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("Return Name", _silvernium.FindName("objectName"));
        }

        [TestMethod]
        public void ShouldInitParams()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].initParams;"))
                .Returns("List of init params");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("List of init params", _silvernium.InitParams());
        }

        [TestMethod]
        public void ShouldReturnAccessibilityValue()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].content.accessibility;"))
                .Returns("Some Accessibility Return Value");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("Some Accessibility Return Value", _silvernium.Accessibility());
        }

        [TestMethod]
        public void ShouldReturnActualHeightOfMovie()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].content.actualHeight;"))
                .Returns("42");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual(42, _silvernium.ActualHeight());
        }

        [TestMethod]
        public void ShouldReturnActualWidthOfMovie()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].content.actualWidth;"))
                .Returns("24");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual(24, _silvernium.ActualWidth());
        }

        [TestMethod]
        public void ShouldReturnFullScreenAttributes()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].content.fullScreen;"))
                .Returns("True");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.IsTrue(_silvernium.FullScreen());
        }

        [TestMethod]
        public void ShouldReturnTrueIfLoaded()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].isLoaded;"))
                .Returns("True");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.IsTrue(_silvernium.IsLoaded());
        }

        [TestMethod]
        public void ShouldReturnTrueIfVersionIsSupported()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].isVersionSupported('10');"))
                .Returns("true");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.IsTrue(_silvernium.IsVersionSupported("10"));
        }

        [TestMethod]
        public void ShouldReturnRoot()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].root;"))
                .Returns("Root Content");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("Root Content", _silvernium.Root());
        }

        [TestMethod]
        public void ShouldReturnBackgroundInformation()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].settings.background;"))
                .Returns("Bg Info");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("Bg Info", _silvernium.Background());
        }

        [TestMethod]
        public void ShouldCallSettingsProperties()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].settings.enabledFramerateCounter;"))
                .Returns("True");
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].settings.enableRedrawRegions;"))
                .Returns("True");
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].settings.enableHtmlAccess;"))
                .Returns("True");
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].settings.maxFrameRate;"))
                .Returns("42");
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].settings.windowless;"))
                .Returns("True");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.IsTrue(_silvernium.EnabledFrameRateCounter());
            Assert.IsTrue(_silvernium.EnableRedrawRegions());
            Assert.IsTrue(_silvernium.EnableHtmlAccess());
            Assert.AreEqual(42, _silvernium.MaxFrameRate());
            Assert.IsTrue(_silvernium.WindowLess());
        }

        [TestMethod]
        public void ShouldReturnSource()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return document['Test'].source;"))
                .Returns("Source Code");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("Source Code", _silvernium.Source());
        }
    }
}