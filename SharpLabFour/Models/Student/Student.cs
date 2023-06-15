using SharpLabFour.Models.Subjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharpLabFour.Models.Students
{
    public class Student : INotifyPropertyChanged
    {
        private int itsId;
        private string itsFirstName;
        private string itsLastName;
        private ObservableCollection<SubjectOfStudent> itsSubjectsAndGrades;
        private event Action<Student> itsStudentUpdatedEvent;
        private event Action<SubjectOfStudent> itsSubjectOfStudentRemovedEvent;

        public int Id { get { return itsId; } set { itsId = value; } }
        public string FirstName
        {
            get { return itsFirstName; }
            set 
            { 
                itsFirstName = value; 
                OnPropertyChanged("FirstName"); 
                if (itsStudentUpdatedEvent != null)
                    itsStudentUpdatedEvent(this); 
            }
        }
        public string LastName
        {
            get { return itsLastName; }
            set 
            { 
                itsLastName = value; 
                OnPropertyChanged("LastName");
                if (itsStudentUpdatedEvent != null)
                    itsStudentUpdatedEvent(this); 
            }
        }
        public ObservableCollection<SubjectOfStudent> SubjectsAndGrades 
        { 
            get { return itsSubjectsAndGrades; } 
            set 
            { 
                itsSubjectsAndGrades = value;
                if (itsStudentUpdatedEvent != null)
                    itsStudentUpdatedEvent(this);
            } 
        }
        public event Action<Student> StudentUpdatedEvent 
        {
            add { itsStudentUpdatedEvent += value; }
            remove { itsStudentUpdatedEvent -= value; }
        }
        public event Action<SubjectOfStudent> SubjectOfStudentRemovedEvent
        {
            add { itsSubjectOfStudentRemovedEvent += value; }
            remove { itsSubjectOfStudentRemovedEvent -= value; }
        }

        public Student() : this(string.Empty, string.Empty, new ObservableCollection<SubjectOfStudent>()) {}
        public Student(string firstName, string lastName)
        {
            itsFirstName = firstName;
            itsLastName = lastName;
            itsSubjectsAndGrades = new ObservableCollection<SubjectOfStudent>();
        }
        public Student(string firstName, string lastName, ObservableCollection<SubjectOfStudent> subjectsAndGrades)
        {
            itsFirstName = firstName;
            itsLastName = lastName;
            itsSubjectsAndGrades = subjectsAndGrades;
            itsSubjectsAndGrades.CollectionChanged += ItsSubjectsAndGrades_CollectionChanged;
        }

        private void ItsSubjectsAndGrades_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                itsSubjectOfStudentRemovedEvent((SubjectOfStudent)e.OldItems[0]);
            }
        }

        public void SetUpdateEvents()
        {
            foreach (SubjectOfStudent subjectOfStudent in itsSubjectsAndGrades)
                subjectOfStudent.SubjectOfStudentUpdatedEvent += OnUpdateSubjectAndGrades;
        }
        public void AddSubject(Subject subject)
        {
            itsSubjectsAndGrades.Add(new SubjectOfStudent(subject));
            itsStudentUpdatedEvent(this);
        }
        public bool AddSubjectRange(List<Subject> subjects)
        {
            bool allSubjectsAdded = true;
            foreach (Subject subject in subjects)
            {
                if (itsSubjectsAndGrades.Count < 35)
                {
                    SubjectOfStudent subjectOfStudent = new SubjectOfStudent(subject);
                    subjectOfStudent.SubjectOfStudentUpdatedEvent += OnUpdateSubjectAndGrades;
                    itsSubjectsAndGrades.Add(subjectOfStudent);
                }
                else
                {
                    allSubjectsAdded = false;
                    break;
                }
            }
            if (itsStudentUpdatedEvent != null)
                itsStudentUpdatedEvent(this);
            return allSubjectsAdded;
        }
        public void RemoveSubject(SubjectOfStudent subjectOfStudent)
        {
            itsSubjectsAndGrades.Remove(subjectOfStudent);
            itsStudentUpdatedEvent(this);
            itsSubjectOfStudentRemovedEvent(subjectOfStudent);
        }
        public void RemoveSubject(Subject subject) // called from StudentViewModel when an initial subject is deleted
        {
            itsSubjectsAndGrades.Remove(itsSubjectsAndGrades.Where(sg => sg.Subject == subject).FirstOrDefault());
            itsStudentUpdatedEvent(this);
        }
        public void OnUpdateSubjectAndGrades(SubjectOfStudent subjectOfStudent)
        {
            itsStudentUpdatedEvent(this);
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