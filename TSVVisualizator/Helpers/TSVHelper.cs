using DTO;
using System;
using Extensions;
using TSVReader.Output;
using McMaster.Extensions.CommandLineUtils;
using Parser;

namespace TSVReader
{
    static class TSVHelper
    {
        public static void PrintData(CommandLineApplication command)
        {
            CommandOption file = command.Option("-file", "Full path to the input file.", CommandOptionType.SingleValue);
            CommandOption sort = command.Option("-sortByStartDate", "Sort results by column 'Start date' in ascending order.", CommandOptionType.SingleOrNoValue);
            CommandOption project = command.Option("-projectId", "filter results by column 'Project'.", CommandOptionType.SingleOrNoValue);

            command.OnExecute(() => 
            {
                int? projectIdFilter = null;
                bool sortByDateFilter = false;
                string pathToFile = string.Empty;

                projectIdFilter = projectIdFilter.TryParseNullable(project.Value());
                bool.TryParse(sort.Value(), out sortByDateFilter);
                pathToFile = file.Value();

                TSVData data = ReadTSV(pathToFile);
                TSVData filteredData = FilterTSV(data, sortByDateFilter, projectIdFilter);

                IOutput @out = new ConsoleOutput();
                @out.Print(filteredData);
            });
        }

        private static TSVData ReadTSV(string path)
        {
            var validator = new TSVValidation.TSVValidator(path);
            bool isTSVFileValid = validator.IsValid();
            if (isTSVFileValid)
            {
                ITSVParser parser = new TSVParser(validator.TSVContent);
                TSVData data = parser.Parse();
                return data;
            }
            throw new Exception("Invalid TSV file.");
        }

        private static TSVData FilterTSV(TSVData data, bool sortByDate, int? projectIdFilter)
        {
            data.ClearNULLs(new string[] { "Savings amount", "Currency" });
            if (projectIdFilter != null)
                data = data.FilterProject((int)projectIdFilter);
            if (sortByDate)
                data = data.OrderByDate();
            return data;
        }
    }
}
