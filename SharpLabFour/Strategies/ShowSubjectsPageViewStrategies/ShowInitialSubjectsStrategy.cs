using System.Windows;
using System.Windows.Controls;

namespace SharpLabFour.Strategies.ShowSubjectsPageViewStrategies
{
    public class ShowInitialSubjectsStrategy : IShowSubjectsPageViewStrategy
    {
        public void SetShowSubjectsPageView(DataGrid subjectsDataGrid, Button removeButton, Button chooseButton)
        {
            subjectsDataGrid.SelectionMode = DataGridSelectionMode.Single;
            removeButton.Visibility = Visibility.Visible;
            chooseButton.Visibility = Visibility.Hidden;
        }
    }
}