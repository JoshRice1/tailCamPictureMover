using System;
using System.Collections.Generic;
using System.IO;

namespace TrailCamPicManager
{
    class Program
    {
        

        static void Main(string[] args)
        {

            RemovableDriveProcessor removableDriveProcessor = new RemovableDriveProcessor();
            removableDriveProcessor.processAllDrives();
            Console.WriteLine("Hello World!");

        }

        
    }
}
