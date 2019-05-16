using Moq;
using NUnit.Framework;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace UnitTests
{
    [TestFixture]
    public class SilverniumTests
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _mockSelenium = new Mock<ISelenium>();
            _selenium = _mockSelenium.Object;
        }

        [TearDown]
        public void TearDown()
        {
            _mockSelenium.Verify();
        }

        #endregion

        private Mock<ISelenium> _mockSelenium;
        private ISelenium _selenium;
        private Silvernium _silvernium;

        [Test]
        public void ShouldReturnDocumentJsPrefixForFf2()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_selenium, "test");
            Assert.AreEqual("document['test'].", _silvernium.CreateJsPrefixDocument("test"));
        }

        [Test]
        public void ShouldReturnJsFunctionForDirectMethodForFf2()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("document['Test'].Func1();", _silvernium.JsForDirectMethod("Func1"));
            Assert.AreEqual("document['Test'].Func2('42');", _silvernium.JsForDirectMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].Func3('42','24');",
                            _silvernium.JsForDirectMethod("Func3", "42", "24"));
        }

        [Test]
        public void ShouldReturnJsFunctionForDirectMethodForMsie()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("MSIE");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("window.document['Test'].Func1();", _silvernium.JsForDirectMethod("Func1"));
            Assert.AreEqual("window.document['Test'].Func2('42');", _silvernium.JsForDirectMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].Func3('42','24');",
                            _silvernium.JsForDirectMethod("Func3", "42", "24"));
        }

        [Test]
        public void ShouldReturnJsFunctionForScriptMethodForFf2()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("document['Test'].content.Key.Func1();", _silvernium.JsForContentScriptMethod("Func1"));
            Assert.AreEqual("document['Test'].content.Key.Func2('42');",
                            _silvernium.JsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].content.Key.Func3('42','24');",
                            _silvernium.JsForContentScriptMethod("Func3", "42", "24"));
        }

        [Test]
        public void ShouldReturnJsFunctionForScriptMethodForFf3()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/3.0.0.1");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("window.document['Test'].content.Key.Func1();", _silvernium.JsForContentScriptMethod("Func1"));
            Assert.AreEqual("window.document['Test'].content.Key.Func2('42');",
                            _silvernium.JsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].content.Key.Func3('42','24');",
                            _silvernium.JsForContentScriptMethod("Func3", "42", "24"));
        }
        
        [Test]
        public void ShouldReturnJsFunctionForContentMethodForFf2()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("document['Test'].content.Func1();", _silvernium.JsForContentMethod("Func1"));
            Assert.AreEqual("document['Test'].content.Func2('42');",
                            _silvernium.JsForContentMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].content.Func3('42','24');",
                            _silvernium.JsForContentMethod("Func3", "42", "24"));
        }

        [Test]
        public void ShouldReturnJsFunctionForContentMethodForFf3()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/3.0.0.1");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("window.document['Test'].content.Func1();", _silvernium.JsForContentMethod("Func1"));
            Assert.AreEqual("window.document['Test'].content.Func2('42');",
                            _silvernium.JsForContentMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].content.Func3('42','24');",
                            _silvernium.JsForContentMethod("Func3", "42", "24"));
        }

        [Test]
        public void ShouldReturnWindowDocumentJsPrefixForFf3()
        {
            _mockSelenium
                .Setup(x => x.GetEval("navigator.userAgent"))
                .Returns("Firefox/3.0.0.1");
            _silvernium = new Silvernium(_selenium, "test");
            Assert.AreEqual("window.document['test'].", _silvernium.CreateJsPrefixWindowDocument("test"));
        }
    }
}