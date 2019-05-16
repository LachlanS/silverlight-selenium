using NUnit.Framework;
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
            _selenium = new DefaultSelenium("localhost", 4444, "*iexplore", "http://localhost");
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