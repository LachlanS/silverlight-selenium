using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class CheckBoxFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void CheckCheckes()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(1).CheckBox("InnerCheckBox")
                .RequireUnchecked()
                .Check()
                .RequireChecked()
                .Uncheck();
        }

        [TestMethod]
        public void UncheckUncheckes()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(0).CheckBox("InnerCheckBox")
                .RequireChecked()
                .Uncheck()
                .RequireUnchecked()
                .Check();
        }

        [TestMethod]
        public void RequireCheckedPassesIfCheckBoxIsChecked()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(0).CheckBox("InnerCheckBox").RequireChecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireCheckedThrowsExceptionIfCheckBoxIsUnchecked()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(1).CheckBox("InnerCheckBox").RequireChecked();
        }

        [TestMethod]
        public void RequireUncheckedPassesIfCheckBoxIsUnchecked()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(1).CheckBox("InnerCheckBox").RequireUnchecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireUncheckedThrowsExceptionIfCheckBoxIsChecked()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(0).CheckBox("InnerCheckBox").RequireUnchecked();
        }

    }
}
