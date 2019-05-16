using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class CheckBoxFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestInitialize]
        public void ResetReferenceCheckBox()
        {
            App.CheckBox("CheckBox").Uncheck();
        }

        [TestMethod]
        public void CheckCheckes()
        {
            App.CheckBox("CheckBox")
                .Check()
                .RequireChecked();
        }

        [TestMethod]
        public void UncheckUncheckes()
        {
            App.CheckBox("CheckBox")
                .Uncheck()
                .RequireUnchecked();
        }

        [TestMethod]
        public void RequireCheckedPassesIfCheckBoxIsChecked()
        {
            App.CheckBox("CheckBox")
                .Check()
                .RequireChecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireCheckedThrowsExceptionIfCheckBoxIsUnchecked()
        {
            App.CheckBox("CheckBox")
                .RequireChecked();

        }

        [TestMethod]
        public void RequireUncheckedPassesIfCheckBoxIsUnchecked()
        {
            App.CheckBox("CheckBox")
                .RequireUnchecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireUncheckedThrowsExceptionIfCheckBoxIsChecked()
        {
            App.CheckBox("CheckBox")
                .Check()
                .RequireUnchecked();
        }

    }
}
