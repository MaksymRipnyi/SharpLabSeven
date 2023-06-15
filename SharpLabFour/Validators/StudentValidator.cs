using SharpLabFour.Notification;
using System.Collections.Generic;

namespace SharpLabFour.Validators
{
    public static class StudentValidator
    {
        public static List<INotification> CheckStudent(string firstName, string lastName)
        {
            List<INotification> notifications = new List<INotification>();
            if (NameValidator.CheckName(firstName) is not None)
                notifications.Add(new EmptyStudentFirstName());
            if (NameValidator.CheckName(lastName) is not None)
                notifications.Add(new EmptyStudentLastName());
            return notifications;
        }
    }
}