using SharpLabFour.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpLabFour.Models.Subjects
{
    public class Subject : INotifyPropertyChanged
    {
        private int itsId;
        private string itsName;
        private event Action<Subject> itsSubjectUpdatedEvent;

        public int Id { get { return itsId; } set { itsId = value; } }
        public string Name 
        { 
            get { return itsName; } 
            set 
            { 
                itsName = value; 
                OnPropertyChanged("Name"); 
                if (itsSubjectUpdatedEvent != null)
                    itsSubjectUpdatedEvent(this); 
            } 
        }
        public event Action<Subject> SubjectUpdatedEvent 
        { 
            add { itsSubjectUpdatedEvent += value; }
            remove { itsSubjectUpdatedEvent -= value; }
        }

        public Subject()
        {
            itsName = string.Empty;
        }
        public Subject(string name)
        {
            itsName = name;
        }
        public Subject(string name, SubjectViewModel subjectViewModel) : this(name)
        {
            itsSubjectUpdatedEvent += subjectViewModel.OnUpdateSubject;
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