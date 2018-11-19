using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TrailCamPicManager
{

    

    class RemovableDriveProcessor
    {
        List<DriveInfo> removableDrives;

        public RemovableDriveProcessor()
        {
            getRemovableDrives();

        }

        public void getRemovableDrives()
        {
            var driveList = DriveInfo.GetDrives();

            foreach (DriveInfo drive in driveList)
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    removableDrives.Add(drive);
                }
            }
        }

        public void processAllDrives()
        {
            if (removableDrives != null)
            {
                foreach (DriveInfo drive in removableDrives)
                {
                    processDrive(drive);
                }
            }
            else
            {
                Console.WriteLine("No removable drives to process");
            }
        }

        public void processDrive (DriveInfo drive)
        {
            List<FileInfo> jpgs = recursiveGetJPGs(drive.RootDirectory);
            foreach(FileInfo file in jpgs)
            {
                Console.WriteLine(file.FullName);
            }
        }

        public List<FileInfo> recursiveGetJPGs(DirectoryInfo directory)
        {
            List<FileInfo> toReturn = new List<FileInfo>();
            //get the jpg in the directory
            toReturn.AddRange(loadDirectoryJPGFiles(directory));
            //loop through all child directories and call this method to get
            //jpg in that directory and process children
            foreach(DirectoryInfo childDirectory in directory.GetDirectories())
            {
                toReturn.AddRange(recursiveGetJPGs(childDirectory));
            }
            return toReturn;
        }

        public List<FileInfo> loadDirectoryJPGFiles(DirectoryInfo directory)
        {
            List<FileInfo> toReturn = new List<FileInfo>(); ;
            foreach(FileInfo file in directory.GetFiles("*.jpg"))
            {
                toReturn.Add(file);
            }
                        
            return toReturn;
        }
    }

   
}
