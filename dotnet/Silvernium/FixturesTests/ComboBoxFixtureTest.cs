using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ComboBoxFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireValuePassesForCorrectValues()
        {
            App.ComboBox("SimpleComboBox").RequireValue("Option 1");
            App.ComboBox("DisplayMemberPathComboBox").RequireValue("Arthur");
            App.ComboBox("ComplexComboBox").RequireValue("Red");
            App.ComboBox("DisabledComboBox").RequireValue("Disabled ComboBox");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValueInASimpleComboBox()
        {
            App.TextBox("SimpleComboBox").RequireText("This is not my value");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValueInADisplayMemberPathComboBox()
        {
            App.TextBox("DisplayMemberPathComboBox").RequireText("This is not my value");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValueInADisabledComboBox()
        {
            App.TextBox("DisabledComboBox").RequireText("This is not my value");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValueInAComplexComboBox()
        {
            App.TextBox("ComplexComboBox").RequireText("This is not my value");
        }

        [TestMethod]
        public void SetValueChangesComboBoxValue()
        {
            App.ComboBox("SimpleComboBox")
                .RequireValue("Option 1")
                .SetValue("Option 2")
                .RequireValue("Option 2")
                .SetValue("Option 3")
                .RequireValue("Option 3")
                .SetValue("Option 1")
                .RequireValue("Option 1");

            App.ComboBox("DisplayMemberPathComboBox")
                .RequireValue("Arthur")
                .SetValue("John")
                .RequireValue("John")
                .SetValue("Richard")
                .RequireValue("Richard")
                .SetValue("Arthur")
                .RequireValue("Arthur");

            App.ComboBox("ComplexComboBox")
                .RequireValue("Red")
                .SetValue("Green")
                .RequireValue("Green")
                .SetValue("Blue")
                .RequireValue("Blue")
                .SetValue("Red")
                .RequireValue("Red");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            App.ComboBox("SimpleComboBox").RequireEnabled();
        }
        
        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.ComboBox("DisabledComboBox").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.ComboBox("DisabledComboBox").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.ComboBox("SimpleComboBox").RequireDisabled();
        }

    }

}
