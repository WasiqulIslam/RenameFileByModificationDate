using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenameFileByModificationDate;

//Developing by Wasiqul Islam at 27th June, 2015

namespace RenameFileByModificationDateTest
{
    [TestClass]
    public class FileNamerTest
    {

        [TestMethod]
        public void GetSuggestedFileNameTestBasic()
        {
            Random random = new Random(1024);
            DateTime dateTime = new DateTime(2000, 12, 26);
            FileNamer fileNamer = new FileNamer(random);
            string expected = "2000-12-26 720788498";

            string actual = fileNamer.GetSuggestedFileName(dateTime);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSuggestedFileNameTestWithDifferentDate()
        {
            Random random = new Random(1024);
            DateTime dateTime = new DateTime(2015, 1, 1);
            FileNamer fileNamer = new FileNamer(random);
            string expected = "2015-01-01 720788498";

            string actual = fileNamer.GetSuggestedFileName(dateTime);

            Assert.AreEqual(expected, actual);
        }

    }
}
