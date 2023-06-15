using SharpLabFour.Models.Students;
using System.Collections.ObjectModel;
using System.Linq;

namespace SharpLabFour.States.StudentViewModelSortingStates
{
    public class StudentViewModelNotSortedByLastNameState : IStudentViewModelSortingState
    {
        private ObservableCollection<Student> itsNotSortedStudents;

        public void SortByLastName(ref ObservableCollection<Student> students
            , ref IStudentViewModelSortingState studentViewModelSortingState)
        {
            itsNotSortedStudents = students;
            students = ToObservableStudentCollection(students.OrderBy(s => s.LastName));
            studentViewModelSortingState = new StudentViewModelSortedByLastNameState(itsNotSortedStudents);
        }
        private ObservableCollection<Student> ToObservableStudentCollection(IOrderedEnumerable<Student> orderedEnumerable)
        {
            ObservableCollection<Student> orderedStudents = new ObservableCollection<Student>();
            foreach (Student student in orderedEnumerable)
                orderedStudents.Add(student);
            return orderedStudents;
        }
        private void MakeBackUp(ObservableCollection<Student> students)
        {
            itsNotSortedStudents = new ObservableCollection<Student>();
            foreach (Student student in students)
                itsNotSortedStudents.Add(student);
        }
    }
}