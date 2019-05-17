using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using ThoughtWorks.Selenium.Silvernium;

namespace IntegrationTests
{
    [TestClass]
    public class SilverniumIntegrationTests
    {
        private IWebDriver _webDriver;
        private Silvernium _silvernium;

        [TestInitialize]
        public void SetUp()
        {
            var driver = new InternetExplorerDriver {Url = "http://localhost"};

            _silvernium = new Silvernium(driver, "Test");
            _webDriver = driver;
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Close();
        }

        [TestMethod]
        public void ShouldSpawnBrowserOnSeleniumAndFetchSilverLightJsStringPreixForMsie()
        {
            Assert.AreEqual("window.document['Test'].", _silvernium.SilverLightJSStringPrefix);
        }
    }
}