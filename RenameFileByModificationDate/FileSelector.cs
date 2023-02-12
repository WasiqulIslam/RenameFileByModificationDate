using Microsoft.Win32;
using System;
using System.Linq;

//Developing by Wasiqul Islam at 27th June, 2015

namespace RenameFileByModificationDate
{
    public class FileSelector
    {
        public string[] GetFileNames()
        {
            string[] fileNames = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files(*.*)|*.*";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Please select the files you want to rename";
            bool? isFileSelected = openFileDialog.ShowDialog();
            if (isFileSelected != null && isFileSelected == true)
            {
                fileNames = openFileDialog.FileNames;
            }
            return fileNames;
        }
    }
}
