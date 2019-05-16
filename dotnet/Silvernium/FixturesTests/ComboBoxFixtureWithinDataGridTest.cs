using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ComboBoxFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireValuePassesForCorrectValues()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("InnerComboBox").RequireValue("Option 1");
            dataGrid.RowByIndex(1).ComboBox("InnerComboBox").RequireValue("Option 2");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValue()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("InnerComboBox").RequireValue("Option 2");
        }

        [TestMethod]
        public void SetValueChangesComboBoxValue()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("InnerComboBox")
                .RequireValue("Option 1")
                .SetValue("Option 2")
                .RequireValue("Option 2")
                .SetValue("Option 1");
            dataGrid.RowByIndex(1).ComboBox("InnerComboBox")
                .RequireValue("Option 2")
                .SetValue("Option 1")
                .RequireValue("Option 1")
                .SetValue("Option 2");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("InnerComboBox").RequireEnabled();
            dataGrid.RowByIndex(1).ComboBox("InnerComboBox").RequireEnabled();
        }
        
        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(2).ComboBox("InnerComboBox").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(2).ComboBox("InnerComboBox").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            var dataGrid = App.DataGrid("EditableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("InnerComboBox").RequireDisabled();
        }

    }

}
