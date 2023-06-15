using SharpLabFour.Models.Students;
using SharpLabFour.Notification;
using SharpLabFour.Strategies.ShowSubjectsPageViewStrategies;
using SharpLabFour.UIHandlers.TextBoxes;
using SharpLabFour.Validators;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SharpLabFour.DataFramePages
{
    /// <summary>
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        private MainWindow itsContent;
        private Student itsStudent;
        public AddStudentPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;
            itsStudent = new Student();
        }

        private void AddSubjects_Click(object sender, RoutedEventArgs e)
        {
            itsContent.dataFrame.Content = new ShowSubjectsPage(itsContent, new AddSubjectsToStudentStrategy()
                , itsContent.subjectViewModel, itsStudent);
        }
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            List<INotification> notifications = StudentValidator.CheckStudent(studentFirstNameTextBox.Text, studentLastNameTextBox.Text);
            if (notifications.Count == 0)
            {
                itsStudent.FirstName = studentFirstNameTextBox.Text;
                itsStudent.LastName = studentLastNameTextBox.Text;
                itsContent.studentViewModel.AddStudent(itsStudent);
                TextBoxCleaner.CleanTextBoxes(studentFirstNameTextBox, studentLastNameTextBox);
                NotificationView.ShowNotification(notificationStackPanel, notificationTextBlock, new StudentAdded());
            }
            else
                NotificationView.ShowNotifications(notificationStackPanel, notificationTextBlock, notifications);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationView.HideNotifications(notificationStackPanel);
        }
    }
}