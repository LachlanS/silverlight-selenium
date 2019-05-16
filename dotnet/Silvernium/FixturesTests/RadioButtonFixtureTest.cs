using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class RadioButtonFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestInitialize]
        public void ResetReferenceRadioButton()
        {
            App.RadioButton("RadioButtonILike").Select();
        }

        [TestMethod]
        public void SelectSelectsTheRadioButtonAndUnselectOtherRadiosInTheSameGroup()
        {
            var radioButtonILike = App.RadioButton("RadioButtonILike");
            var radioButtonIHate = App.RadioButton("RadioButtonIHate");

            radioButtonIHate
                .Select()
                .RequireSelected();
            radioButtonILike
                .RequireUnselected()
                .Select()
                .RequireSelected();
            radioButtonIHate
                .RequireUnselected();
        }

        [TestMethod]
        public void RequireSelectedPassesIfTheRadioButtonIsSelected()
        {
            App.RadioButton("RadioButtonILike").RequireSelected();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireSelectedThrowsExceptionIfTheRadioButtonIsUnselected()
        {
            App.RadioButton("RadioButtonIHate").RequireSelected();
        }

        [TestMethod]
        public void RequireUnselectedPassesIfTheRadioButtonIsNotSelected()
        {
            App.RadioButton("RadioButtonIHate").RequireUnselected();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireUnselectedThrowsExceptionIfTheRadioButtonIsSelected()
        {
            App.RadioButton("RadioButtonILike").RequireUnselected();
        }

    }
}
