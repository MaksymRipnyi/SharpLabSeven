using SharpLabFour.Models.Students;
using SharpLabFour.Notification;
using SharpLabFour.Strategies.ShowSubjectsPageViewStrategies;
using SharpLabFour.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SharpLabFour.DataFramePages
{
    /// <summary>
    /// Interaction logic for ShowSubjectsOfStudentPage.xaml
    /// </summary>
    public partial class ShowSubjectsOfStudentPage : Page
    {
        private MainWindow itsContent;
        private SubjectsOfStudentViewModel itsSubjectsOfStudentViewModel;
        private Student itsChosenStudent;
        public ShowSubjectsOfStudentPage(MainWindow content, Student chosenStudent)
        {
            InitializeComponent();
            itsContent = content;
            itsSubjectsOfStudentViewModel = new SubjectsOfStudentViewModel(chosenStudent);
            DataContext = itsSubjectsOfStudentViewModel;
            itsChosenStudent = chosenStudent;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            itsContent.dataFrame.Content = new ShowSubjectsPage(itsContent, new AddSubjectsToStudentStrategy()
                , new SubjectViewModel(itsSubjectsOfStudentViewModel.GetNotUsedSubjectsOfCurrentStudent(
                    itsContent.subjectViewModel.Subjects), itsContent.dbUniversityContext), itsChosenStudent);
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (subjectsOfStudentDataGrid.SelectedIndex == -1)
                NotificationView.ShowNotification(notificationStackPanel, notificationTextBlock, new RecordNotChosen());
            else
                itsSubjectsOfStudentViewModel.RemoveSubject((SubjectOfStudent)subjectsOfStudentDataGrid.SelectedItem);
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationView.HideNotifications(notificationStackPanel);
        }
    }
}