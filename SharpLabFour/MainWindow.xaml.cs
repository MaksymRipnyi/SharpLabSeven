using SharpLabFour.Database;
using SharpLabFour.DataFramePages;
using SharpLabFour.Directories;
using SharpLabFour.Strategies.ShowSubjectsPageViewStrategies;
using SharpLabFour.ViewModels;
using System;
using System.Windows;

namespace SharpLabFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string initialLocation;
        static MainWindow()
        {
            initialLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            initialLocation = System.IO.Path.GetDirectoryName(initialLocation);

            DirectoryChecker.CreateDeletedDirectories();
        }

        public DbUniversityContext dbUniversityContext;
        public StudentViewModel studentViewModel;
        public SubjectViewModel subjectViewModel;
        public MainWindow()
        {
            InitializeComponent();

            dbUniversityContext = new DbUniversityContext();
            studentViewModel = new StudentViewModel(dbUniversityContext);
            subjectViewModel = new SubjectViewModel(studentViewModel, dbUniversityContext);
            //studentViewModel = new StudentViewModel();
            //subjectViewModel = new SubjectViewModel(studentViewModel);
        }
        private void MainWindow_Loaded(object sender, EventArgs e)
        {
        }

        private void AddSubject_Click(object sender, RoutedEventArgs e)
        {
            dataFrame.Content = new AddSubjectPage(this);
        }
        private void ShowSubjects_Click(object sender, RoutedEventArgs e)
        {
            dataFrame.Content = new ShowSubjectsPage(this, new ShowInitialSubjectsStrategy(), subjectViewModel);
        }
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            dataFrame.Content = new AddStudentPage(this);
        }
        private void ShowStudents_Click(object sender, RoutedEventArgs e)
        {
            dataFrame.Content = new ShowStudentsPage(this);
        }
        private void StudentsBySubject_Click(object sender, RoutedEventArgs e)
        {
            dataFrame.Content = new ShowStudentsBySubjectPage(this);
        }

        private void MainWindow_Closing(object sender, EventArgs e)
        {
        }
    }
}