using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace IntegrationTests
{
    [TestClass]
    public class SilverniumIntegrationTests
    {
        private ISelenium _selenium;
        private Silvernium _silvernium;

        [TestInitialize]
        public void SetUp()
        {
            var uriBuilder = new UriBuilder { Host = "localhost", Port = 4444 };

            var driver = new InternetExplorerDriver();
            _selenium = new WebDriverBackedSelenium(driver, uriBuilder.Uri);

            _selenium.Start();
            _selenium.Open("http://localhost");
            _silvernium = new Silvernium(_selenium, "Test");
        }

        [TestCleanup]
        public void TearDown()
        {
            _selenium.Stop();
        }

        [TestMethod]
        public void ShouldSpawnBrowserOnSeleniumAndFetchSilverLightJsStringPreixForMsie()
        {
            Assert.AreEqual("window.document['Test'].", _silvernium.SilverLightJSStringPrefix);
        }
    }
}