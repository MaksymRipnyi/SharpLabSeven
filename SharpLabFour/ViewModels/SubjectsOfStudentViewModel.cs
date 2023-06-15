using SharpLabFour.Models.Students;
using SharpLabFour.Models.Subjects;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SharpLabFour.ViewModels
{
    public class SubjectsOfStudentViewModel : INotifyPropertyChanged
    {
        private Student itsStudent;
        public ObservableCollection<SubjectOfStudent> Subjects { get { return itsStudent.SubjectsAndGrades; } set { itsStudent.SubjectsAndGrades = value; } }

        public SubjectsOfStudentViewModel(Student student)
        {
            itsStudent = student;
        }
        public void RemoveSubject(SubjectOfStudent subjectOfStudent)
        {
            itsStudent.RemoveSubject(subjectOfStudent);
        }
        public ObservableCollection<Subject> GetNotUsedSubjectsOfCurrentStudent(ObservableCollection<Subject> allSubjects)
        {
            ObservableCollection<Subject> notUsedSubjects = new ObservableCollection<Subject>();
            foreach (Subject subject in allSubjects)
            {
                if (Subjects.Where(sg => sg.Subject == subject).FirstOrDefault() == null) // There is no Exists method for this collection
                    notUsedSubjects.Add(subject);
            }
            return notUsedSubjects;
        }


        // MVVM events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}