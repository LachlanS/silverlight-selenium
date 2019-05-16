using System;
using NUnit.Framework;
using OpenQA.Selenium.IE;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace IntegrationTests
{
    [TestFixture]
    public class SilverniumIntegrationTests
    {
        private ISelenium _selenium;
        private Silvernium _silvernium;

        [SetUp]
        public void SetUp()
        {
            var uriBuilder = new UriBuilder { Host = "localhost", Port = 4444 };

            var driver = new InternetExplorerDriver();
            _selenium = new WebDriverBackedSelenium(driver, uriBuilder.Uri);

            _selenium.Start();
            _selenium.Open("http://localhost");
            _silvernium = new Silvernium(_selenium, "Test");
        }

        [TearDown]
        public void TearDown()
        {
            _selenium.Stop();
        }

        [Test]
        public void ShouldSpawnBrowserOnSeleniumAndFetchSilverLightJsStringPreixForMsie()
        {
            Assert.AreEqual("window.document['Test'].", _silvernium.SilverLightJSStringPrefix);
        }
    }
}