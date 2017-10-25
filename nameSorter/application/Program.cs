using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new NameSorter();
            Console.WriteLine("nameSorter initialised.\n\n");

            string input= null;

            if (args.Length == 0 || !File.Exists(args[0]))
            {
                while(input == null)
                {
                    Console.WriteLine("Please enter correct file path:\n");
                    input = Console.ReadLine();

                    if (input != null && (File.Exists(Path.GetFullPath(input))))
                    {
                        break;
                    }
                    input = null;
                }
            }
            else
            {
                input = args[0];
            }

            app.parseFile(input);
            Console.Write("Reading file...\n");

            app.sort();
            Console.Write("Sorting...\n");

            app.writeToFile();
            Console.Write("Writing to file...\n\n");

            app.displaySorted();
            Console.Write("\n\nSort Complete. Press Any Key to exit...");
            Console.ReadKey(true);
        }

    }
}
