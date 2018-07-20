using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GlobalLogic_Solution
{
    public class Folder
    {

        public string Name;

        public string DateCreated;

        public List<FileInfoSerializable> Files = new List<FileInfoSerializable>();

        public List<Folder> Children = new List<Folder>();

        public Folder()
        {

        }

        public Folder(DirectoryInfo directory)
        {
            if (!Directory.Exists(directory.FullName))
                return;
            this.Name = directory.Name;
            this.DateCreated = directory.CreationTime.ToString("dd-MMM-yy h:mm tt", 
                System.Globalization.CultureInfo.InvariantCulture);

            foreach (var file in directory.GetFiles("*.*"))
            {
                try
                {
                    var f = new FileInfoSerializable(file);
                    Files.Add(f);
                }
                catch(Exception ex) { }
            } 
            
            

            try
            {
                foreach (var dirInfo in directory.GetDirectories())
                {
                    Children.Add(new Folder(dirInfo));
                }
            }
            catch { }
        }
    }
}
