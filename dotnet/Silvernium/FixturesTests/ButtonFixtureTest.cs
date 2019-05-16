using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ButtonFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void ClickClicks()
        {
            var textBox = App.TextBox("ClearTextBox");
            var button = App.Button("ClearButton");

            textBox.SetText("This text should be cleared by the button above");
            button.Click();
            textBox.RequireText("");
        }

        [TestMethod]
        public void RequireContentPassesForExpectedContent()
        {
            App.Button("ClearButton").RequireContent("This Button clears the TextBox below");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContentThrowsExceptionForUnexpectedContent()
        {
            App.Button("ClearButton").RequireContent("This is not the Button content");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            App.Button("ClearButton").RequireEnabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.Button("DisabledButton").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.Button("DisabledButton").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.Button("ClearButton").RequireDisabled();
        }

    }
}
