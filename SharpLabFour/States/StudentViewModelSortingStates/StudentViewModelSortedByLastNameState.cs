using SharpLabFour.Models.Students;
using System.Collections.ObjectModel;

namespace SharpLabFour.States.StudentViewModelSortingStates
{
    public class StudentViewModelSortedByLastNameState : IStudentViewModelSortingState
    {
        private ObservableCollection<Student> itsNotSortedStudents;

        public StudentViewModelSortedByLastNameState(ObservableCollection<Student> notSortedStudents)
        {
            itsNotSortedStudents = notSortedStudents;
        }

        public void SortByLastName(ref ObservableCollection<Student> students
            , ref IStudentViewModelSortingState studentViewModelSortingState)
        {
            students = itsNotSortedStudents;
            studentViewModelSortingState = new StudentViewModelNotSortedByLastNameState();
        }
    }
}