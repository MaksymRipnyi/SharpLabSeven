using SharpLabFour.Models.Subjects;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpLabFour.Models.Students
{
    public class SubjectOfStudent : INotifyPropertyChanged
    {
        private int itsId;
        private Subject itsSubject;
        private double itsGrade;
        private event Action<SubjectOfStudent> itsSubjectOfStudentUpdatedEvent;

        public int Id { get { return itsId; } set { itsId = value; } }
        public Subject Subject 
        { 
            get { return itsSubject; } 
            set 
            { 
                itsSubject = value;
                if (itsSubjectOfStudentUpdatedEvent != null)
                    itsSubjectOfStudentUpdatedEvent(this);
            } 
        }
        public double Grade 
        { 
            get { return itsGrade; } 
            set 
            { 
                itsGrade = value; 
                OnPropertyChanged("Grade");
                if (itsSubjectOfStudentUpdatedEvent != null)
                    itsSubjectOfStudentUpdatedEvent(this);
            } 
        }
        public event Action<SubjectOfStudent> SubjectOfStudentUpdatedEvent
        {
            add { itsSubjectOfStudentUpdatedEvent += value; }
            remove { itsSubjectOfStudentUpdatedEvent -= value; }
        }

        public SubjectOfStudent()
        {
            itsSubject = new Subject();
            itsGrade = 0.0;
        }
        public SubjectOfStudent(Subject subject, double grade = 0.0)
        {
            itsSubject = subject;
            itsGrade = grade;
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