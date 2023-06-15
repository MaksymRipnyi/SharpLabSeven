using SharpLabFour.Models.Students;
using SharpLabFour.Models.Subjects;
using SharpLabFour.Notification;
using SharpLabFour.Strategies.ShowSubjectsPageViewStrategies;
using SharpLabFour.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SharpLabFour.DataFramePages
{
    /// <summary>
    /// Interaction logic for ShowSubjectsPage.xaml
    /// </summary>
    public partial class ShowSubjectsPage : Page
    {
        private MainWindow itsContent;
        private Student itsChosenStudent; // used if this page is called from ShowSubjectsOfStudentPage
        public ShowSubjectsPage(MainWindow content, IShowSubjectsPageViewStrategy showSubjectsPageViewStrategy
            , SubjectViewModel subjectViewModel, Student chosenStudent = null)
        {
            InitializeComponent();
            itsContent = content;
            showSubjectsPageViewStrategy.SetShowSubjectsPageView(subjectsDataGrid, removeButton, chooseButton);
            DataContext = subjectViewModel;
            itsChosenStudent = chosenStudent;
        }


        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (subjectsDataGrid.SelectedIndex == -1)
                NotificationView.ShowNotification(notificationStackPanel, notificationTextBlock, new RecordNotChosen());
            else
                itsContent.subjectViewModel.RemoveSubject((Subject)subjectsDataGrid.SelectedItem);
        }
        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            if (subjectsDataGrid.SelectedIndex == -1)
                NotificationView.ShowNotification(notificationStackPanel, notificationTextBlock, new RecordNotChosen());
            else
            {
                if (itsChosenStudent.AddSubjectRange(subjectsDataGrid.SelectedItems.Cast<Subject>().ToList()) == false)
                    NotificationView.ShowNotification(notificationStackPanel, notificationTextBlock, new SubjectLimitForStudentExceeded());
                else
                    itsContent.dataFrame.GoBack();
            }
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationView.HideNotifications(notificationStackPanel);
        }
    }
}