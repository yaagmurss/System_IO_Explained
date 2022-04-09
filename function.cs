using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace System_IO_Explained
{
    class function
    {
        public void BinaryReaderandBinaryWriterClass()
        {

            //Reads primitive data types as binary values in a specific encoding

            /*
             BinaryReader            BinaryWriter               DataType

             Read                    Write(byte[],int,int)      Buffer of types
             ReadBoolean             Write(boolean)             Boolean
             ReadByte                Write(byte)                Byte
             ReadBytes               Write(byte[])              Byte array
             ReadByte                Write(byte)                Byte
            ...
             ReadString              Write(string)              String
            
             */



            //Create some arbitary variables about me in order to read and write in a file
            string name = "Yagmur";
            int age = 24;
            double height = 1.75;
            bool single = true;
            char gender = 'F';

            string fileName = @"C:\Users\200741\Desktop\BinaryTxt.txt";
           
            using (var stream = File.Open(fileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(name);
                    writer.Write(age);
                    writer.Write(height);
                    writer.Write(single);
                    writer.Write(gender);
                }
            }
            
            using (var stream = File.Open(fileName, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    name = reader.ReadString();
                    age = reader.ReadInt32();
                    height = reader.ReadDouble();
                    single = reader.ReadBoolean();
                    gender = reader.ReadChar();
                }
            }


            Console.WriteLine("My name is : " + name);
            Console.WriteLine("My age is : " + age);
            Console.WriteLine("My height is : " + height);
            Console.WriteLine("Am i single ? " + single);
            Console.WriteLine("My gender is" + gender);





        }

        public void BufferedStreamClass()
        {
            /* 
             
             Adds a buffering layer to read and write operations on another stream. This class cannot be inherited.
             
             buffered stream  vs normmal stream için süre tutp kodu karsılştır

             Hangisi daha makul anlamış olurum!!!
                          
             */

        }

        public void DirectoryClass()
        {
            //Exposes static methods for creating, moving, and enumerating through directories and subdirectories.

            string sourceDirectory = @"C:\Users\200741\Desktop\SourceDirectory";
            string archiveDirectory = @"C:\Users\200741\Desktop\ArchiveDirectory";
            try
            {

                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
                //Creates FileSystemEnumerable contains paths only ends with .txt
                //EnumerateFiles method to retrieve a collection of text files from a directory


                foreach (string currentFile in txtFiles)
                {
                    string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                    //Source DirectoryLengt is 39 +1 for "/" when you remove first 40 charcter then you get the fileName

                    Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
                    //Directory move(source destination as string, arcihieve destiinitaion as string)
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Console.WriteLine(txtFiles.GetType());
            //System.IO.Enumeration.FileSystemEnumerable`1[System.String]


            /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/


            string archivedDirectory = @"C:\Users\200741\Desktop\ArchiveDirectory";

            // Finds all the file that contains "DİPNOT" in a spesific directory

            var files = from retrievedFile in Directory.EnumerateFiles(archivedDirectory, "*.txt", SearchOption.AllDirectories)
                        
                        from line in File.ReadLines(retrievedFile)
                        where line.Contains("DİPNOT")
                        select new
                        {
                            File = retrievedFile,
                            Line = line
                        };

            foreach (var f in files)
            {
                Console.WriteLine("{0} contains {1}", f.File, f.Line);
            }
            Console.WriteLine("{0} lines found.", files.Count().ToString());

            /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

            //The following example demonstrates how to move a directory and all its files to a new directory.
            //The original directory no longer exists after it has been moved.


            try
            {
                Directory.Move(sourceDirectory, archiveDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/


            /*Use the Directory class for copying, moving, renaming, creating, and deleting directories.

            CreateDirectory methods.

            Delete methods.

            GetCurrentDirectory or SetCurrentDirectory method.
            
            SetLastAccessTime and SetCreationTime.

            DirectoryInfo

            CreateDirectory(String)	
Creates all directories and subdirectories in the specified path unless they already exist.

Delete(String)	
Deletes an empty directory from a specified path.

Delete(String, Boolean)	
Deletes the specified directory and, if indicated, any subdirectories and files in the directory.

EnumerateDirectories(String)	
Returns an enumerable collection of directory full names in a specified path.

EnumerateDirectories(String, String)	
Returns an enumerable collection of directory full names that match a search pattern in a specified path.

EnumerateDirectories(String, String, EnumerationOptions)	
Returns an enumerable collection of the directory full names that match a search pattern in a specified path, and optionally searches subdirectories.

EnumerateDirectories(String, String, SearchOption)	
Returns an enumerable collection of directory full names that match a search pattern in a specified path, and optionally searches subdirectories.

EnumerateFiles(String)	
Returns an enumerable collection of full file names in a specified path.

EnumerateFiles(String, String)	
Returns an enumerable collection of full file names that match a search pattern in a specified path.

EnumerateFiles(String, String, EnumerationOptions)	
Returns an enumerable collection of full file names that match a search pattern and enumeration options in a specified path, and optionally searches subdirectories.

EnumerateFiles(String, String, SearchOption)	
Returns an enumerable collection of full file names that match a search pattern in a specified path, and optionally searches subdirectories.

EnumerateFileSystemEntries(String)	
Returns an enumerable collection of file names and directory names in a specified path.

EnumerateFileSystemEntries(String, String)	
Returns an enumerable collection of file names and directory names that match a search pattern in a specified path.

EnumerateFileSystemEntries(String, String, EnumerationOptions)	
Returns an enumerable collection of file names and directory names that match a search pattern and enumeration options in a specified path.

EnumerateFileSystemEntries(String, String, SearchOption)	
Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.

Exists(String)	
Determines whether the given path refers to an existing directory on disk.

GetCreationTime(String)	
Gets the creation date and time of a directory.

GetCreationTimeUtc(String)	
Gets the creation date and time, in Coordinated Universal Time (UTC) format, of a directory.

GetCurrentDirectory()	
Gets the current working directory of the application.

GetDirectories(String)	
Returns the names of subdirectories (including their paths) in the specified directory.

GetDirectories(String, String)	
Returns the names of subdirectories (including their paths) that match the specified search pattern in the specified directory.

GetDirectories(String, String, EnumerationOptions)	
Returns the names of subdirectories (including their paths) that match the specified search pattern and enumeration options in the specified directory.

GetDirectories(String, String, SearchOption)	
Returns the names of the subdirectories (including their paths) that match the specified search pattern in the specified directory, and optionally searches subdirectories.

GetDirectoryRoot(String)	
Returns the volume information, root information, or both for the specified path.

GetFiles(String)	
Returns the names of files (including their paths) in the specified directory.

GetFiles(String, String)	
Returns the names of files (including their paths) that match the specified search pattern in the specified directory.

GetFiles(String, String, EnumerationOptions)	
Returns the names of files (including their paths) that match the specified search pattern and enumeration options in the specified directory.

GetFiles(String, String, SearchOption)	
Returns the names of files (including their paths) that match the specified search pattern in the specified directory, using a value to determine whether to search subdirectories.

GetFileSystemEntries(String)	
Returns the names of all files and subdirectories in a specified path.

GetFileSystemEntries(String, String)	
Returns an array of file names and directory names that match a search pattern in a specified path.

GetFileSystemEntries(String, String, EnumerationOptions)	
Returns an array of file names and directory names that match a search pattern and enumeration options in a specified path.

GetFileSystemEntries(String, String, SearchOption)	
Returns an array of all the file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.

GetLastAccessTime(String)	
Returns the date and time the specified file or directory was last accessed.

GetLastAccessTimeUtc(String)	
Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.

GetLastWriteTime(String)	
Returns the date and time the specified file or directory was last written to.

GetLastWriteTimeUtc(String)	
Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last written to.

GetLogicalDrives()	
Retrieves the names of the logical drives on this computer in the form "<drive letter>:\".

GetParent(String)	
Retrieves the parent directory of the specified path, including both absolute and relative paths.

Move(String, String)	
Moves a file or a directory and its contents to a new location.

SetCreationTime(String, DateTime)	
Sets the creation date and time for the specified file or directory.

SetCreationTimeUtc(String, DateTime)	
Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.

SetCurrentDirectory(String)	
Sets the application's current working directory to the specified directory.

SetLastAccessTime(String, DateTime)	
Sets the date and time the specified file or directory was last accessed.

SetLastAccessTimeUtc(String, DateTime)	
Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.

SetLastWriteTime(String, DateTime)	
Sets the date and time a directory was last written to.

SetLastWriteTimeUtc(String, DateTime)	
Sets the date and time, in Coordinated Universal Time (UTC) format, that a directory was last written to.
            
             */





        }
    }

    
    
}
