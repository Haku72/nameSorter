using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class NameSorter
{
    public string filePath { get; private set; }
    public List<String[]> namesList_unsorted { get; private set; }
    public List<String[]> namesList_sorted { get; private set; }


    public NameSorter()
    {
        filePath = null;
        namesList_unsorted = new List<string[]>();
        namesList_sorted = new List<string[]>();
    }

    public void parseFile(String path)
    {
        filePath = Path.GetDirectoryName( Path.GetFullPath(path) );

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                namesList_unsorted.Add(line.Split());
            }
        }

        namesList_sorted.Capacity = namesList_unsorted.Count;
    }

    public void sort()
    {
        namesList_sorted = namesList_unsorted.OrderBy(name => name.Last()).
            ThenBy(name => name.First()).
            ThenBy(name => name.ElementAtOrDefault(2)).
            ThenBy(name => name.ElementAtOrDefault(3)).
        ToList();
    }

    public void writeToFile()
    {
        if(filePath == null)
        {
            throw new ArgumentNullException(filePath, "filePath not set");
        }

        if (namesList_sorted.Count == 0)
        {
            throw new NullReferenceException("namesList_sorted empty");
        }

        string path = filePath + @"\sorted-names-list.txt";

        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (String[] p in namesList_sorted)
            {
                string s = String.Join(" ", p);
                writer.WriteLine(s);
            }
        }
    }

    public void displaySorted()
    {
        foreach (String[] p in namesList_sorted)
        {
            string s = String.Join(" ", p);
            Console.WriteLine(s);
        }
    }
}