
namespace SharpLabFour.Notification
{
    public class RecordNotChosen : INotification
    {
        public string Text { get; set; }

        public RecordNotChosen() { Text = "RECORD HASN'T BEEN CHOSEN!"; }
    }
    public class EmptySubjectName : INotification
    {
        public string Text { get; set; }

        public EmptySubjectName() { Text = "SUBJECT'S NAME IS EMPTY!"; }
    }
    public class SuchSubjectExists : INotification
    {
        public string Text { get; set; }

        public SuchSubjectExists() { Text = "SUCH SUBJECT ALREADY EXISTS!"; }
    }
    public class EmptyStudentFirstName : INotification
    {
        public string Text { get; set; }

        public EmptyStudentFirstName() { Text = "STUDENT'S FIRST NAME IS EMPTY!"; }
    }
    public class EmptyStudentLastName : INotification
    {
        public string Text { get; set; }

        public EmptyStudentLastName() { Text = "STUDENT'S LAST NAME IS EMPTY!"; }
    }
    public class SubjectLimitForStudentExceeded : INotification
    {
        public string Text { get; set; }

        public SubjectLimitForStudentExceeded() { Text = "SOME SUBJECTS HAVEN'T BEEN ADDED DUE TO LIMIT (35 MAX)!"; }
    }
    public class None : INotification
    {
        public string Text { get; set; }

        public None() { Text = "NONE"; }
    }
}