using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using ThoughtWorks.Selenium.Silvernium;

namespace IntegrationTests
{
    [TestClass]
    [Ignore] /* URL is gone; migrate this to https://github.com/markheath/nibbles ? */
    public class SilverNibblesTest
    {
        private const string Url = "http://www.markheath.me.uk/silvernibbles";
        private const string ObjectId = "SilverlightControl";
        private const string ScriptKey = "SilverNibbles";
        private IWebDriver _webDriver;
        private Silvernium _silvernium;

        [TestInitialize]
        public void SetUp()
        {
            var driver = new InternetExplorerDriver {Url = Url};

            _webDriver = driver;
            _silvernium = new Silvernium(driver, ObjectId, ScriptKey);
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Close();
        }
        [TestMethod]
        public void ShouldCommunicateWithSilverNibbleApplication()
        {
            Assert.AreEqual("SilverNibbles", _webDriver.Title);
            // verifies default properties in the silverlight object
            Assert.AreEqual(640, _silvernium.ActualWidth());
            Assert.AreEqual(460, _silvernium.ActualHeight());

            // verifies user defined properties and methods
            // content.SilverNibbles.StartingSpeed;,  returns 5
            Assert.AreEqual("5", _silvernium.GetPropertyValue("StartingSpeed"));
            // content.SilverNibbles.NewGame('1');,  returns null
            Assert.AreEqual("null", _silvernium.Call("NewGame", "1"));


            // testing set and get for a user defined property
            Assert.AreEqual("5", _silvernium.GetPropertyValue("StartingSpeed"));
            // setting the property
            _silvernium.SetPropertyValue("StartingSpeed", "8");
            // getting it again
            Assert.AreEqual("8", _silvernium.GetPropertyValue("StartingSpeed"));
        }
    }
}