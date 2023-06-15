using SharpLabFour.Models.Subjects;
using SharpLabFour.Notification;
using SharpLabFour.UIHandlers.TextBoxes;
using SharpLabFour.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SharpLabFour.DataFramePages
{
    /// <summary>
    /// Interaction logic for AddSubjectPage.xaml
    /// </summary>
    public partial class AddSubjectPage : Page
    {
        private MainWindow itsContent;
        public AddSubjectPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            List<INotification> notifications = SubjectValidator.CheckSubject(subjectNameTextBox.Text
                , itsContent.subjectViewModel.Subjects.ToList());
            if (notifications.Count == 0)
            {
                itsContent.subjectViewModel.AddSubject(new Subject(subjectNameTextBox.Text));
                TextBoxCleaner.CleanTextBox(subjectNameTextBox);
                NotificationView.ShowNotification(notificationStackPanel, notificationTextBlock, new SubjectAdded());
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