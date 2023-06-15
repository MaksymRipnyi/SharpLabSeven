using SharpLabFour.Models.Subjects;
using SharpLabFour.Notification;
using System.Collections.Generic;

namespace SharpLabFour.Validators
{
    public static class SubjectValidator
    {
        public static List<INotification> CheckSubject(string subjectName, List<Subject> subjects)
        {
            List<INotification> notifications = new List<INotification>();
            if (NameValidator.CheckName(subjectName) is not None)
                notifications.Add(new EmptySubjectName());
            if (SuchSubjectExists(subjectName, subjects))
                notifications.Add(new SuchSubjectExists());
            return notifications;
        }
        private static bool SuchSubjectExists(string subjectName, List<Subject> subjects)
        {
            return subjects.Exists(s => s.Name == subjectName);
        }
    }
}