using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

//Developing by Wasiqul Islam at 27th June, 2015

namespace RenameFileByModificationDate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private FileNamer fileNamer = null;
        private string helpText;
        private string applicationNameWithVersion = "Rename File By Modification Date v1.0.0.1";

        public MainWindow()
        {
            InitializeComponent();

            helpText = "" + applicationNameWithVersion + @"
This application helps you to rename any file according to the last modification date of that file. You can also select multiple files and rename all at once. This application is applicable for the following scenario: Suppose that, you want to keep all photos taken in different time in a single folder but you cannot do it because many photos have same name. In this case this is a solution to rename the files to keep them in a single folder. This program helps you to rename all your photos and any other types of file.
Developed by: Wasiqul Islam
Email: islam.wasiqul@gmail.com";

            wdoMain.Title = applicationNameWithVersion;
        }

        private void BtnRenameClick(object sender, RoutedEventArgs e)
        {
            try
            {

                FileSelector fileSelector = new FileSelector();
                string[] fileNamesWithPath = fileSelector.GetFileNames();
                if (fileNamesWithPath == null)
                {
                    return;
                }

                StringBuilder errorList = new StringBuilder();
                foreach (string fileNameWithPath in fileNamesWithPath)
                {
                    try
                    {
                        RenameSingleFile(fileNameWithPath);
                    }
                    catch( Exception exceptionsInsideLoop )
                    {
                        errorList.Append(exceptionsInsideLoop.Message + Environment.NewLine);
                    }
                }

                if( !String.IsNullOrWhiteSpace(errorList.ToString() ))
                {
                    throw new Exception(  errorList.ToString() );
                }

                txtResult.Text = "Renamed successfully.";

            }
            catch(Exception exception)
            {
                txtResult.Text = "One or more errors have occured: " + Environment.NewLine + exception.Message;
            }
        }

        private void RenameSingleFile(string fileNameWithPath)
        {
            FileNameParser parser;
            parser = new FileNameParser(fileNameWithPath);
            var extension = parser.GetFileExtension();

            string parentDirectory = Directory.GetParent(fileNameWithPath).FullName;
            string newName = GetNewFileName(fileNameWithPath);

            CheckIfRenamedEarlier(fileNameWithPath, newName);

            string newFileNameWithPath = GetFileNameWithPath(parentDirectory, newName, extension);

            if (!File.Exists(newFileNameWithPath))
            {
                File.Move(fileNameWithPath, newFileNameWithPath);
            }
            else
            {
                throw new Exception(String.Format("This file cannot be renamed at this time, please try again later: {0}.", fileNameWithPath));
            }
        }

        private void CheckIfRenamedEarlier(string fileNameWithPath, string newName)
        {
            if (fileNameWithPath.Contains(newName.Substring(0, 10)))
            {
                throw new Exception("This file is not renamed because probably it was renamed earlier: " + fileNameWithPath);
            }
        }

        private string GetFileNameWithPath(string parentDirectory, string newName, string extension)
        {
            return System.IO.Path.Combine(parentDirectory,
                (newName + (String.IsNullOrWhiteSpace(extension) ? "" : "." + extension)));
        }

        private string GetNewFileName(string fileNameWithPath)
        {
            if (fileNamer == null)
            {
                var random = new Random();
                fileNamer = new FileNamer(random);
            }

            DateTime lastModificatonDate = File.GetLastWriteTime(fileNameWithPath);
            string newName = fileNamer.GetSuggestedFileName(lastModificatonDate);
            return newName;
        }

        private void LblHelpAboutMouseUp(object sender, MouseButtonEventArgs e)
        {
            txtResult.Text = helpText;
        }     
        
    }
}
