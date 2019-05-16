using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class TextBlockFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireTextPassesForCorrectValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("InnerTextBlock").RequireText("TextBlock 1");
            dataGrid.RowByIndex(1).TextBlock("InnerTextBlock").RequireText("TextBlock 2");
            dataGrid.RowByIndex(2).TextBlock("InnerTextBlock").RequireText("TextBlock 3");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireTextThrowsExceptionForIncorrectValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("InnerTextBlock").RequireText("TextBlock 2");
        }

        [TestMethod]
        public void RequireContainsPassesForExactValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("InnerTextBlock").RequireContains("TextBlock 1");
            dataGrid.RowByIndex(1).TextBlock("InnerTextBlock").RequireContains("TextBlock 2");
            dataGrid.RowByIndex(2).TextBlock("InnerTextBlock").RequireContains("TextBlock 3");
        }

        [TestMethod]
        public void RequireContainsPassesForPartialValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("InnerTextBlock").RequireContains("Block 1");
            dataGrid.RowByIndex(1).TextBlock("InnerTextBlock").RequireContains("Block 2");
            dataGrid.RowByIndex(2).TextBlock("InnerTextBlock").RequireContains("Block 3");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContainsThrowsExceptionForIncorrectValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("InnerTextBlock").RequireContains("Block 2");
        }

        [TestMethod]
        public void RequireNotContainsPassesForAbsentValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("InnerTextBlock").RequireNotContains("Block 2");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireNotContainsThrowsExceptionForPresentValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("InnerTextBlock").RequireNotContains("Block 1");
        }

    }
}
