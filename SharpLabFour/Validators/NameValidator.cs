using SharpLabFour.Notification;
using System.Linq;

namespace SharpLabFour.Validators
{
    public static class NameValidator
    {
        public static INotification CheckName(string name)
        {
            if (name != string.Empty && name.Any(s => char.IsLetterOrDigit(s)))
                return new None();
            else
                return new EmptySubjectName();
        }
    }
}