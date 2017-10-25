using System;
using System.IO;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTests
    {
        private readonly NameSorter _sorter;
        private string testPath;
        private int names_Expected;

        public UnitTests()
        {
            _sorter = new NameSorter();
            testPath = Path.GetFullPath(@"..\..\unsorted-names-list.txt");
            names_Expected = 11;
        }

        [Theory]
        [InlineData (@"..\..\unsorted-names-list.txt")]
        [InlineData(@"C:\Users\R Fujisawa\Source\Repos\nameSorter\nameSorter\XUnitTestProject\bin\unsorted-names-list.txt")]
        public void ReadTest(string path)
        {
            _sorter.parseFile(path);

            Assert.True(System.IO.Directory.Exists(_sorter.filePath), "Retrieved path: "+_sorter.filePath);
            Assert.True(_sorter.namesList_unsorted.Count == names_Expected);
        }

        [Fact]
        public void SortTest()
        {
            _sorter.parseFile(testPath);
            _sorter.sort();

            List<String[]> testList = new List<string[]>();
            using (StreamReader reader = new StreamReader(@"..\..\sorted-names-test.txt") )
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    testList.Add(line.Split());
                }
            }

            Assert.True(_sorter.namesList_sorted.Count == names_Expected);
            Assert.Equal(testList, _sorter.namesList_sorted);
        }

        [Fact]
        public void WriteTest()
        {
            string expectedFilePath = Path.GetDirectoryName(testPath) + @"\sorted-names-list.txt";

            _sorter.parseFile(testPath);
            _sorter.sort();
            _sorter.writeToFile();

            Assert.True( File.Exists(expectedFilePath), "File not found at: " + expectedFilePath );
        }
    }
}
