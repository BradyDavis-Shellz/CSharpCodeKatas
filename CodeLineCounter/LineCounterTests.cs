using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CodeLineCounter
{
    [TestFixture]
    class LineCounterTests
    {
        private LineCounter sut;

        private readonly string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
        private string elevenFile;
        private string fileWithSpaces;
        private string fileWithInlineComments;
        private string fileWithInlineCode;


        [SetUp]
        public void SetUp()
        {
            sut = new LineCounter();
            elevenFile = path + "/testFiles/FileWith11Lines.cs";
            fileWithSpaces = path + "/testFiles/FileWithSpaces.cs";
            fileWithInlineComments = path + "/testFiles/FileWithComments.cs";
            fileWithInlineCode = path + "/testFiles/FileWithInlineCode.cs";

        }

        [Test]
        public void TestCountsLineInFile()
        {
            
        }

        
    }
}
