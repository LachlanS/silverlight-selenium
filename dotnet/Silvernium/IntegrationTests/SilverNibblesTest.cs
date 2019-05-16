using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using Selenium;
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
        private ISelenium _selenium;
        private Silvernium _silvernium;

        [TestInitialize]
        public void SetUp()
        {
            var uriBuilder = new UriBuilder { Host = "localhost", Port = 4444 };

            var driver = new InternetExplorerDriver();
            _selenium = new WebDriverBackedSelenium(driver, uriBuilder.Uri);

            _selenium.Start();
            _selenium.Open(Url);
            _silvernium = new Silvernium(_selenium, ObjectId, ScriptKey);
        }

        [TestCleanup]
        public void TearDown()
        {
            _selenium.Stop();
        }
        [TestMethod]
        public void ShouldCommunicateWithSilverNibbleApplication()
        {
            Assert.AreEqual("SilverNibbles", _selenium.GetTitle());
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