using SharpLabFour.Converters.SubjectConverters;
using System.Windows.Controls;

namespace SharpLabFour.DataFramePages
{
    /// <summary>
    /// Interaction logic for ShowStudentsBySubjectPage.xaml
    /// </summary>
    public partial class ShowStudentsBySubjectPage : Page
    {
        MainWindow itsContent;
        public ShowStudentsBySubjectPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;
            subjectsComboBox.ItemsSource = SubjectConverter.SubjectsToStrings(itsContent.subjectViewModel.Subjects);
        }

        private void SubjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            studentsAndGradesListView.ItemsSource =
                itsContent.studentViewModel.GetStudentsBySubjectName((string)subjectsComboBox.SelectedItem);
        }
    }
}