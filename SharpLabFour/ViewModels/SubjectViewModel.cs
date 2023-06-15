using SharpLabFour.Database;
using SharpLabFour.Models.Subjects;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpLabFour.ViewModels
{
    public class SubjectViewModel : INotifyPropertyChanged
    {
        private event Action<Subject> itsSubjectRemovedEvent;
        private event Action<Subject> itsAddSubjectToDatabaseEvent;
        private event Action<Subject> itsRemoveSubjectFromDatabaseEvent;
        private event Action<Subject> itsUpdateSubjectInDatabaseEvent;
        public ObservableCollection<Subject> Subjects { get; set; }

        public SubjectViewModel(ObservableCollection<Subject> subjects, DbUniversityContext dbUniversityContext)
        {
            Subjects = subjects;
            itsAddSubjectToDatabaseEvent += dbUniversityContext.AddSubject;
        }
        public SubjectViewModel(StudentViewModel studentViewModel)
        {
            Subjects = new ObservableCollection<Subject>();
            itsSubjectRemovedEvent += studentViewModel.RemoveSubjectFromAllStudents;
        }
        public SubjectViewModel(StudentViewModel studentViewModel, DbUniversityContext dbUniversityContext)
        {
            Subjects = new ObservableCollection<Subject>(dbUniversityContext.Subjects);
            SetUpdateEvents();
            itsSubjectRemovedEvent += studentViewModel.RemoveSubjectFromAllStudents;
            itsAddSubjectToDatabaseEvent += dbUniversityContext.AddSubject;
            itsRemoveSubjectFromDatabaseEvent += dbUniversityContext.RemoveSubject;
            itsUpdateSubjectInDatabaseEvent += dbUniversityContext.UpdateSubject;
        }
        private void SetUpdateEvents()
        {
            foreach (Subject subject in Subjects)
                subject.SubjectUpdatedEvent += OnUpdateSubject;
        }
        public void AddSubject(Subject subject)
        {
            subject.SubjectUpdatedEvent += OnUpdateSubject;
            Subjects.Add(subject);
            itsAddSubjectToDatabaseEvent(subject);
        }
        public void RemoveSubject(Subject subject)
        {
            Subjects.Remove(subject);
            itsSubjectRemovedEvent(subject);
            itsRemoveSubjectFromDatabaseEvent(subject);
        }
        public void OnUpdateSubject(Subject subject) // called from an element that has just been updated
        {
            itsUpdateSubjectInDatabaseEvent(subject);
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