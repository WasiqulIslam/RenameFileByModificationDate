using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenameFileByModificationDate;

//Developing by Wasiqul Islam at 27th June, 2015

namespace RenameFileByModificationDateTest
{
    [TestClass]
    public class FileNameParserTest
    {

        [TestMethod]
        public void GetFileExtensionTestBasic()
        {
            string fileName = "C:/images/abc.PNG";
            var parser = new FileNameParser(fileName);
            var expected = "png";

            var actual = parser.GetFileExtension();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionTestForNoExtension()
        {
            string fileName = "C:/abc";
            var parser = new FileNameParser(fileName);
            var expected = "";

            var actual = parser.GetFileExtension();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileExtensionTestForMultipleExtensions()
        {
            string fileName = "D:/invalid images/abc.png.jpeg";
            var parser = new FileNameParser(fileName);
            var expected = "jpeg";

            var actual = parser.GetFileExtension();

            Assert.AreEqual(expected, actual);
        }

    }
}
