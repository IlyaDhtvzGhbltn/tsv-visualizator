using NUnit.Framework;
using TSVValidation;
using System;
using System.Linq;
using System.IO;
using Parser;
using DTO;

namespace Tests
{
    public class ParseUnitTests
    {
        string RootFolder;
        [SetUp]
        public void Setup()
        {
            string nUnitTestsFolder = AppDomain.CurrentDomain.BaseDirectory;
            RootFolder = Path.GetFullPath((Path.Combine(nUnitTestsFolder, @"..\..\..\..\")));
        }

        [Test]
        public void RowsCount()
        {
            string path = Path.Combine(RootFolder, @"Example Data\CorrectExample.tsv");
            var validator = new TSVValidator(path);
            bool valid = validator.IsValid();
            Assert.True(valid);

            ITSVParser parser = new TSVParser(validator.TSVContent);
            TSVData data = parser.Parse();
            Assert.True(data.Rows.Count == 8);
        }

        [Test]
        public void HeadersCount()
        {
            string path = Path.Combine(RootFolder, @"Example Data\CorrectExample.tsv");
            var validator = new TSVValidator(path);
            bool valid = validator.IsValid();
            Assert.True(valid);

            ITSVParser parser = new TSVParser(validator.TSVContent);
            TSVData data = parser.Parse();
            Assert.IsTrue(data.Headers.Count == 8);
        }

        [Test]
        public void DateTimeFormatExist()
        {
            string path = Path.Combine(RootFolder, @"Example Data\CorrectExample.tsv");
            var validator = new TSVValidator(path);
            bool valid = validator.IsValid();
            Assert.True(valid);

            ITSVParser parser = new TSVParser(validator.TSVContent);
            TSVData data = parser.Parse();
            var row = data.Rows.First();
            Assert.NotNull(row);

            var cell = row.Cells.FirstOrDefault(x => x.Type.FullName == DateTime.Now.GetType().FullName);
            Assert.NotNull(cell);
        }
    }
}