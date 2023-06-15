using SharpLabFour.Models.Subjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharpLabFour.Converters.SubjectConverters
{
    public static class SubjectConverter
    {
        public static List<string> SubjectsToStrings(ObservableCollection<Subject> subjects)
        {
            List<string> subjectsNames = new List<string>();
            foreach (Subject subject in subjects)
                subjectsNames.Add(subject.Name);
            return subjectsNames;
        }
    }
}