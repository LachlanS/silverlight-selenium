using NMock;
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
            _mockProcessor = new DynamicMock(typeof (ISelenium));
            _selenium = (ISelenium) _mockProcessor.MockInstance;
        }

        [TearDown]
        public void TearDown()
        {
            _mockProcessor.Verify();
        }

        #endregion

        private DynamicMock _mockProcessor;
        private ISelenium _selenium;
        private Silvernium _silvernium;

        [Test]
        public void ShouldReturnDocumentJsPrefixForFf2()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "test");
            Assert.AreEqual("document['test'].", _silvernium.CreateJsPrefixDocument("test"));
        }

        [Test]
        public void ShouldReturnJsFunctionForDirectMethodForFf2()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("document['Test'].Func1();", _silvernium.JsForDirectMethod("Func1"));
            Assert.AreEqual("document['Test'].Func2('42');", _silvernium.JsForDirectMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].Func3('42','24');",
                            _silvernium.JsForDirectMethod("Func3", new[] {"42", "24"}));
        }

        [Test]
        public void ShouldReturnJsFunctionForDirectMethodForMsie()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "MSIE", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "Test");
            Assert.AreEqual("window.document['Test'].Func1();", _silvernium.JsForDirectMethod("Func1"));
            Assert.AreEqual("window.document['Test'].Func2('42');", _silvernium.JsForDirectMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].Func3('42','24');",
                            _silvernium.JsForDirectMethod("Func3", new[] {"42", "24"}));
        }

        [Test]
        public void ShouldReturnJsFunctionForScriptMethodForFf2()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("document['Test'].content.Key.Func1();", _silvernium.JsForContentScriptMethod("Func1"));
            Assert.AreEqual("document['Test'].content.Key.Func2('42');",
                            _silvernium.JsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].content.Key.Func3('42','24');",
                            _silvernium.JsForContentScriptMethod("Func3", new[] {"42", "24"}));
        }

        [Test]
        public void ShouldReturnJsFunctionForScriptMethodForFf3()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/3.0.0.1", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("window.document['Test'].content.Key.Func1();", _silvernium.JsForContentScriptMethod("Func1"));
            Assert.AreEqual("window.document['Test'].content.Key.Func2('42');",
                            _silvernium.JsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].content.Key.Func3('42','24');",
                            _silvernium.JsForContentScriptMethod("Func3", new[] {"42", "24"}));
        }
        
        [Test]
        public void ShouldReturnJsFunctionForContentMethodForFf2()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("document['Test'].content.Func1();", _silvernium.JsForContentMethod("Func1"));
            Assert.AreEqual("document['Test'].content.Func2('42');",
                            _silvernium.JsForContentMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].content.Func3('42','24');",
                            _silvernium.JsForContentMethod("Func3", new[] { "42", "24" }));
        }

        [Test]
        public void ShouldReturnJsFunctionForContentMethodForFf3()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/3.0.0.1", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "Test", "Key");
            Assert.AreEqual("window.document['Test'].content.Func1();", _silvernium.JsForContentMethod("Func1"));
            Assert.AreEqual("window.document['Test'].content.Func2('42');",
                            _silvernium.JsForContentMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].content.Func3('42','24');",
                            _silvernium.JsForContentMethod("Func3", new[] { "42", "24" }));
        }

        [Test]
        public void ShouldReturnWindowDocumentJsPrefixForFf3()
        {
            _mockProcessor.ExpectAndReturn("GetEval", "Firefox/3.0.0.1", "navigator.userAgent");
            _silvernium = new Silvernium(_selenium, "test");
            Assert.AreEqual("window.document['test'].", _silvernium.CreateJsPrefixWindowDocument("test"));
        }
    }
}