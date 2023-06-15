using System.Windows;
using System.Windows.Controls;

namespace SharpLabFour.Strategies.ShowSubjectsPageViewStrategies
{
    public interface IShowSubjectsPageViewStrategy
    {
        void SetShowSubjectsPageView(DataGrid subjectsDataGrid, Button removeButton, Button chooseButton);
    }
}