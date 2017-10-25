using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace nameSorter
{
    class Person
    {
        public string[] name;


    }


    class Program
    {
        static void Main(string[] args)
        {
            String path = "..\\names.txt";

            List<Person> list = new List<Person>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ( (line = reader.ReadLine()) != null)
                {
                    Person person = new Person();
                   person.name = line.Split();
                    list.Add(person);
                }
            }

            var sortedList = list.OrderBy(p => p.name.Last()).
                ThenBy(p => p.name.First());
                //ThenBy(p => p.name.Last()).
                //ThenBy(p => p.name.Last());

            foreach(Person p in sortedList)
            {
                string s = String.Join(" ", p.name);
                Console.WriteLine(s);
            }

            Console.Write("\nPress Any Key to continue...");
            Console.ReadKey(true);
        }
    }
}
