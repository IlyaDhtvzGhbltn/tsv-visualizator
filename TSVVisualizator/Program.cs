using McMaster.Extensions.CommandLineUtils;
using System;

namespace TSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var app = new CommandLineApplication();
                app.Command("read", (command) => TSVHelper.PrintData(command));
                app.Execute(args);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("End of programm. Press any key to exit.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
    }
}
