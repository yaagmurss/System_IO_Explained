using System;
using System.IO;


namespace Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\200741\Desktop\Dosya\ymr\New folder");

            foreach (FileInfo fi in dir.GetFiles())
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception) { } // Ignore all exceptions
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                //System.IO.File.Delete(di.FullName);
                try
                {
                    di.Delete();
                }
                catch (Exception) { } // Ignore all exceptions
            }
        }
    }
}
