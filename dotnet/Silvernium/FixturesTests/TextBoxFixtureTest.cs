using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class TextBoxFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireTextPassesForCorrectValues()
        {
            App.TextBox("TextBox").RequireText("This is a TextBox");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireTextThrowsExceptionForIncorrectValues()
        {
            App.TextBox("TextBox").RequireText("This is not a TextBox");
        }

        [TestMethod]
        public void RequireContainsPassesForExactValues()
        {
            App.TextBox("TextBox").RequireContains("This is a TextBox");
        }
        
        [TestMethod]
        public void RequireContainsPassesForPartialValues()
        {
            App.TextBox("TextBox").RequireContains("is a Text");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContainsThrowsExceptionForIncorrectValues()
        {
            App.TextBox("TextBox").RequireContains("is not a Text");
        }

        [TestMethod]
        public void RequireNotContainsPassesForAbsentValues()
        {
            App.TextBox("TextBox").RequireNotContains("is not a Text");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireNotContainsThrowsExceptionForPresentValues()
        {
            App.TextBox("TextBox").RequireNotContains("is a Text");
        }

        [TestMethod]
        public void SetTextChangesTextBoxValue()
        {
            App.TextBox("TextBox")
                .RequireText("This is a TextBox")

                .SetText("This is still a TextBox")
                .RequireText("This is still a TextBox")

                .SetText("This is a TextBox")
                .RequireText("This is a TextBox");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            App.TextBox("TextBox").RequireEnabled();
        }
        
        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.TextBox("DisabledTextBox").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.TextBox("DisabledTextBox").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.TextBox("TextBox").RequireDisabled();
        }

    }

}
