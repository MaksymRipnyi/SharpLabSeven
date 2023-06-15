using SharpLabFour.Models.Students;
using System.Collections.ObjectModel;

namespace SharpLabFour.States.StudentViewModelSortingStates
{
    public interface IStudentViewModelSortingState
    {
        void SortByLastName(ref ObservableCollection<Student> students, ref IStudentViewModelSortingState studentViewModelSortingState);
    }
}