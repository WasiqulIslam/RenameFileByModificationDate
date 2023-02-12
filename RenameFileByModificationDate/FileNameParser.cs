using System;
using System.Linq;

//Developing by Wasiqul Islam at 27th June, 2015

namespace RenameFileByModificationDate
{
    public class FileNameParser
    {
        private readonly string fileName;

        public FileNameParser(string fileName)
        {
            this.fileName = fileName;
        }

        public string GetFileExtension()
        {
            var extension = "";
            int lastIndexOfDot = fileName.LastIndexOf(".");
            if (lastIndexOfDot != -1)
            {
                extension = fileName.Substring(lastIndexOfDot+1);
            }
            return extension.ToLower();
        }
    }
}
