using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    // Convert to a savable format (using "|" as a separator)
    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    // Create an Entry from saved data
    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        Entry entry = Entry.FromFileFormat(line);
                if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
}
