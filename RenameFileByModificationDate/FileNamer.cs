using System;
using System.Linq;

//Developing by Wasiqul Islam at 27th June, 2015

namespace RenameFileByModificationDate
{
    public class FileNamer
    {

        private readonly Random random;

        public FileNamer(Random random )
        {
            this.random = random;
        }

        public string GetSuggestedFileName(DateTime lastModificatonDate)
        {
            string fileName = lastModificatonDate.ToString("yyyy-MM-dd ") + random.Next(100000000, 999999999);
            return fileName;
        }

    }
}
