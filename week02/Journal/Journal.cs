using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    // Add a new entry
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Display all entries
    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(entry.ToString());
        }
    }

    // Save entries to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine($"Journal saved successfully to '{filename}'.");
    }

    // Load entries from a file
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                Entry entry = Entry.FromFileFormat(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded successfully from '{filename}'.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    internal static void DisplayEntry()
    {
        throw new NotImplementedException();
    }
}

