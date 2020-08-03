using NUnit.Framework;
using TSVValidation;
using System;
using System.IO;

namespace Tests
{
    public class ValidationUnitTests
    {
        string RootFolder;
        [SetUp]
        public void Setup()
        {
            string nUnitTestsFolder = AppDomain.CurrentDomain.BaseDirectory;
            RootFolder = Path.GetFullPath((Path.Combine(nUnitTestsFolder, @"..\..\..\..\")));
        }

        [Test]
        public void EmptyFile()
        {
            string path = Path.Combine(RootFolder, @"Example Data\Empty.tsv");
            var validator = new TSVValidator(path);
            try
            {
                bool result = validator.IsValid();
                Assert.False(result);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Target file doesn't contain data.");
            }
        }

        [Test]
        public void BrokenFormatFile()
        {
            string path = Path.Combine(RootFolder, @"Example Data\BrokenFormat.tsv");
            var validator = new TSVValidator(path);
            try
            {
                bool result = validator.IsValid();
                Assert.False(result);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Invalid TSV format.");
            }
        }

        [Test]
        public void NotExistFile()
        {
            string path = Path.Combine(RootFolder, @"Example Data\NotExist.tsv");
            var validator = new TSVValidator(path);
            try
            {
                bool result = validator.IsValid();
                Assert.False(result);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "File doesn't exist.");
            }
        }

        [Test]
        public void UnknownComplexityValidation()
        {
            string path = Path.Combine(RootFolder, @"Example Data\UnknownComplexity.tsv");
            var validator = new TSVValidator(path);

            bool result = validator.IsValid();
            Assert.True(result);
        }

        [Test]
        public void FileWithEmptyLines()
        {
            string path = Path.Combine(RootFolder, @"Example Data\IncludesEmptyLines.tsv");
            var validator = new TSVValidator(path);

            bool result = validator.IsValid();
            Assert.True(result);
        }


        [Test]
        public void SingleColumn()
        {
            string path = Path.Combine(RootFolder, @"Example Data\SingleColumn.tsv");
            var validator = new TSVValidator(path);

            bool result = validator.IsValid();
            Assert.True(result);
        }

        [Test]
        public void RowsCount()
        {
            string path = Path.Combine(RootFolder, @"Example Data\SingleColumn.tsv");
            var validator = new TSVValidator(path);

            bool result = validator.IsValid();
            Assert.True(result);
            int rows = 9;
            Assert.True(validator.TSVContent.Count == rows);
        }

    }
}