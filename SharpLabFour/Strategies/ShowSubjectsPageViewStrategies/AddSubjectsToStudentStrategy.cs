using System.Windows.Controls;
using System.Windows;

namespace SharpLabFour.Strategies.ShowSubjectsPageViewStrategies
{
    public class AddSubjectsToStudentStrategy : IShowSubjectsPageViewStrategy
    {
        public void SetShowSubjectsPageView(DataGrid subjectsDataGrid, Button removeButton, Button chooseButton)
        {
            subjectsDataGrid.SelectionMode = DataGridSelectionMode.Extended;
            removeButton.Visibility = Visibility.Hidden;
            chooseButton.Visibility = Visibility.Visible;
        }
    }
}