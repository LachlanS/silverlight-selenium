using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace UnitTests
{
    [TestClass]
    public class SilverniumTests
    {
        #region Setup/Teardown

        [TestInitialize]
        public void SetUp()
        {
            _mockJavaScriptExecutor = new Mock<IJavaScriptExecutor>();
            _javaScriptExecutor = _mockJavaScriptExecutor.Object;
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockJavaScriptExecutor.Verify();
        }

        #endregion

        private Mock<IJavaScriptExecutor> _mockJavaScriptExecutor;
        private IJavaScriptExecutor _javaScriptExecutor;
        private Silvernium _silvernium;

        [TestMethod]
        public void ShouldReturnDocumentJsPrefixForFf2()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_javaScriptExecutor, "test");
            Assert.AreEqual("document['test'].", _silvernium.CreateJsPrefixDocument("test"));
        }

        [TestMethod]
        public void ShouldReturnJsFunctionForDirectMethodForFf2()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("return document['Test'].Func1();", _silvernium.JsForDirectMethod("Func1"));
            Assert.AreEqual("return document['Test'].Func2('42');", _silvernium.JsForDirectMethod("Func2", "42"));
            Assert.AreEqual("return document['Test'].Func3('42','24');",
                            _silvernium.JsForDirectMethod("Func3", "42", "24"));
        }

        [TestMethod]
        public void ShouldReturnJsFunctionForDirectMethodForMsie()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("MSIE");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test");
            Assert.AreEqual("return window.document['Test'].Func1();", _silvernium.JsForDirectMethod("Func1"));
            Assert.AreEqual("return window.document['Test'].Func2('42');", _silvernium.JsForDirectMethod("Func2", "42"));
            Assert.AreEqual("return window.document['Test'].Func3('42','24');",
                            _silvernium.JsForDirectMethod("Func3", "42", "24"));
        }

        [TestMethod]
        public void ShouldReturnJsFunctionForScriptMethodForFf2()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test", "Key");
            Assert.AreEqual("return document['Test'].content.Key.Func1();", _silvernium.JsForContentScriptMethod("Func1"));
            Assert.AreEqual("return document['Test'].content.Key.Func2('42');",
                            _silvernium.JsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("return document['Test'].content.Key.Func3('42','24');",
                            _silvernium.JsForContentScriptMethod("Func3", "42", "24"));
        }

        [TestMethod]
        public void ShouldReturnJsFunctionForScriptMethodForFf3()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/3.0.0.1");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test", "Key");
            Assert.AreEqual("return window.document['Test'].content.Key.Func1();", _silvernium.JsForContentScriptMethod("Func1"));
            Assert.AreEqual("return window.document['Test'].content.Key.Func2('42');",
                            _silvernium.JsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("return window.document['Test'].content.Key.Func3('42','24');",
                            _silvernium.JsForContentScriptMethod("Func3", "42", "24"));
        }
        
        [TestMethod]
        public void ShouldReturnJsFunctionForContentMethodForFf2()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/2.0.0.18");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test", "Key");
            Assert.AreEqual("return document['Test'].content.Func1();", _silvernium.JsForContentMethod("Func1"));
            Assert.AreEqual("return document['Test'].content.Func2('42');",
                            _silvernium.JsForContentMethod("Func2", "42"));
            Assert.AreEqual("return document['Test'].content.Func3('42','24');",
                            _silvernium.JsForContentMethod("Func3", "42", "24"));
        }

        [TestMethod]
        public void ShouldReturnJsFunctionForContentMethodForFf3()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/3.0.0.1");
            _silvernium = new Silvernium(_javaScriptExecutor, "Test", "Key");
            Assert.AreEqual("return window.document['Test'].content.Func1();", _silvernium.JsForContentMethod("Func1"));
            Assert.AreEqual("return window.document['Test'].content.Func2('42');",
                            _silvernium.JsForContentMethod("Func2", "42"));
            Assert.AreEqual("return window.document['Test'].content.Func3('42','24');",
                            _silvernium.JsForContentMethod("Func3", "42", "24"));
        }

        [TestMethod]
        public void ShouldReturnWindowDocumentJsPrefixForFf3()
        {
            _mockJavaScriptExecutor
                .Setup(x => x.ExecuteScript("return navigator.userAgent"))
                .Returns("Firefox/3.0.0.1");
            _silvernium = new Silvernium(_javaScriptExecutor, "test");
            Assert.AreEqual("window.document['test'].", _silvernium.CreateJsPrefixWindowDocument("test"));
        }
    }
}