using System.IO;

namespace SharpLabFour.Directories
{
    public static class DirectoryChecker
    {
        public static void CreateDeletedDirectories()
        {
            if (!Directory.Exists(MainWindow.initialLocation + "\\SaveFiles"))
                Directory.CreateDirectory(MainWindow.initialLocation + "\\SaveFiles");
        }
    }
}