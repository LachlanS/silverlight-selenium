using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ButtonFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void ClickClicks()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");

            dataGrid.RowByIndex(0).Button("InnerButton").Click();
            App.TextBlock("MessageTextBlock").RequireText("Clicked at Button 1");
            App.Button("OkButton").Click();

            dataGrid.RowByIndex(1).Button("InnerButton").Click();
            App.TextBlock("MessageTextBlock").RequireText("Clicked at Button 2");
            App.Button("OkButton").Click();
        }

        [TestMethod]
        public void RequireContentPassesForExpectedContent()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).Button("InnerButton").RequireContent("Button 1");
            dataGrid.RowByIndex(1).Button("InnerButton").RequireContent("Button 2");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContentThrowsExceptionForUnexpectedContent()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(0).Button("InnerButton").RequireContent("This is not the Button content");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).Button("InnerButton").RequireEnabled();
            dataGrid.RowByIndex(1).Button("InnerButton").RequireEnabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(2).Button("InnerButton").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(2).Button("InnerButton").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.DataGrid("EditableDataGrid").RowByIndex(0).Button("InnerButton").RequireDisabled();
        }

    }
}
